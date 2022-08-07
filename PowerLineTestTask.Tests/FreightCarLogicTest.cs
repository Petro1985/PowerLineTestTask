namespace PowerLineTestTask.Tests;

public class FreightCarLogicTest
{
    private const int ValidMaxWeight = 2100;
    private const double ValidFuelTankVolume = 40;
    private const double ValidAverageFuelConsumptionFor100Km = 8;
    private const double ValidSpeed = 60;

    [Fact]
    public void CanNot_Set_Weight_More_Than_MaxWeight()
    {
        var car = new FreightCar(
            ValidMaxWeight
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            car.Weight = ValidMaxWeight + 1;
        });
    }

    [Fact]
    public void Distance_Can_Drive_Without_Encumbrance()
    {
        var currentFuelLevel = 50d;
        var car = new FreightCar(
            ValidMaxWeight
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel
        };

        var distance = car.DistanceCanDrive();
        var expectedDistance = (currentFuelLevel / ValidAverageFuelConsumptionFor100Km * 100) * (1 - (car.Weight / 200) * 0.04); 
        
        Assert.Equal(expectedDistance, distance);
    }
    
    [Fact]
    public void Distance_Can_Drive_With_Encumbrance()
    {
        var currentFuelLevel = 50d;
        var car = new FreightCar(
            ValidMaxWeight
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel,
            Weight = ValidMaxWeight,
        };

        var distance = car.DistanceCanDrive();
        var expectedDistance = (currentFuelLevel / ValidAverageFuelConsumptionFor100Km * 100) * (1 - (car.Weight / 200) * 0.04); 
        
        Assert.Equal(expectedDistance, distance);
    }
    
    [Fact]
    public void Distance_Can_Drive_For_Full_Tank()
    {
        var currentFuelLevel = 50d;
        var car = new FreightCar(
            ValidMaxWeight
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed)
        {
            CurrentFuelLevel = currentFuelLevel,
            Weight = ValidMaxWeight,
        };

        var distance = car.DistanceForFullTank();
        var expectedDistance = (ValidFuelTankVolume / ValidAverageFuelConsumptionFor100Km * 100) * (1 - (car.Weight / 200) * 0.04); 
        
        Assert.Equal(expectedDistance, distance);
    }
   
}