namespace PowerLineTestTask.Tests;

public class SportCarLogic
{
    private const double ValidFuelTankVolume = 40;
    private const double ValidAverageFuelConsumptionFor100Km = 8;
    private const double ValidSpeed = 60;

    [Fact]
    public void Distance_Can_Drive()
    {
        var currentFuelLevel = 50d;
        var car = new SportCar(
            ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel
        };

        var distance = car.DistanceCanDrive();
        var expectedDistance = (currentFuelLevel / ValidAverageFuelConsumptionFor100Km * 100); 
        
        Assert.Equal(expectedDistance, distance);
    }
    
    [Fact]
    public void Distance_Can_Drive_For_Full_Tank()
    {
        var currentFuelLevel = 50d;
        var car = new SportCar(
             ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel,
        };

        var distance = car.DistanceCanDriveWithFullTank();
        var expectedDistance = (ValidFuelTankVolume / ValidAverageFuelConsumptionFor100Km * 100); 
        
        Assert.Equal(expectedDistance, distance);
    }
    
}