//Mathilda Eriksson, DT071G, HT23
namespace Projekt.Models
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VerticalVelocity { get; set; }
        public bool IsOnGround { get; set; }
        public int PreviousY { get; set; }
        public int Lives { get; set; } = 3;
        public int Height { get; } = 26;
        public int Width { get; } = 22;
        public int CollectedDiamonds { get; private set; } = 0;
        private const int InvulnerabilityDuration = 1000;
        private DateTime lastHitTime;

        public void MoveLeft(int moveAmount, int gameBoardWidth) { X = Math.Max(0, X - moveAmount); }
        public void MoveRight(int moveAmount, int gameBoardWidth) { X = Math.Min(gameBoardWidth - Width, X + moveAmount); }
        public void Jump() {
               VerticalVelocity = -20; // Ett negativt värde för att hoppa uppåt
               IsOnGround = false;
        }

        // Tillämpar gravitation på spelaren
        public void ApplyGravity(int gravity, int groundLevel)
        {
            if (!IsOnGround)
            {
                VerticalVelocity += gravity;
                Y += VerticalVelocity;

                // Kontrollerar om spelaren når marknivån
                if (Y >= groundLevel)
                {
                    IsOnGround = true;
                    VerticalVelocity = 0; // Nollställer vertikal hastighet
                    Y = groundLevel;
                }
            }
        }

        public void HandlePlatformCollisions(IEnumerable<Platform> platforms)
        {
            foreach (var platform in platforms)
            {
                if (CheckCollisionWithPlatform(platform))
                {
                    VerticalVelocity = 0; // Nollställer vertikal hastighet vid kollision
                    Y = platform.Y - Height; // Justerar Y-positionen så att spelaren är på plattformen
                    IsOnGround = true;
                    break; 
                }
            }
        }

        //Kontrollerar kollision mellan spelare och plattform
        public bool CheckCollisionWithPlatform(Platform platform)
        {
            bool isAbovePlatform = PreviousY + Height <= platform.Y;
            return X + Width > platform.X && X < platform.X + platform.Width
                   && Y + Height >= platform.Y && Y < platform.Y
                   && isAbovePlatform;
        }

        // Kontrollerar om spelaren är på marken
        public void CheckIfOnGround(IEnumerable<Platform> platforms, int groundLevel)
        {
            bool wasOnGround = IsOnGround;
            IsOnGround = Y >= groundLevel || platforms.Any(p => CheckCollisionWithPlatform(p));

            // Justerar Y-positionen om spelaren landar på marken från högre höjd
            if (IsOnGround && !wasOnGround)
            {
                VerticalVelocity = 0;
                Y = groundLevel;
            }
        }

        // Kontrollerar och hanterar insamling av diamanter
        public void CollectDiamonds(List<Diamond> diamonds)
        {
            for (int i = diamonds.Count - 1; i >= 0; i--)
            {
                if (IsCollidingWithDiamond(diamonds[i]))
                {
                    diamonds.RemoveAt(i); // Tar bort diamanten från listan
                    CollectedDiamonds++;
                }
            }
        }

        private bool IsCollidingWithDiamond(Diamond diamond)
        {
            int diamondWidth = 18; 
            int diamondHeight = 18; 

            return X < diamond.X + diamondWidth &&
                   X + Width > diamond.X &&
                   Y < diamond.Y + diamondHeight &&
                   Y + Height > diamond.Y;
        }

        //Kontrollerar kollision mellan spelare och fiende
        public bool CheckCollisionWithEnemy(Enemy enemy)
        {
            if (DateTime.Now - lastHitTime > TimeSpan.FromMilliseconds(InvulnerabilityDuration))
            {
                if (X < enemy.X + enemy.Width &&
                    X + Width > enemy.X &&
                    Y < enemy.Y + enemy.Height &&
                    Y + Height > enemy.Y)
                {
                    Lives--;
                    lastHitTime = DateTime.Now;
                    return true; // Kollision detekterad
                }
            }
            return false;
        }
    }
}