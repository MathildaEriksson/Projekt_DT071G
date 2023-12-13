//Mathilda Eriksson, DT071G, HT23
namespace Projekt.Models
{
    public class Enemy
    {
        public enum EnemyDirection
        {
            Horizontal,
            Vertical
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public EnemyDirection Direction { get; set; }

        public Enemy(int x, int y, int width, int height, int speed, EnemyDirection direction)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Direction = direction;
        }

        public void Move(GameBoard gameBoard)
        {
            if (Direction == EnemyDirection.Horizontal)
            {
                X += Speed;

                // Vänd riktning vid kant av spelbrädet
                if (X < 0 || X + Width > gameBoard.Width)
                {
                    Speed = -Speed;
                }
            }
            else if (Direction == EnemyDirection.Vertical)
            {
                Y += Speed;

                // Vänd riktning vid kant av spelbrädet
                if (Y < 0 || Y + Height > gameBoard.Height)
                {
                    Speed = -Speed;
                }
            }
        }
    }

}
