// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//from user settings or user context
var userRegion = "NZ";

//controller - A controller contains the flow control logic for an ASP.NET MVC application. 
// A controller determines what response to send back to a user when a user makes a browser request to an endpoint.
var orders = new List<Invoice>();
var taxCalculatorFactory = new TaxCalculatorFactory();  // factory pattern (kind of software design pattern)
var taxCalculator = taxCalculatorFactory.GetTaxCalculator(userRegion);
var taxRates = taxCalculator.CalculateGST(orders);

class TaxCalculatorFactory  // factory
{
    public ITaxCalculator GetTaxCalculator(string region) // method signature / method or function
    {
        switch (region)
        {
            case "NZ": return new NzTaxCalculator();
            case "AU": return new AuTaxCalculator();
            case "UK": return new UkTaxCalculator();
            case "US": return new UsTaxCalculator();
            default: throw new NotImplementedException();
        }
    }
}

// interface - method signature, format, contract
interface ITaxCalculator
{
    Dictionary<TaxRate, decimal> CalculateGST(List<Invoice> orders);
}

//specific region implemenation for ITaxCalculator (interface)
class NzTaxCalculator : ITaxCalculator
{
    public Dictionary<TaxRate, decimal> CalculateGST(List<Invoice> orders)
    {
        var result = new Dictionary<TaxRate, decimal>();
        // some logic to calculate NZ GST
        return result;
    }
}

class AuTaxCalculator : ITaxCalculator
{
    public Dictionary<TaxRate, decimal> CalculateGST(List<Invoice> orders)
    {
        throw new NotImplementedException();
    }
}

class UkTaxCalculator : ITaxCalculator
{
    public Dictionary<TaxRate, decimal> CalculateGST(List<Invoice> orders)
    {
        throw new NotImplementedException();
    }
}

class UsTaxCalculator : ITaxCalculator
{
    public Dictionary<TaxRate, decimal> CalculateGST(List<Invoice> orders)
    {
        throw new NotImplementedException();
    }
}

internal class TaxRate
{
}

class Invoice
{
}
