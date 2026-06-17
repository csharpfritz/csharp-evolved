string DescribeTemperature(int celsius) => celsius switch
{
    < 0 => "freezing",
    >= 0 and <= 10 => "cold",
    > 10 and < 25 => "mild",
    _ => "warm"
};
