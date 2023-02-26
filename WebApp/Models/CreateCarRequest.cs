namespace WebApp.Model;

public sealed class CreateOrUpdateCarRequest
{
    public int Year { get; set; }
    public int Doors { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
}


