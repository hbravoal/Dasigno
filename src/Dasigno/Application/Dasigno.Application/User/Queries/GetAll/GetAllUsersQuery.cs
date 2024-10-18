using Dasigno.Application.Wrappers;
using Dasigno.Domain.Interfaces.Persistence;
using MediatR;

namespace Dasigno.Application.User.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<PagedResponse<IEnumerable<GetAllUsersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllOwnersQueryHandler(IUserRepository target)
        : IRequestHandler<GetAllUsersQuery, PagedResponse<IEnumerable<GetAllUsersViewModel>>>
    {
        public async Task<PagedResponse<IEnumerable<GetAllUsersViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new GetUsersParameter
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
            var result = await target.GetPaginingAsync(null,validFilter.PageNumber, validFilter.PageSize, cancellationToken: cancellationToken);
            
            var resultViewModel = result.Select(item => new GetAllUsersViewModel()
                {
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    Salary = item.Salary,
                    SecondLastName = item.SecondLastName,
                    MiddleName = item.MiddleName,
                    DateOfBirth = item.DateOfBirth
                })
                .ToList();
            return new PagedResponse<IEnumerable<GetAllUsersViewModel>>(resultViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
