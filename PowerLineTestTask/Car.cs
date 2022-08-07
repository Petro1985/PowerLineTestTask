using PowerLineTestTask.Utilities;

namespace PowerLineTestTask;

public class Car : CarBase
{
    private readonly int _maxPassengersCount;
    private int _currentPassengersCount;
    protected override double Efficiency => (1 - PassengersCount * ReducingDistancePerPassenger); 

    public Car(int maxPassengersCount, double fuelTankVolume, double averageFuelConsumptionFor100Km, double speed) 
        : base(fuelTankVolume, averageFuelConsumptionFor100Km, speed)
    {
        Guards.MustBePositiveOrZero(maxPassengersCount);
        
        _maxPassengersCount = maxPassengersCount;
    }

    /// <summary>
    /// coefficient that reduce distance vehicle can drive per passenger
    /// </summary>
    private const double ReducingDistancePerPassenger = 0.06;       
    public override CarType Type => CarType.Car;

    public int PassengersCount
    {
        get => _currentPassengersCount; 
        set
        {
            if (value > _maxPassengersCount)
                throw new ArgumentOutOfRangeException($"Max count of passengers is {_maxPassengersCount}. You tried to set {value}");
            _currentPassengersCount = value;
        }
    }

}