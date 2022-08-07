namespace PowerLineTestTask.Tests;

public class CarLogicTest
{
    private const int ValidMaxPassengersCount = 5;
    private const double ValidFuelTankVolume = 40;
    private const double ValidAverageFuelConsumptionFor100Km = 8;
    private const double ValidSpeed = 60;

    [Fact]
    public void CanNot_Set_PassengersCount_More_Than_MaxPassengersCount()
    {
        var car = new Car(
            ValidMaxPassengersCount
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            car.PassengersCount = ValidMaxPassengersCount + 1;
        });
    }

    [Fact]
    public void Distance_Can_Drive_Without_Encumbrance()
    {
        var currentFuelLevel = 50d;
        var car = new Car(
            ValidMaxPassengersCount
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel
        };

        var distance = car.DistanceCanDrive();
        var expectedDistance = (currentFuelLevel / ValidAverageFuelConsumptionFor100Km * 100) * (1 - car.PassengersCount * 0.06); 
        
        Assert.Equal(expectedDistance, distance);
    }
    
    [Fact]
    public void Distance_Can_Drive_With_Encumbrance()
    {
        var currentFuelLevel = 50d;
        var car = new Car(
            ValidMaxPassengersCount
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel,
            PassengersCount = ValidMaxPassengersCount,
        };

        var distance = car.DistanceCanDrive();
        var expectedDistance = (currentFuelLevel / ValidAverageFuelConsumptionFor100Km * 100) * (1 - car.PassengersCount * 0.06); 
        
        Assert.Equal(expectedDistance, distance);
    }
    
    [Fact]
    public void Distance_Can_Drive_For_Full_Tank()
    {
        var currentFuelLevel = 50d;
        var car = new Car(
            ValidMaxPassengersCount
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel,
            PassengersCount = ValidMaxPassengersCount,
        };

        var distance = car.DistanceForFullTank();
        var expectedDistance = (ValidFuelTankVolume / ValidAverageFuelConsumptionFor100Km * 100) * (1 - car.PassengersCount * 0.06); 
        
        Assert.Equal(expectedDistance, distance);
    }
}