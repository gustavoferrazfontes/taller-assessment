using WebApp.Domain;

namespace WebApp.Data;

internal static class InMemoryDatabase
{
    internal static List<Car> CarCollection = new(){
         Car.Create(   "Audi",  "R8",  2018,  2, "Red",  79995,1 ),
         Car.Create (  "Tesla", "3",  2018,  4,  "Black",  54995,2 ),
         Car.Create(   "Porsche",  " 911 991",  2020,  2,  "White",  155000,3 ),
         Car.Create(   "Mercedes-Benz",  "GLE 63S",  2021,  5,  "Blue",  83995,4 ),
         Car.Create(   "BMW",  "X6 M",  2020,  5,  "Silver",  62995,5),
    };

}
