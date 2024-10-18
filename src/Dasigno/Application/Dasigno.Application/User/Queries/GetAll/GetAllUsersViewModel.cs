namespace Dasigno.Application.User.Queries.GetAll;

public class GetAllUsersViewModel
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? SecondLastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}