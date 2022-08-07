namespace PowerLineTestTask.Tests;

public class FreightCarsCreationTest
{
    private const int ValidMaxWeight = 2000;
    private const double ValidFuelTankVolume = 40;
    private const double ValidAverageFuelConsumptionFor100Km = 8;
    private const double ValidSpeed = 60;

    [Fact]
    public void CanNot_Creat_FreightCar_With_Negative_Speed()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new FreightCar(
                ValidMaxWeight
                , ValidFuelTankVolume
                , ValidAverageFuelConsumptionFor100Km
                , -10);
        });
    }

    [Fact]
    public void CanNot_Create_FreightCar_With_Negative_MaxWeight()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new FreightCar(
                -10
                , ValidFuelTankVolume
                , ValidAverageFuelConsumptionFor100Km
                , ValidSpeed);
        });
    }

    [Fact]
    public void Can_Create_FreightCar_With_Zero_MaxWeight()
    {
        var car = new FreightCar(
            0
            , ValidFuelTankVolume
            , ValidAverageFuelConsumptionFor100Km
            , ValidSpeed);
        
        Assert.NotNull(car);
    }
    
    [Fact]
    public void CanNot_Create_FreightCar_With_Negative_AverageFuelConsumptionFor100Km()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new FreightCar(
                ValidMaxWeight
                , ValidFuelTankVolume
                , -4
                , ValidSpeed);
        });
    }
    
    [Fact]
    public void CanNot_Create_FreightCar_With_Negative_FuelTankVolume()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new FreightCar(
                ValidMaxWeight
                , -60
                , ValidAverageFuelConsumptionFor100Km
                , ValidSpeed);
        });
    }
}