namespace GamesMarket.Models;

public class Developer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    private const int MaxLengthName = 60;
    
    public Developer(Guid id, string name)
    {
        string exception = Validation(id, name);
            
        if (exception != string.Empty)
            throw new ArgumentException(exception);
    }

    private string Validation(Guid id, string name)
    {
        if (name.Length > MaxLengthName)
            return $"Name must be less than {MaxLengthName}";
            
        Id = id;
        Name = name;
            
        return string.Empty;
    }
}