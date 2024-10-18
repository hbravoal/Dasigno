using Dasigno.Application.Exceptions;
using Dasigno.Application.Wrappers;
using Dasigno.Domain.Interfaces.Persistence;
using MediatR;

namespace Dasigno.Application.User.Commands.Update;

public class UpdateUserCommand : IRequest<Response<int>>
{
    public int Id { get; private set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? SecondLastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public decimal Salary { get; set; }

    public void SetId(int id)
    {
        this.Id = id;
    }
        
    public class UpdateOwnerCommandHandler(IUserRepository target)
        : IRequestHandler<UpdateUserCommand, Response<int>>
    {
        public async Task<Response<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await target.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

            if (result == null)
            {
                throw new ApiException($"User Not Found.");
            }

            result.LastName = request.LastName;
            result.FirstName = request.FirstName;
            result.Salary = request.Salary;
            result.SecondLastName = request.SecondLastName;
            result.MiddleName = request.MiddleName;
            result.DateOfBirth = request.DateOfBirth;
            await target.UpdateAsync(result, cancellationToken);
            return new Response<int>(result.Id);
        }
    }
}