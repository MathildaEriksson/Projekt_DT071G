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
            levels.Add(CreateLevel3());
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
            level.Platforms.Add(new Platform(100, 540, 72, 18));
            level.Platforms.Add(new Platform(200, 480, 90, 18));
            level.Platforms.Add(new Platform(300, 420, 90, 18));
            level.Platforms.Add(new Platform(400, 375, 54, 18));
            level.Platforms.Add(new Platform(500, 305, 90, 18));
            level.Platforms.Add(new Platform(400, 245, 90, 18));
            level.Platforms.Add(new Platform(650, 245, 72, 18));
            level.Platforms.Add(new Platform(720, 180, 54, 18));
            level.Platforms.Add(new Platform(300, 195, 90, 18));
            level.Platforms.Add(new Platform(200, 135, 36, 18));

            // Lägg till fiender
            level.Enemies.Add(new Enemy(300, 350, 24, 24, 2, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(175, 180, 24, 24, 3, EnemyDirection.Vertical));
            level.Enemies.Add(new Enemy(610, 400, 24, 24, 5, EnemyDirection.Vertical));

            // Lägg till diamanter
            level.Diamonds.Add(new Diamond { X = 250, Y = 460 });
            level.Diamonds.Add(new Diamond { X = 720, Y = 160 });
            level.Diamonds.Add(new Diamond { X = 200, Y = 110 });

            return level;
        }

        private Level CreateLevel2()
        {
            var level = new Level();

            // Lägg till plattformar
            level.Platforms.Add(new Platform(700, 540, 54, 18));
            level.Platforms.Add(new Platform(600, 480, 72, 18));
            level.Platforms.Add(new Platform(550, 420, 36, 18));
            level.Platforms.Add(new Platform(380, 375, 108, 18));
            level.Platforms.Add(new Platform(500, 305, 90, 18));
            level.Platforms.Add(new Platform(300, 305, 90, 18));
            level.Platforms.Add(new Platform(650, 245, 90, 18));
            level.Platforms.Add(new Platform(720, 180, 72, 18));
            level.Platforms.Add(new Platform(400, 220, 54, 18));
            level.Platforms.Add(new Platform(300, 190, 36, 18));
            level.Platforms.Add(new Platform(200, 135, 36, 18));

            // Lägg till fiender
            level.Enemies.Add(new Enemy(300, 500, 24, 24, 2, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 400, 24, 24, 3, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 300, 24, 24, 4, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 200, 24, 24, 5, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 100, 24, 24, 6, EnemyDirection.Horizontal));

            // Lägg till diamanter
            level.Diamonds.Add(new Diamond { X = 260, Y = 460 });
            level.Diamonds.Add(new Diamond { X = 720, Y = 100 });
            level.Diamonds.Add(new Diamond { X = 100, Y = 200 });
            return level;
        }

        private Level CreateLevel3()
        {
            var level = new Level();

            // Lägg till plattformar
            level.Platforms.Add(new Platform(200, 540, 54, 18));
            level.Platforms.Add(new Platform(300, 480, 72, 18));
            level.Platforms.Add(new Platform(450, 420, 36, 18));
            level.Platforms.Add(new Platform(380, 375, 36, 18));
            level.Platforms.Add(new Platform(500, 305, 90, 18));
            level.Platforms.Add(new Platform(300, 305, 90, 18));
            level.Platforms.Add(new Platform(650, 245, 90, 18));
            level.Platforms.Add(new Platform(720, 180, 72, 18));
            level.Platforms.Add(new Platform(400, 220, 54, 18));

            // Lägg till fiender
            level.Enemies.Add(new Enemy(300, 500, 24, 24, 2, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 400, 24, 24, 3, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 300, 24, 24, 4, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 200, 24, 24, 5, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(300, 100, 24, 24, 6, EnemyDirection.Horizontal));
            level.Enemies.Add(new Enemy(175, 180, 24, 24, 2, EnemyDirection.Vertical));
            level.Enemies.Add(new Enemy(300, 400, 24, 24, 3, EnemyDirection.Vertical));
            level.Enemies.Add(new Enemy(450, 180, 24, 24, 4, EnemyDirection.Vertical));
            level.Enemies.Add(new Enemy(670, 400, 24, 24, 5, EnemyDirection.Vertical));

            // Lägg till diamanter
            level.Diamonds.Add(new Diamond { X = 300, Y = 275 });
            level.Diamonds.Add(new Diamond { X = 200, Y = 325 });
            level.Diamonds.Add(new Diamond { X = 400, Y = 300 });
            level.Diamonds.Add(new Diamond { X = 500, Y = 275 });
            level.Diamonds.Add(new Diamond { X = 600, Y = 325 });
            return level;
        }
    }

}
