namespace PowerLineTestTask;

public class SportCar : CarBase
{
    public override CarType Type => CarType.SportCar;
    public SportCar(double fuelTankVolume, double averageFuelConsumptionFor100Km, double speed) 
        : base(fuelTankVolume,  averageFuelConsumptionFor100Km,  speed)
    {
    }
}