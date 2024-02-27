using System.Security.Principal;

namespace CSLGaming.Data.Seeder;

public class Seed
{
    public List<string> categoryOptions = new List<string>() { "Windows", "Mac", "PS", "XBox", "WII" };
    public List<string> products = new List<string>()
    {
        "Doom2", "Age of Empires", "Zelda", "World of warcraft", "Dungeon siege 2", "GTA Vice City", "Warcraft3", "Tekken", "Diablo2", "Diablo4",
        "Sims2", "7 days to die", "Stronghold", "Dawn of war", "Half Life 2", "Mario Karts", "Pikmin", "Mortal Combat 4", "Need for spped 3", "Descent 2"
    };
    public List<int> ageRestrictions = new List<int>() { 3, 7, 12, 16, 18 };
    public List<string> genereOptions = new List<string>() { "Accion", "Adventure", "RPG", "RTS", "Family", "Shooter", "Sandbox", "Survival" };


    private readonly CSLGamingContext _context;

    public Seed(CSLGamingContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Seeds an empty database when called
    /// </summary>
    public void SeedDataContext()
    {
        if (!_context.Categories.Any())
        {
            for (int i = 0; i < 20; i++)
            {
                var rnd = new Random();

                var ageRes = new AgeRestriction() { Age = ageRestrictions[rnd.Next(0, 5)]};

                var shuffledCategories = categoryOptions.OrderBy(x => rnd.Next()).ToList();
                int nrCategories = rnd.Next(5);
                List<Category> categories = new List<Category>();
                for (int j = 0; j < nrCategories; j++)
                {
                    categories.Add(new Category() { CategoryType = shuffledCategories[j] });
                }

                var shuffledGeneres = genereOptions.OrderBy(x => rnd.Next()).ToList();
                int nrGeneres = rnd.Next(5);
                List<Genere> generes = new List<Genere>();
                for (int k = 0; k < nrGeneres; k++)
                {
                    generes.Add(new Genere() { GenereType = shuffledGeneres[k] });
                }

                var product = new Product()
                {
                    Name = products[i],
                    Price = rnd.Next(100, 600),
                    Rating = rnd.Next(0, 6),
                    ReleaseYear = rnd.Next(1985, 2024),
                    Description = LoremIpsumGenerator.LoremIpsum(20, 200, 1, 10, 1),
                    PictureUrl = "images/Games" + $"{i}.png",
                    AgeRestriction = ageRes,
                    Categories = categories,
                    Generes = generes
                };
                _context.Products.Add(product);
            }
            _context.SaveChanges();
        }
    }
}
