
namespace Projekt.Models
{
    public class Level
    {
        public List<Platform> Platforms { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Diamond> Diamonds { get; set; }

        public Level()
        {
            Platforms = new List<Platform>();
            Enemies = new List<Enemy>();
            Diamonds = new List<Diamond>();
        }
    }  
}
