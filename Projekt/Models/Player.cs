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
    }
}
