using System.Security.Principal;

namespace CSLGaming.Data.Seeder;

public class Seed
{
    public List<Category> categories = new List<Category>() { new Category() { CategoryType = "Windows" }, new Category() { CategoryType = "Mac" }, 
        new Category() { CategoryType = "PS" }, new Category() { CategoryType = "XBox" }, new Category() { CategoryType = "WII" } };

    public List<string> productNames = new List<string>()
    {
        "Doom2", "Age of Empires", "Zelda", "World of warcraft", "Dungeon siege 2", "GTA Vice City", "Warcraft3", "Tekken", "Diablo2", "Diablo4",
        "Sims2", "7 days to die", "Stronghold", "Dawn of war", "Half Life 2", "Mario Karts", "Pikmin", "Mortal Combat 4", "Need for spped 3", "Descent 2"
    };
    public List<AgeRestriction> ageRestrictions = new List<AgeRestriction>() { new AgeRestriction() { Age = 3}, new AgeRestriction() { Age = 7 }, 
        new AgeRestriction() { Age = 12 }, new AgeRestriction() { Age = 16 }, new AgeRestriction() { Age = 18 } };

    public List<Genere> generes = new List<Genere>() { new Genere() { GenereType = "Accion" }, new Genere() { GenereType = "Adventure" }, 
        new Genere() { GenereType = "RPG" }, new Genere() { GenereType = "RTS" }, new Genere() { GenereType = "Family" }, 
        new Genere() { GenereType = "Shooter" }, new Genere() { GenereType = "Survival" }, new Genere() { GenereType = "Accion" } };


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
        using (var scope = _context.Database.BeginTransaction())
        {
            try
            {
                if (!_context.Categories.Any())
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var rnd = new Random();

                        var ageRes  = ageRestrictions[rnd.Next(0, 5)];

                        categories.OrderBy(x => rnd.Next()).ToList();
                        List<Category> categoriesToAdd = [];
                        int nrCategories = rnd.Next(1, 6);
                        for (int j = 0; j < nrCategories; j++)
                        {
                            categoriesToAdd.Add( categories[j] );
                        }

                        generes.OrderBy(x => rnd.Next()).ToList();
                        List<Genere> generesToAdd = [];
                        int nrGeneres = rnd.Next(1, 6);
                        for (int k = 0; k < nrGeneres; k++)
                        {
                            generesToAdd.Add( generes[k] );
                        }

                        var product = new Product()
                        {
                            Name = productNames[i],
                            Price = rnd.Next(100, 600),
                            Rating = rnd.Next(0, 6),
                            ReleaseYear = rnd.Next(1985, 2024),
                            Description = LoremIpsumGenerator.LoremIpsum(20, 200, 1, 10, 1),
                            PictureUrl = "images/Games/" + $"{i}.png",
                            AgeRestriction = ageRes,
                            Categories = categoriesToAdd,
                            Generes = generesToAdd
                        };
                        _context.Products.Add(product);
                    }
                    _context.SaveChanges();
                    scope.Commit();
                }
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }
    }
}
