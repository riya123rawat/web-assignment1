namespace Temperaturechecker.Models;

public static class TemperatureChecker
{
    public static string CheckTemperature(float temperature, string scale)
    {
        if (scale == "Fahrenheit")
        {
            temperature = (temperature - 32) * 5 / 9; // Convert to Celsius
        }

        if (temperature >= 38.0f)
        {
            return "You have a fever.";
        }
        else if (temperature < 35.0f)
        {
            return "You have hypothermia.";
        }
        else
        {
            return "Your temperature is normal.";
        }
    }
}

