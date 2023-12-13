//Mathilda Eriksson, DT071G, HT23
using static Projekt.Models.Enemy;
using static Projekt.Pages.Game;

namespace Projekt.Models
{
    public class GameManager
    {
        public Action OnStateChanged;

        public GameState CurrentState { get; private set; } = GameState.StartMenu;
        public int CurrentLevel { get; private set; } = 1;

        private List<Level> levels = new List<Level>();

        public GameManager()
        {
            levels.Add(CreateLevel1());
            levels.Add(CreateLevel2());
        }
        public void StartGame()
        {
            CurrentState = GameState.InGame;
            CurrentLevel = 1;
            OnStateChanged?.Invoke();
        }

        public Level GetLevelData(int levelNumber)
        {
            if (levelNumber <= levels.Count)
            {
                return levels[levelNumber - 1];
            }
            else
            {
                // Returnera level 1 som backup
                return levels[0];
            }
        }

        public int NextLevel()
        {
            CurrentLevel++;
            OnStateChanged?.Invoke();
            return CurrentLevel;
        }

        public void GameOver()
        {
            CurrentState = GameState.GameOver;
            OnStateChanged?.Invoke();
        }
        public bool IsLastLevel()
        {
            return CurrentLevel == levels.Count;
        }
        private Level CreateLevel1()
        {
            var level = new Level();

            // Lägg till plattformar
            level.Platforms.Add(new Platform(200, 520, 72, 18));
            level.Platforms.Add(new Platform(300, 450, 90, 18));

            // Lägg till fiender
            level.Enemies.Add(new Enemy(300, 380, 24, 24, 2, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 180, 24, 24, 5, EnemyDirection.Vertical));

            // Lägg till diamanter
            level.Diamonds.Add(new Diamond { X = 100, Y = 500 });
            level.Diamonds.Add(new Diamond { X = 200, Y = 450 });
            level.Diamonds.Add(new Diamond { X = 300, Y = 400 });

            return level;
        }

        private Level CreateLevel2()
        {
            var level = new Level();
            // Lägg till plattformar
            level.Platforms.Add(new Platform(200, 520, 72, 18));

            // Lägg till fiender
            level.Enemies.Add(new Enemy(300, 380, 24, 24, 2, EnemyDirection.Horizontal));

            // Lägg till diamanter
            level.Diamonds.Add(new Diamond { X = 100, Y = 500 });
            level.Diamonds.Add(new Diamond { X = 200, Y = 450 });

            return level;
        }
    }

}
