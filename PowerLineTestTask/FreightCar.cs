using PowerLineTestTask.Utilities;

namespace PowerLineTestTask;

public class FreightCar : CarBase
{
    private readonly int _maxWeight;
    private int _currentWeight;
    protected override double Efficiency => (1 - (_currentWeight / 200) * ReducingDistancePer200Kg); 

    public FreightCar(int maxWeight, double fuelTankVolume, double averageFuelConsumptionFor100Km, double speed) 
        : base(fuelTankVolume,  averageFuelConsumptionFor100Km,  speed)
    {
        Guards.MustBePositiveOrZero(maxWeight);
        
        _maxWeight = maxWeight;
    }

    /// <summary>
    /// coefficient that reduce distance vehicle can drive per 200 kg of weights
    /// </summary>
    private const double ReducingDistancePer200Kg = 0.04;
    public override CarType Type => CarType.FreightCar;
    public int Weight
    {
        get => _currentWeight; 
        set
        {
            if (value > _maxWeight)
                throw new ArgumentOutOfRangeException($"Max weight is {_maxWeight}kg. You tried to load {value}kg");
            _currentWeight = value;
        }
    }
}