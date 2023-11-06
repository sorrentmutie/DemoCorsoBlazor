using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoAuthBlazorServer.Data;

public class MyAuthenticationContext: IdentityDbContext<MyIdentityUser>
{
    public MyAuthenticationContext(DbContextOptions<MyAuthenticationContext>
        opzioni): base(opzioni)
    {
        
    }
}
