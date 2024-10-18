using Dasigno.Application.Exceptions;
using Dasigno.Application.Wrappers;
using Dasigno.Domain.Interfaces.Persistence;
using MediatR;

namespace Dasigno.Application.User.Commands.DeleteById
{
    public class DeleteUserByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; init; }
        public class DeleteOwnerByIdCommandHandler(IUserRepository target)
            : IRequestHandler<DeleteUserByIdCommand, Response<int>>
        {
            public async Task<Response<int>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                var result = await target.GetByIdAsync(command.Id, cancellationToken: cancellationToken);
                if (result == null) throw new ApiException($"User Not Found.");
                await target.DeleteAsync(result, cancellationToken);
                return new Response<int>(result.Id);
            }
        }
    }
}
