namespace Projekt.Models
{
    public class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }

        public Enemy(int x, int y, int width, int height, int speed)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
        }

        public void Move(GameBoard gameBoard)
        {
            X += Speed;

            // Vänd riktning vid kant av spelbrädet eller kollision med vägg etc.
            if (X < 0 || X + Width > gameBoard.Width)
            {
                Speed = -Speed;
            }
        }
    }

}
