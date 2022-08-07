namespace PowerLineTestTask.Tests;

public class CarsCreationTest
{
    private const int ValidMaxPassengersCount = 5;
    private const double ValidFuelTankVolume = 40;
    private const double ValidAverageFuelConsumptionFor100Km = 8;
    private const double ValidSpeed = 60;

    [Fact]
    public void CanNot_Creat_Car_With_Negative_Speed()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new Car(
                ValidMaxPassengersCount
                , ValidFuelTankVolume
                , ValidAverageFuelConsumptionFor100Km
                , -10);
        });
    }

    [Fact]
    public void CanNot_Create_Car_With_Negative_MaxPassengersCount()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new Car(
                -10
                , ValidFuelTankVolume
                , ValidAverageFuelConsumptionFor100Km
                , ValidSpeed);
        });
    }

    [Fact]
    public void Can_Create_Car_With_Zero_MaxPassengersCount()
    {
        var car = new Car(
            0
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed);
        
        Assert.NotNull(car);
    }
    
    [Fact]
    public void CanNot_Create_Car_With_Negative_AverageFuelConsumptionFor100Km()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new Car(
                ValidMaxPassengersCount
                , ValidFuelTankVolume
                , -4
                , ValidSpeed);
        });
    }
    
    [Fact]
    public void CanNot_Create_Car_With_Negative_FuelTankVolume()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new Car(
                ValidMaxPassengersCount
                , -60
                , ValidAverageFuelConsumptionFor100Km
                , ValidSpeed);
        });
    }
}