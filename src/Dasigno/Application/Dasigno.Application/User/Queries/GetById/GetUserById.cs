using Dasigno.Application.Exceptions;
using Dasigno.Domain.Interfaces.Persistence;
using MediatR;
using Dasigno.Application.Wrappers;

namespace Dasigno.Application.User.Queries.GetById
{
    public class GetUserById : IRequest<Response<Domain.Entities.User>>
    {
        #region Properties

        public int Id { get; init; }

        #endregion
        public class GetUserByIdHandler(IUserRepository target)
            : IRequestHandler<GetUserById, Response<Domain.Entities.User>>
        {
            public async Task<Response<Domain.Entities.User>> Handle(GetUserById query, CancellationToken cancellationToken)
            {
                var result = await target.GetByIdAsync(query.Id, cancellationToken: cancellationToken);
                if (result == null) throw new ApiException($"User Not Found.");
                return new Response<Domain.Entities.User>(result);
            }
        }
    }
}
