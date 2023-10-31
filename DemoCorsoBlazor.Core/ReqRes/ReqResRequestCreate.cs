using System.ComponentModel.DataAnnotations;

namespace DemoCorsoBlazor.Core.ReqRes;

public class ReqResData
{
    [Required(ErrorMessage = "Il nome è obbligatorio")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Il lavoro è obbligatorio")]
    public string Job { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}



public class ReqResUser
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public User[] data { get; set; }
    public Support support { get; set; }
}

public class Support
{
    public string url { get; set; }
    public string text { get; set; }
}

public class User
{
    public int id { get; set; }
    public string email { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string avatar { get; set; }
}
