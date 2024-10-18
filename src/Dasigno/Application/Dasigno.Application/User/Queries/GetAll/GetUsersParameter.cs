using Dasigno.Application.Filters;

namespace Dasigno.Application.User.Queries.GetAll;

public class GetUsersParameter : RequestParameter
{
    public string? FieldToSearch { get; set; }
}