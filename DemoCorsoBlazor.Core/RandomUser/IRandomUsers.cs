namespace DemoCorsoBlazor.Core.RandomUser;

public interface IRandomUsers
{
    Task<Utente[]?> GetUsersAsync(int count);
}
