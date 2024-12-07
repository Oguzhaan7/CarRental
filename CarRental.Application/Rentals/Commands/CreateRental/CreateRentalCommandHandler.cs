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

namespace CarRental.Application.Rentals.Commands.CreateRental
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Response<RentalResponse>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public CreateRentalCommandHandler(IRentalRepository rentalRepository, IPaymentRepository paymentRepository, IInvoiceRepository invoiceRepository, IMapper mapper, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<Response<RentalResponse>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            DateValidation.ValidateDate(request.Rental.StartDate, request.Rental.EndDate);

            var car = await _carRepository.GetByIdAsync(x => x.Id == request.Rental.CarId);

            if (!car.IsAvailable)
                return Response<RentalResponse>.FailResponse("This car is not available for rental", null);

            car.IsAvailable = false;      

            var rental = _mapper.Map<Rental>(request.Rental);
            rental.Payments = _mapper.Map<List<Payment>>(request.Rental.PaymentRequest);
            rental.CreatedDateTime = DateTime.UtcNow;
            rental.UpdatedDateTime = DateTime.UtcNow;

            var rentedDateDiff = request.Rental.EndDate - request.Rental.StartDate;
            var rentedDay = (int)rentedDateDiff.Days != 0 ? (int)rentedDateDiff.Days : 1;

            decimal paymentsAmount = rental.Payments.Sum(x=>x.Amount);

            if(paymentsAmount != car.DailyPrice * rentedDay)
               return Response<RentalResponse>.FailResponse("The sum of payment amounts does not match the invoice total", null);

            Invoice invoice = new()
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = "245545465564",
                PaymentAmount = car.DailyPrice * rentedDay,
                RentalId = rental.Id,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
            };
            
            rental.Invoice = invoice;

            await _paymentRepository.AddRangeAsync(rental.Payments);
            await _invoiceRepository.AddAsync(invoice);
            await _rentalRepository.AddAsync(rental);

            await _carRepository.SaveChangesAsync();
            await _invoiceRepository.SaveChangesAsync();
            await _paymentRepository.SaveChangesAsync();
            await _rentalRepository.SaveChangesAsync();

            return Response<RentalResponse>.SuccessResponse("The car rental process has been successful", _mapper.Map<RentalResponse>(rental));
        }
    }
}
