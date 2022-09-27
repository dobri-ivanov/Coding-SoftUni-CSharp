namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        private static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new SortedDictionary<string, List<FileInfo>>();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!extensionsFiles.ContainsKey(fileInfo.Extension))
                {
                    extensionsFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }
                extensionsFiles[fileInfo.Extension].Add(fileInfo);
            }

            var orderedExtensionsFiles = extensionsFiles.OrderByDescending(f => f.Value.Count);
            StringBuilder sb = new StringBuilder();

            foreach (var extension in orderedExtensionsFiles)
            {
                sb.AppendLine(extension.Key);

                var orderedFiles = extension.Value.OrderByDescending(f => f.Length);

                foreach (var file in orderedFiles)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(desktopPath, textContent);
        }
    }
}