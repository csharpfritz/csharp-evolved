using System;

public interface ITemperatureFormatter
{
    string FormatCelsius(double celsius) => celsius.ToString("0.0") + " C";
}

public class FancyFormatter : ITemperatureFormatter
{
    public string FormatCelsius(double celsius) => celsius.ToString("0.00") + " °C";
}

Console.WriteLine(((ITemperatureFormatter)new FancyFormatter()).FormatCelsius(21.34));
