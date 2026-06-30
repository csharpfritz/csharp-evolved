using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

public sealed class UserSettings
{
    [Description("The time zone used when formatting dashboard timestamps.")]
    public string TimeZone { get; set; }

    [Description("When true, summaries are grouped into one daily email instead of immediate notifications.")]
    public bool DigestEmails { get; set; }
}

public static class Program
{
    public static void Main()
    {
        List<string> helpLines = new List<string>();
        PropertyInfo[] properties = typeof(UserSettings).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            object[] attributes = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                continue;
            }

            DescriptionAttribute description = (DescriptionAttribute)attributes[0];
            helpLines.Add(property.Name + ": " + description.Description);
        }

        Console.WriteLine(string.Join(Environment.NewLine, helpLines.ToArray()));
    }
}
