using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
public sealed class JobHandlerAttribute : Attribute
{
    private readonly string _name;

    public JobHandlerAttribute(string name)
    {
        _name = name;
    }

    public string Name
    {
        get { return _name; }
    }
}

public interface IJobHandler
{
    void Run();
}

[JobHandler("nightly-report")]
public sealed class NightlyReportJob : IJobHandler
{
    public void Run()
    {
        Console.WriteLine("Generated the nightly report.");
    }
}

[JobHandler("rebuild-search-index")]
public sealed class SearchIndexJob : IJobHandler
{
    public void Run()
    {
        Console.WriteLine("Rebuilt the search index.");
    }
}

public static class Program
{
    public static void Main()
    {
        Dictionary<string, IJobHandler> handlers = new Dictionary<string, IJobHandler>();
        Type[] discoveredTypes = Assembly.GetExecutingAssembly().GetTypes();

        foreach (Type discoveredType in discoveredTypes)
        {
            if (!typeof(IJobHandler).IsAssignableFrom(discoveredType) || discoveredType.IsInterface || discoveredType.IsAbstract)
            {
                continue;
            }

            object[] attributes = discoveredType.GetCustomAttributes(typeof(JobHandlerAttribute), false);
            if (attributes.Length == 0)
            {
                continue;
            }

            JobHandlerAttribute attribute = (JobHandlerAttribute)attributes[0];
            handlers.Add(attribute.Name, (IJobHandler)Activator.CreateInstance(discoveredType));
        }

        handlers["nightly-report"].Run();
    }
}
