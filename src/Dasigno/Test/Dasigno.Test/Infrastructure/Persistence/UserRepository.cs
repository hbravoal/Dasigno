using Dasigno.Test.Extend;
using Bogus;

namespace Dasigno.Test.Infrastructure.Persistence;

[TestFixture]
public class UserRepository
{

    [Test]
    public void CreateUserSuccessCase()
    {
        //Arrange

        var commentEntity = new Faker<Domain.Entities.User>().GenerateObject();

        //Mock
        var unitOfWork = UserContextExtend.UnitOfWork;
        unitOfWork.UserRepository.AddAsync(commentEntity).Wait();
        unitOfWork.SaveAsync().GetAwaiter().GetResult();

        //Assert
        Assert.That(commentEntity.Id, Is.GreaterThan(0));
    }


    [Test]
    public void UpdateUserSuccessCase()
    {
        //Arrange

        var request = new Faker<Domain.Entities.User>().GenerateObject();

        //Action
        var unitOfWork = UserContextExtend.UnitOfWork;
        var commentToUpdate = unitOfWork.UserRepository.GetFirstOrDefaultAsync(withDisabled: true).Result;
        commentToUpdate.LastName = request.LastName;
        commentToUpdate.LastUpdate = DateTime.UtcNow;
        unitOfWork.UserRepository.UpdateAsync(commentToUpdate, CancellationToken.None).GetAwaiter().GetResult();
        unitOfWork.SaveAsync().Wait();

        var commentEntity = unitOfWork.UserRepository.GetByIdAsync(commentToUpdate.Id, true, CancellationToken.None).GetAwaiter().GetResult();

        //Assert
        Assert.That(commentEntity, Is.Not.Null);
        Assert.That(commentEntity.LastName, Is.EqualTo(request.LastName));
        Assert.That(commentEntity.LastUpdate, Is.EqualTo(commentToUpdate.LastUpdate));
    }
}