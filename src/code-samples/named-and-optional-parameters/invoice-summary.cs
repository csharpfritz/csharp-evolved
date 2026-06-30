using System;

public static class InvoiceFormatter
{
    public static string FormatInvoice(
        string customerName,
        decimal amount,
        string currency = "USD",
        bool includeDueDate = false)
    {
        var message = string.Format(
            "Invoice for {0}: {1:0.00} {2}",
            customerName,
            amount,
            currency);

        return includeDueDate
            ? message + " (due in 14 days)"
            : message;
    }
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine(InvoiceFormatter.FormatInvoice("A. Datum", 1200m));
        Console.WriteLine(
            InvoiceFormatter.FormatInvoice(
                "A. Datum",
                1200m,
                currency: "EUR",
                includeDueDate: true));
    }
}
