
namespace Jump_and_Run
{
    class EnemyBlock : Block
    {
        public int MovementRange { get; set; }
        public EnemyBlock(int x, int y, int r) : base(x, y)
        {
            W = 50;
            H = 50;
            MovementRange = r;
        }
        private bool Left = true;
        private int Range = 0;
        public void Enemymovements()
        {
            if (Left)
            {
                if (Range >= MovementRange)
                {
                    Left = false;
                    Range = 0;
                }
                else
                {
                    X -= 1;
                    Range++;
                }
            }
            else
            {
                if (Range >= MovementRange)
                {
                    Left = true;
                    Range = 0;
                }
                else
                {
                    X += 1;
                    Range++;
                }
            }
        }
        public bool Enemycollision(Player Player)
        {
            bool collision = false;
            if (Bottom_collision(Player) < 0 && Bottom_collision(Player) > -10)
                collision = true;

            if (Right_collision(Player) < 0 && Right_collision(Player) > -10)
                collision = true;

            if (Left_collision(Player) < 0 && Left_collision(Player) > -10)
                collision = true;

            return collision;
        }
        private int Bottom_collision(Player Player)
        {
            int collision = 0;
                int distanceleft = Player.X - (X + W);
                int distanceright = X - (Player.X + Player.Width);
                if (distanceleft < 0 && distanceleft > 0 - 100 || distanceright < 0 && distanceright > 0 - 100)
                    collision = Y - (Player.Y + Player.Height);
             
            return collision;
        }
        private int Left_collision(Player Player)
        {
            int collision = 0;
                int y_distancetop = Y - Player.Y;
                int y_distancebottom = Y - (Player.Y + Player.Width);
                if (y_distancetop < 0 && y_distancetop > 0 - 100 || y_distancebottom < 0 && y_distancebottom > 0 - 100)
                    collision = Player.X - (X + W);
                
            return collision;
        }
        private int Right_collision(Player Player)
        {
            int collision = 0;

                double y_distancetop = Y - Player.Y;
                double y_distancebottom = Y - (Player.Y + Player.Height);
                if (y_distancetop < 0 && y_distancetop > 0 - 100 || y_distancebottom < 0 && y_distancebottom > 0 - 100)
                    collision = X - (Player.X + Player.Width);
            
            return collision;
        }
    }
}
