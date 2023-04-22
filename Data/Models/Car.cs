namespace CarServiceCRUD.Data.Models;

public class Car
{
    public int Id { get; init; }
    public string Make { get; init; } = null!;
    public string Model { get; init; } = null!;
    public int Year { get; init; }

    // Keep the problem set, the other props init/ immutable. 
    // You can always find more problems in a car, but cannot change its make and model
    public string Problem { get; set; } = null!;
}