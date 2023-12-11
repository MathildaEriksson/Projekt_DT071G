﻿using static Projekt.Pages.Game;

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

        public void RestartGame()
        {
            CurrentState = GameState.InGame;
            CurrentLevel = 1;
            OnStateChanged?.Invoke();
        }

        public void LoadLevel(int levelNumber)
        {
            // Ladda level för givet levelnummer, ev kan denna tas bort nu
        }
        public Level GetLevelData(int levelNumber)
        {
            if (levelNumber <= levels.Count)
            {
                return levels[levelNumber - 1];
            }
            else
            {
                // Hantera felaktigt levelnummer
                return new Level();
            }
        }

        public void NextLevel()
        {
            CurrentLevel++;
            OnStateChanged?.Invoke();
        }

        public void GameOver()
        {
            CurrentState = GameState.GameOver;
            OnStateChanged?.Invoke();
        }

        private Level CreateLevel1()
        {
            var level = new Level();

            // Lägg till plattformar
            level.Platforms.Add(new Platform(200, 520, 72, 18));
            level.Platforms.Add(new Platform(300, 450, 90, 18));

            // Lägg till fiender
            level.Enemies.Add(new Enemy(300, 380, 24, 24, 2));
            level.Enemies.Add(new Enemy(300, 180, 24, 24, 2));

            // Lägg till diamanter
            level.Diamonds.Add(new Diamond { X = 100, Y = 500 });
            level.Diamonds.Add(new Diamond { X = 200, Y = 450 });
            level.Diamonds.Add(new Diamond { X = 300, Y = 400 });

            return level;
        }

        private Level CreateLevel2()
        {
            var level = new Level();
            // Definiera plattformar, fiender och diamanter för level 2
            return level;
        }
    }

}