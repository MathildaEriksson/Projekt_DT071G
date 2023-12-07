using System.Numerics;

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

        public void MoveLeft(int moveAmount, int gameBoardWidth) { X = Math.Max(0, X - moveAmount); }
        public void MoveRight(int moveAmount, int gameBoardWidth) { X = Math.Min(gameBoardWidth - Width, X + moveAmount); }
        public void Jump() {
               VerticalVelocity = -20; // Ett negativt värde för att hoppa uppåt
               IsOnGround = false;
        }
        public void ApplyGravity(int gravity, IEnumerable<Platform> platforms, int groundLevel)
        {
            if (!IsOnGround)
            {
                VerticalVelocity += gravity;
                Y += VerticalVelocity;

                foreach (var platform in platforms)
                {
                    if (CheckCollisionWithPlatform(platform))
                    {
                        VerticalVelocity = 0;
                        Y = platform.Y - Height; // Placera spelaren på plattformen
                        IsOnGround = true;
                        return; // Avslutar metoden om kollision med plattform upptäcks
                    }
                }

                if (Y >= groundLevel + Height)
                {
                    IsOnGround = true;
                    VerticalVelocity = 0;
                    Y = groundLevel;
                }
            }
        }


        public bool CheckCollisionWithPlatform(Platform platform)
        {
            bool isAbovePlatform = PreviousY + Height <= platform.Y;
            return X + Width > platform.X && X < platform.X + platform.Width
                   && Y + Height >= platform.Y && Y < platform.Y
                   && isAbovePlatform;
        }

        public void CheckIfOnGround(IEnumerable<Platform> platforms, int groundLevel)
        {
            bool wasOnGround = IsOnGround;
            IsOnGround = Y >= groundLevel || platforms.Any(p => CheckCollisionWithPlatform(p));

            if (IsOnGround && !wasOnGround)
            {
                VerticalVelocity = 0;
                Y = groundLevel;
            }
        }

        public void CheckCollisionWithEnemy(Enemy enemy)
        {
            // Logik för kollision med fienden
        }
    }
}
