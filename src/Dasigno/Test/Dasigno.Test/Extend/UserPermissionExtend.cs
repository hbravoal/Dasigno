using Bogus;

namespace Dasigno.Test.Extend;

public static class UserExtend
{
   
    public static Dasigno.Domain.Entities.User GenerateObject(this Faker<Dasigno.Domain.Entities.User> faker)
    {
        faker.RuleFor(a => a.DateOfBirth, z => DateTime.UtcNow);
        faker.RuleFor(a => a.FirstName, z => z.Lorem.Lines(2));
        faker.RuleFor(a => a.LastName, z => z.Name.FirstName());
        faker.RuleFor(a => a.MiddleName, z => z.Name.FirstName());
        faker.RuleFor(a => a.SecondLastName, z => z.Name.FirstName());
        faker.RuleFor(a => a.Enabled, z => true);
        faker.RuleFor(a => a.CreatedDate, z => DateTime.UtcNow);
        faker.RuleFor(a => a.LastUpdate, z => DateTime.UtcNow);
        return faker.Generate();
    }

    public static List<Dasigno.Domain.Entities.User> GenerateObjectlist(this Faker<Dasigno.Domain.Entities.User> faker)
    {
        faker.RuleFor(a => a.DateOfBirth, z => DateTime.UtcNow);
        faker.RuleFor(a => a.FirstName, z => z.Lorem.Lines(2));
        faker.RuleFor(a => a.LastName, z => z.Name.FirstName());
        faker.RuleFor(a => a.MiddleName, z => z.Name.FirstName());
        faker.RuleFor(a => a.SecondLastName, z => z.Name.FirstName());
        faker.RuleFor(a => a.Enabled, z => true);
        faker.RuleFor(a => a.CreatedDate, z => DateTime.UtcNow);
        faker.RuleFor(a => a.LastUpdate, z => DateTime.UtcNow);
        return faker.Generate(5).ToList();
    }

}