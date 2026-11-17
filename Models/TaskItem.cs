namespace TaskTracker.Models;
public class TasKItem
{
    public int ID {get; set;}
    public string Desc {get;set;} = string.Empty;
    public string Status {get;set;} = "ToDO";
    public DateTime CreatedAt {get;set;}
    public DateTime UpdatedAt {get;set;}
    
}
