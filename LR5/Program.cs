
struct Toy
{
    public int Article;       
    public string Name;    
    public int Price;      
    public int MinAge;        
    public int MaxAge;       

    public Toy(int article, string name, int price, int ageMin, int ageMax)
    {
        if (article < 100 || article > 999)
            throw new ArgumentException("Артикул має бути тризначним числом.");

        Article = article;
        Name = name;
        Price = price;
        MinAge = ageMin;
        MaxAge = ageMax;
    }

    public string GetInfo()
    {
        return $"Артикул: {Article}, Назва: {Name}, Ціна: {Price} грн, Вік: {MinAge}-{MaxAge} років";
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding =System.Text.Encoding.UTF8;  
        List<Toy> toys = new List<Toy>();

        Console.Write("Введіть кількість іграшок: ");
        int numberOfToys = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfToys; i++)
        {
            Console.WriteLine($"Введіть дані для іграшки {i + 1}:");

            Console.Write("Артикул (тризначне число): ");
            int article = int.Parse(Console.ReadLine());

            Console.Write("Назва: ");
            string name = Console.ReadLine();

            Console.Write("Ціна: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Мінімальний вік: ");
            int ageMin = int.Parse(Console.ReadLine());

            Console.Write("Максимальний вік: ");
            int ageMax = int.Parse(Console.ReadLine());

            Toy toy = new Toy(article, name, price, ageMin, ageMax);
            toys.Add(toy);
        }

        Console.WriteLine("\nСписок іграшок:");
        foreach (var toy in toys)
        {
            Console.WriteLine(toy.GetInfo());
        }

        Console.Write("\nВведіть назву іграшки для пошуку найдешевшої: ");
        string searchName = Console.ReadLine();
        var cheapestToy = toys.Where(t => t.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                              .OrderBy(t => t.Price)
                              .FirstOrDefault();
        if (cheapestToy.Name != null)
        {
            Console.WriteLine("Найдешевша іграшка з такою назвою:");
            Console.WriteLine(cheapestToy.GetInfo());
        }
        else
        {
            Console.WriteLine("Іграшку з такою назвою не знайдено.");
        }
        Console.Write("\nВведіть вік дитини для пошуку відповідних іграшок: ");
        int childAge = int.Parse(Console.ReadLine());
        var suitableToys = toys.Where(t => t.MinAge <= childAge && t.MaxAge >= childAge).ToList();

        if (suitableToys.Any())
        {
            Console.WriteLine("\nІграшки, які підходять для цього віку:");
            foreach (var toy in suitableToys)
            {
                Console.WriteLine(toy.GetInfo());
            }
        }
        else
        {
            Console.WriteLine("Іграшок, які підходять для цього віку, не знайдено.");
        }
    }
}
