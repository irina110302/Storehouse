using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApp.Models.Entities
{
    public class Product
    {
        public static string GenerateSKU(Product product)
        {
            char delimiter = '-';

            List<string> targets = new()
            {
                product.Name,
                product.Manufacturer,
                product.Color,
            };

            targets = targets.Select(str => GetFirstCharacters(str)).ToList();
            targets.Add(product.ProductionDate.Date.ToString($"yy{delimiter}MM{delimiter}dd"));

            return string.Join(delimiter, targets);
        }

        private static string GetFirstCharacters(string str, int count = 3)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string blackList = "!,()_-'\"[]{}&?/\\|$;:.@#№*^+=`~";
            char fillSymbol = '?';

            foreach (char c in blackList)
            {
                str = str.Replace(c.ToString(), "");
            }

            string[] words = str
                .ToUpper()
                .Split(' ')
                .Where(str => !str.IsNullOrEmpty())
                .ToArray();

            if (words.Length > count)
            {
                for (int i = 0; i < count; ++i)
                {
                    stringBuilder.Append(words[i].FirstOrDefault(fillSymbol));
                }
            }
            else if (words.Length > 0)
            {
                string firstWord = words[0];

                for (int i = 0; i < count; ++i)
                {
                    if (i < firstWord.Length)
                    {
                        stringBuilder.Append(firstWord[i]);
                    }
                    else
                    {
                        stringBuilder.Append(fillSymbol);
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; ++i)
                {
                    stringBuilder.Append(fillSymbol);
                }
            }

            return stringBuilder.ToString();
        }

        public string SKU { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public DateTime ProductionDate { get; set; }
        
        public Product(string sku)
        {

        }

        public Product(string name, string manufacturer, string color, DateTime productionDate)
        {
            Name = name;
            Manufacturer = manufacturer;
            Color = color;
            ProductionDate = productionDate;
            SKU = GenerateSKU(this);
        }
    }
}
