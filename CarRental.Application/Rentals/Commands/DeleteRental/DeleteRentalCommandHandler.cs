using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Commands.DeleteRental
{
    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, Response>
    {
        private readonly IRentalRepository _rentalRepository;

        public DeleteRentalCommandHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Response> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetByIdAsync(request.Id);

            if (rental is null)
                return Response.FailResponse("No rental record found");

            await _rentalRepository.DeleteAsync(rental);
            await _rentalRepository.SaveChangesAsync();

            return Response.SuccessResponse("The rental record has been successfully deleted");
        }
    }
}
