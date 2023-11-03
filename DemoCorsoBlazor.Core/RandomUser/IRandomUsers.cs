namespace DemoCorsoBlazor.Core.RandomUser;

public interface IRandomUsers
{
    Task<RandomUserViewModel?> GetUsersAsync(int count);
}
