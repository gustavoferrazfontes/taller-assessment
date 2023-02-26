namespace WebApp.Domain;

public sealed class Car
{
    private Car(int id, string make, string model, int year, int doors, string color, decimal price)
    {
        Id = id;
        Make = make;
        Model = model;
        Year = year;
        Doors = doors;
        Color = color;
        Price = price;
    }

    public int Id { get; }
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public int Doors { get; private set; }
    public string Color { get; private set; }
    public decimal Price { get; private set; }

    public static Car Create(string make, string model, int year, int doors, string color, decimal price, int id = 0)
    {
        if (string.IsNullOrWhiteSpace(make))
            throw new ArgumentException("Make cannot be null");

        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("model cannot be null");

        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("model cannot be null");

        return new Car(id, make, model, year, doors, color, price);
    }

    public void Update(string? make, string? model, int year, int doors, string? color, decimal price)
    {
        if (!string.IsNullOrWhiteSpace(make))
            Make = make;

        if (!string.IsNullOrWhiteSpace(model))
            Model = model;

        if (!string.IsNullOrWhiteSpace(color))
            Color = color;

        if (year != 0)
            Year = year;

        if (doors != 0)
            Doors = doors;

        if (price != 0)
            Price = price;
    }
}
