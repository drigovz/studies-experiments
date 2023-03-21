using Builder.Interfaces;

namespace Builder;

internal class Director
{
    private IBuilder _builder;
    
    public IBuilder Builder
    {
        set => _builder = value;
    }
    
    public void BuildSportiveCar(int seats)
    {
        _builder.SetSeats(seats);
    }
    
    public void BuildSuvCar(int seats, string engine)
    {
        _builder.SetSeats(seats);
        _builder.SetEngine(engine);
        _builder.SetTripComputer();
        _builder.SetGps();
    }
}