using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Files
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var regex = new Regex(@"([^\\]+)\\(?:[^\\]+\\)*([^\\]+\.[^\\.]+)\;(\d+)");
        var files = new List<File>();
        for (int i = 0; i < n; i++)
        {
            var path = Console.ReadLine();
            if (regex.IsMatch(path))
            {
                var fileInfo = regex.Match(path);
                var currentFileRoot = fileInfo.Groups[1].Value;
                var currentFileName = fileInfo.Groups[2].Value;
                var currentExtension = currentFileName.Split('.').Last();
                var currentSize = long.Parse(fileInfo.Groups[3].Value);
                var currentFile = new File()
                {
                    Root = currentFileRoot,
                    FileName = currentFileName,
                    Extension = currentExtension,
                    Size = currentSize
                };
                for (int j = 0; j < files.Count; j++)
                {
                    var currentInList = files[j];
                    if (currentInList.Root == currentFile.Root && currentInList.FileName == currentFile.FileName)
                        files.RemoveAt(j);
                }
                files.Add(currentFile);
            }
        }
        var searchFor = Console.ReadLine().Split().ToArray();
        bool filesAreFound = false;
        foreach (var file in files.OrderByDescending(file => file.Size).ThenBy(file => file.FileName))
        {
            if (file.Root == searchFor[2] && file.Extension == searchFor[0])
            {
                Console.WriteLine($"{file.FileName} - {file.Size} KB");
                filesAreFound = true;
            }
        }
        if (filesAreFound == false)
            Console.WriteLine("No");
    }
}
class File
{
    public string Root { get; set; }

    public string FileName { get; set; }

    public string Extension { get; set; }

    public long Size { get; set; }
}