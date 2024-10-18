
namespace Dasigno.Domain.Entities
{
    public class User : Entity<int>
    {

        public string FirstName { get; set; }

      
        public string? MiddleName { get; set; }  // Optional field

     
        public string LastName { get; set; }

      
        public string? SecondLastName { get; set; }  // Optional field

        public DateTime DateOfBirth { get; set; }

        public decimal Salary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}