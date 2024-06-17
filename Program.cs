using System.Globalization;
using ExercicioResolvidoLinq.Entities;

const string filePath = "./products.csv";
List<Product> products = [];

using (StreamReader sr = File.OpenText(filePath))
{
    while (!sr.EndOfStream)
    {
        string[] part = (sr.ReadLine() ?? "").Split(',');
        string name = part[0];
        double price = double.Parse(part[1], CultureInfo.InvariantCulture);

        products.Add(new Product { Name = name, Price = price });
    }
}

var avg = products.Select(x => x.Price).DefaultIfEmpty(0).Average();
Console.WriteLine($"Average price = {avg:F2}");

var names = products.Where(x => x.Price < avg).OrderByDescending(x => x.Name).Select(x => x.Name);

foreach (string name in names)
    Console.WriteLine(name);
