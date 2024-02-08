namespace ScooterPortal.ApiService.Endpoints.Customers.ExportToCsv;

public class ExportToCsvEndpoint : EndpointWithoutRequest
{
    public DatabaseContext DbContext { get; set; }
    
    public override void Configure()
    {
        Post("customers/export-to-csv");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var customers = DbContext.Customers.ToList();

        var lines = new List<string> {"Id;Imię;Nazwisko"};
        customers.ForEach(c => lines.Add($"{c.Id};{c.FirstName};{c.LastName}"));

        var tempFile = Path.GetTempFileName();
        Directory.CreateDirectory(Path.GetFileNameWithoutExtension(tempFile));
        var tempFilePath = Path.Combine(Path.GetFileNameWithoutExtension(tempFile), "customers.csv");

        try
        {
            File.WriteAllLines(tempFilePath, lines);
        }
        catch (Exception)
        {
            ThrowError("Error while writing to file");
        }

        return SendFileAsync(new(tempFilePath), "text/csv");
    }
}