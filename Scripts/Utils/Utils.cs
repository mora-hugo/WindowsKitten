using System;

namespace WindowsKitten.Scripts.Utils;

public class Utils
{
    public static float GetRandomFloatInRange(float minimum, float maximum)
    { 
        Random random = new Random();
        return (float)random.NextDouble() * (maximum - minimum) + minimum;
    }

}