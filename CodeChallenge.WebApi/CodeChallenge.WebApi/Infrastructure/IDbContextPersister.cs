namespace CodeChallenge.WebApi.Infrastructure;

public interface IDbContextPersister
{
    Task<bool> SaveChanges();
}
