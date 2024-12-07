using CarRental.Application.Common.Interfaces.Authentication;
using CarRental.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Users.Quieries.ValidateToken
{
    public class ValidateTokenQueryHandler : IRequestHandler<ValidateTokenQuery, Response>
    {
        private IJwtTokenGenerator _jwtTokenGenerator;

        public ValidateTokenQueryHandler(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Response> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var isAuthenticated = _jwtTokenGenerator.ValidateToken(request.Token);

            if (isAuthenticated)
            {
                return Response.SuccessResponse("Successful");
            }
            else
            {
                return Response.FailResponse("Unsuccessful");
            }

        }
    }
}
