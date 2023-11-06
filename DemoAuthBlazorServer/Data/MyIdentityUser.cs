using Microsoft.AspNetCore.Identity;

namespace DemoAuthBlazorServer.Data;

public class MyIdentityUser: IdentityUser
{
    public string CodiceFiscale { get; set; } = "";  
}
