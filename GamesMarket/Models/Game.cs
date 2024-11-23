namespace GamesMarket.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid? DeveloperId { get; set; } = null;
        
        private const int MaxLengthName = 50;
        private const int MaxDescriptionName = 250;

        public Game(Guid id, string name, string description, decimal price, Guid? developerId)
        {
            string exception = Validation(id, name, description, price, developerId);
            
            if (exception != string.Empty)
                throw new ArgumentException(exception);
        }

        private string Validation(Guid id, string name, string description, decimal price, Guid? developerId)
        {
            if (name.Length > MaxLengthName)
                return $"Name must be less than {MaxLengthName}";
            
            if (description.Length > MaxDescriptionName)
                return $"Description must be less than {MaxDescriptionName}";
            
            if (price < 0)
                return $"Price cannot be negative";
            
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            DeveloperId = developerId;
            
            return string.Empty;
        }
    }
}
