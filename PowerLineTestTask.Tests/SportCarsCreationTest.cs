namespace PowerLineTestTask.Tests;

public class SportCarsCreationTest
{
    private const double ValidFuelTankVolume = 40;
    private const double ValidAverageFuelConsumptionFor100Km = 8;
    private const double ValidSpeed = 60;

    [Fact]
    public void CanNot_Creat_SportCar_With_Negative_Speed()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new SportCar(
                ValidFuelTankVolume
                , ValidAverageFuelConsumptionFor100Km
                , -10);
        });
    }
    
    [Fact]
    public void CanNot_Create_SportCar_With_Negative_AverageFuelConsumptionFor100Km()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new SportCar(
                ValidFuelTankVolume
                , -4
                , ValidSpeed);
        });
    }
    
    [Fact]
    public void CanNot_Create_SportCar_With_Negative_FuelTankVolume()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var car = new SportCar(
                -60
                , ValidAverageFuelConsumptionFor100Km
                , ValidSpeed);
        });
    }
}