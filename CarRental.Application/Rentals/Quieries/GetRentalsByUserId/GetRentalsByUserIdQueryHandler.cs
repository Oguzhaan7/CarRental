using AutoMapper;
using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Application.Common.Responses;
using CarRental.Application.Rentals.Common;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Rentals.Quieries.GetRentalsByUserId
{
    public class GetRentalsByUserIdQueryHandler : IRequestHandler<GetRentalsByUserIdQuery, Response<PagedResponse<RentalResponse>>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetRentalsByUserIdQueryHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<Response<PagedResponse<RentalResponse>>> Handle(GetRentalsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _rentalRepository.GetAllPagedAsync(x => x.UserId == request.Id, request.PageNumber, request.PageSize, x => x.Invoice, x => x.Payments);

            var rentals = PagedResponse<Rental>.ToPagedResponse(query, request.PageNumber, request.PageSize);

            if(!rentals.Items.Any())
                return Response<PagedResponse<RentalResponse>>.FailResponse("There is no rental record found for this user", null);

            return Response<PagedResponse<RentalResponse>>.SuccessResponse("The rental records have been successfully retrieved", _mapper.Map<PagedResponse<RentalResponse>>(rentals));
        }
    }
}
