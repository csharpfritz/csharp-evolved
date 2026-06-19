using System;

public interface ITemperatureFormatter
{
    string FormatCelsius(double celsius) => celsius.ToString("0.0") + " C";
}

public class BasicFormatter : ITemperatureFormatter
{
}

Console.WriteLine(((ITemperatureFormatter)new BasicFormatter()).FormatCelsius(21.34));
