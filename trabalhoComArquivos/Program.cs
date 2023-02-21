using System.Globalization;


string sourcePath = @"C:\Source\Source.csv";

string endPath = @"C:\Source\Out\";

string fileName = @"\Summary.csv";

string fullPathNameSummary = endPath + fileName;

try
{
    string[] lines = File.ReadAllLines(sourcePath);

    Directory.CreateDirectory(endPath);

    File.Create(fullPathNameSummary).Dispose();

    using (StreamWriter sw = File.AppendText(fullPathNameSummary))
    {
        foreach (string line in lines)
        {
            string[] words = line.Split(',');
            string product = words[0];
            double price = double.Parse(words[1], CultureInfo.InvariantCulture);
            int quantity = int.Parse(words[2]);
            string result = product + "," + (price * quantity).ToString("F2", CultureInfo.InvariantCulture);
            sw.WriteLine(result);
        }
    }
}
catch (IOException e)
{
    Console.WriteLine("Um erro ocorreu: ");
    Console.WriteLine(e.Message);
}
