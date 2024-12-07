using AutoMapper;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Common.Validations;
using CarRental.Application.Rentals.Common;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Commands.UpdateRental
{
    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, Response<RentalResponse>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public UpdateRentalCommandHandler(IRentalRepository rentalRepository, ICarRepository carRepository, IPaymentRepository paymentRepository, IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<Response<RentalResponse>> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            DateValidation.ValidateDate(request.Rental.StartDate, request.Rental.EndDate);

            Rental rental = await _rentalRepository.GetByIdAsync(x=>x.Id == request.Id, x=>x.Invoice, x=>x.Payments);

            if (rental is null)
                return Response<RentalResponse>.FailResponse("Rental record not found", null);

            if (rental.CarId != request.Rental.CarId || rental.StartDate.Day != request.Rental.StartDate.Day || rental.EndDate.Day != request.Rental.EndDate.Day)
            {
                Invoice invoice = await _invoiceRepository.GetByIdAsync(rental.Invoice.Id);
                Car car = await _carRepository.GetByIdAsync(request.Rental.CarId);

                if (!car.IsAvailable)
                    return Response<RentalResponse>.FailResponse("This car is not available for rental", null);

                car.IsAvailable = false;

                var rentedDateDiff = request.Rental.EndDate - request.Rental.StartDate;
                var rentedDay = (int)rentedDateDiff.Days != 0 ? (int)rentedDateDiff.Days : 1;

                rental.Payments = rental.Payments.Concat(_mapper.Map<List<Payment>>(request.Rental.PaymentRequest)).ToList();

                if (rental.Payments.Sum(x=>x.Amount) < car.DailyPrice * rentedDay)
                    return Response<RentalResponse>.FailResponse("The sum of payment amounts does not match the invoice total", null);

                invoice.UpdatedDateTime = DateTime.UtcNow;
                invoice.PaymentAmount = car.DailyPrice * rentedDay;
            }

            rental.CarId = request.Rental.CarId;
            rental.StartDate = request.Rental.StartDate;
            rental.EndDate = request.Rental.EndDate;
            rental.InsuranceType = request.Rental.InsuranceType;
            rental.UpdatedDateTime = DateTime.UtcNow;

            await _carRepository.SaveChangesAsync();
            await _invoiceRepository.SaveChangesAsync();
            await _paymentRepository.SaveChangesAsync();
            await _rentalRepository.SaveChangesAsync();

            return Response<RentalResponse>.SuccessResponse("The car rental update process has been successful", _mapper.Map<RentalResponse>(rental));
        }
    }
}
