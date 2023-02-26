namespace WebApp.Domain
{
    public interface ICarRepository
    {
        Car Get(int id);
        IEnumerable<Car> GetAll();
        void Delete(int id);
        void Save(Car car);
        void Update(Car car);

        int GenerateId();

    }
}
