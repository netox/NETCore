using CarsCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarsData
{
    public interface ICarsData
    {   
        IEnumerable<Car> getCarsByName(string name = null);
        Car GetById(int carId);
        Car Add(Car NewCar);
        Car Update(Car updatedCar);

        int commit();

    }

    public class InMemoryCarsData : ICarsData
    {
        List<Car> cars;
        public InMemoryCarsData()
        {
            cars = new List<Car>()
            {
                new Car{Id=1,Name="Versa",CarColor = Colors.Silver,CarBrand = Brands.Nissan},
                new Car{Id=2,Name="Mazda 3",CarColor = Colors.Red,CarBrand = Brands.Mazda},
                new Car{Id=3,Name="Swift",CarColor = Colors.White,CarBrand = Brands.Suzuki},
                new Car{Id=4,Name="Elantra",CarColor = Colors.Black,CarBrand = Brands.Hyundai}
            };
        }

        public Car Add(Car NewCar)
        {
            cars.Add(NewCar);
            NewCar.Id = cars.Max(r => r.Id) + 1;
            return NewCar;
        }

        public Car GetById(int carId)
        {
            return cars.SingleOrDefault<Car>(r => r.Id == carId);
        }

        public IEnumerable<Car> getCarsByName(string name = null)
        {
            return from r in cars
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public int commit()
        {
            return 0;
        }
        public Car Update(Car updatedCar)
        {
            var car = cars.SingleOrDefault(r => r.Id == updatedCar.Id);
            if(car != null)
            {
                car.Name = updatedCar.Name;
                car.CarBrand = updatedCar.CarBrand;
                car.CarColor = updatedCar.CarColor;
            }
            return car;
        }
    }
}
