// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();

var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);
File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);

        // The file name will contain full path so only check the end
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {
        // Read contents
        string salesJson = File.ReadAllText(file);

        // Parse as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData>(salesJson);

        // Add to total.
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

record SalesData(double Total);
