using PowerLineTestTask.Utilities;

namespace PowerLineTestTask;

public class FreightCar : CarBase
{
    private const double ReducingDistancePer200Kg = 0.04;
    private readonly int _maxWeight;
    private int _currentWeight;
    protected override double Efficiency => (1 - (_currentWeight / 200) * ReducingDistancePer200Kg); 

    public FreightCar(int maxWeight, double fuelTankVolume, double averageFuelConsumptionFor100Km, double speed) 
        : base(fuelTankVolume,  averageFuelConsumptionFor100Km,  speed)
    {
        Guards.MustBePositiveOrZero(maxWeight);
        
        _maxWeight = maxWeight;
    }

    public override CarType Type => CarType.FreightCar;
    public int Weight
    {
        get => _currentWeight; 
        set
        {
            if (value > _maxWeight)
                throw new ArgumentOutOfRangeException($"Max weight for this car is {_maxWeight}kg. You tried to load {value}kg");
            
            _currentWeight = value;
        }
    }
}