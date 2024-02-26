using System.Security.Principal;

namespace CSLGaming.Data;

internal class Seed
{
    public List<string> categories = new List<string>() {"Windows", "Mac", "PS", "XBox", "WII"};
    public List<string> products = new List<string>() 
    { 
        "Doom2", "Age of Empires", "Zelda", "World of warcraft", "Dungeon siege", "GTA Vice City", "Warcraft3", "Tekken", "Diablo2", "Diablo4",
        "Sims2", "7 days to die", "Stronghold", "Dawn of war", "Half Life 2", "Mario Karts", "Pikmin", "Mortal Combat 4", "Need for spped 3", "Descent 2"
    };
    public List<int> ageRestrictions = new List<int>() { 3, 7, 12, 16, 18 };
    public List<string> genere = new List<string>() { "Accion", "Adventure", "RPG", "RTS", "Family", "Shooter", "Sandbox", "Survival" };

    private readonly CSLGamingContext _context;

    public Seed(CSLGamingContext context)
    {
        _context = context;
    } 

    /// <summary>
    /// Seeds an empty database when called
    /// </summary>
    public void SeedData()
    {
        if (!_context.Categories.Any())
        {

        }
    }
}
