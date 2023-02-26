using WebApp.Domain;

namespace WebApp.Data;

public sealed class CarRepository : ICarRepository
{
    public void Delete(int id)
    {
        var foundCar = InMemoryDatabase.CarCollection.Find(car => car.Id == id);

        if (foundCar != null)
        {
            InMemoryDatabase.CarCollection.Remove(foundCar);
            return;
        }

        throw new Exception("car not found");

    }

    public int GenerateId()
    {
        return InMemoryDatabase.CarCollection.LastOrDefault()?.Id + 1 ?? 1;
    }

    public Car Get(int id)
    {
        return InMemoryDatabase.CarCollection.Single(car => car.Id == id);
    }

    public IEnumerable<Car> GetAll()
    {
        return InMemoryDatabase.CarCollection;
    }

    public void Save(Car car)
    {
        InMemoryDatabase.CarCollection.Add(car);
    }

    public void Update(Car car)
    {
        var foundIndex = InMemoryDatabase.CarCollection.FindIndex(0, car => car.Id == car.Id);

        InMemoryDatabase.CarCollection[foundIndex] = car;
    }
}
