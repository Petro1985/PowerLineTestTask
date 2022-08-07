using PowerLineTestTask.Utilities;

namespace PowerLineTestTask;

public abstract class CarBase
{
    private readonly double _fuelTankVolume;
    
    public abstract CarType Type { get; }
    public double AverageFuelConsumptionFor100Km { get; }
    public double CurrentFuelLevel { get; set; }
    public double SpeedKmPerHour { get;  } 
    
    protected virtual double Efficiency => 1d;

    protected CarBase(double fuelTankVolume, double averageFuelConsumptionFor100Km, double speed)
    {
        Guards.MustBePositive(fuelTankVolume);
        Guards.MustBePositive(speed);
        Guards.MustBePositive(averageFuelConsumptionFor100Km);
        
        AverageFuelConsumptionFor100Km = averageFuelConsumptionFor100Km;
        _fuelTankVolume = fuelTankVolume;
        SpeedKmPerHour = speed;
    }

    private double DistanceCanDriveWithoutEncumbrance(double fuelLevel)
        => fuelLevel / AverageFuelConsumptionFor100Km * 100;
    
    public double DistanceCanDriveWithFullTank()
        => DistanceCanDriveWithoutEncumbrance(_fuelTankVolume) * Efficiency;
    public double DistanceCanDrive()
        => Efficiency * DistanceCanDriveWithoutEncumbrance(CurrentFuelLevel);
    
    public double TimeToDrive(double distance)
    {
        var distanceCanDrive = DistanceCanDrive();
        if (distanceCanDrive < distance)
        {
            throw new Exception($"Not enough fuel ({CurrentFuelLevel}) to drive {distance} km");
        }

        return distance / SpeedKmPerHour;
    }
}

public enum CarType
{
    Car,
    FreightCar,
    SportCar,
}