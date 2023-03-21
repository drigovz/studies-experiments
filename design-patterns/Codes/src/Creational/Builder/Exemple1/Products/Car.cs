namespace Builder.Products;

internal class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool TripComputer { get; set; }
    public bool Gps { get; set; }

    public override string ToString() =>
        $"Car contains: \n{Seats}: seats \nEngine: {Engine} \nTrip computer: {TripComputer} \nGPS: {Gps}";
}