namespace PowerLineTestTask.Utilities;

using System.Runtime.CompilerServices;

public static class Guards
{
    public static void MustBePositive(double arg, [CallerArgumentExpression("arg")] string argName = "")
    {
        if (arg <= 0) throw new ArgumentException($"{argName} must be positive. Got value {arg}");
    }
    public static void MustBePositiveOrZero(double arg, [CallerArgumentExpression("arg")] string argName = "")
    {
        if (arg < 0) throw new ArgumentException($"{argName} must be positive. Got value {arg}");
    }
}
