public class Product : IUniqueEntity
{
    [Unique]
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Calories { get; set; }
    public double Carbs { get; set; }
    public double Proteins { get; set; }
    public double Fats { get; set; }

    public string GetUniqueKey() => Name;
}