// See https://aka.ms/new-console-template for more information
var currentDirectory = Directory.GetCurrentDirectory();

var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);
File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

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
