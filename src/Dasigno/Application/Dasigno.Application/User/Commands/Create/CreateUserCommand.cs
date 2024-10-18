using Dasigno.Application.Wrappers;
using Dasigno.Domain.Interfaces.Persistence;
using MediatR;

namespace Dasigno.Application.User.Commands.Create
{
    public partial class CreateUserCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }  // Optional field
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }  // Optional field

        public DateTime DateOfBirth { get; set; }

        public decimal Salary { get; set; }

    }
    public class CreateOwnerCommandHandler(IUserRepository repository)
        : IRequestHandler<CreateUserCommand, Response<int>>
    {
        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var resultMap = new Domain.Entities.User
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Enabled = true,
                Salary = request.Salary,
                SecondLastName = request.SecondLastName,
                MiddleName = request.MiddleName,
                DateOfBirth = request.DateOfBirth
            };
            await repository.AddAsync(resultMap, cancellationToken);

            return new Response<int>(resultMap.Id);
        }
    }
}
