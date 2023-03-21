using Builder.Interfaces;
using Builder.Products;

namespace Builder.ConcreteBuilders;

internal class CarBuilder : IBuilder
{
    private Car _car = new();

    public CarBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _car = new Car();
    }

    public void SetSeats(int number)
    {
        _car.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _car.Engine = engine;
    }

    public void SetTripComputer()
    {
        _car.TripComputer = true;
    }

    public void SetGps()
    {
        _car.Gps = true;
    }

    public Car Result()
        => _car;
}