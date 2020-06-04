using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Jump_and_Run
{
    class Controller
    {
        public Level Level { get; set; }
        public Player Player { get; set; }

        public Controller()
        {
            Level = new Level();
            Player = new Player();
        }
        public void Startgame()
        {
            Level.Currentlevel = 0;
            Level.Changelevel();
            Player.Resetposition();
            Player.Health = 3;
        }
        public void Timer()
        {
            Move();
            Enemycollisionctrl();
            Trapcollision();
            Finishcollision();
            Checkhealth();
            Enemymovement();
        }
        public void Move() //Playermovement
        {
            int speed = 5;
            int width = 1600;
            int height = 900;
            //
            if (!Bottom_collision(Level.Blocklist)) //Gravity
                Player.Movedown(10);

            //
            if (Player.Y == height) //bottom border
            {
                Player.Resetposition();
                Player.Receivedamage();
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if(Player.X + Player.Width == width) //right border
                    Player.Moveright(0);

                else if(!Right_collision(Level.Blocklist))
                    Player.Moveright(speed);
            }
            //
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (Player.X == 0) //left border
                    Player.Moveleft(0);

                else if(!Left_collision(Level.Blocklist))
                    Player.Moveleft(speed);
            }
            //
            if (Keyboard.IsKeyDown(Key.Space) && !Player.Jumpstate && Bottom_collision(Level.Blocklist))
            {
                Player.Jumpstate = true;
                Player.Jumptime = 0;
            }
            //
            if (Player.Jumpstate)
            {
                if (Player.Y > 0)
                {
                    Player.Jumptime++;
                    Player.Moveup(30);
                    if (Player.Jumptime > 12)
                        Player.Jumpstate = false;
                }
                else //Collision with the top border
                {
                    Player.Moveup(0);
                    Player.Jumpstate = false;
                }
            }
        }
        //
        private void Enemycollisionctrl() //Controlling the collision with enemyblocks
        {
            foreach(EnemyBlock b in Level.Enemylist)
            {
                if (b.Enemycollision(Player))
                {
                    Player.Resetposition();
                    Player.Receivedamage();
                }
                
            }
        }
        //
        private void Finishcollision() //Collision with finish
        {
            if (Bottom_collision(Level.Finish) || Right_collision(Level.Finish) || Left_collision(Level.Finish))
            {
                Level.Currentlevel++;
                Level.Changelevel();
                Player.Resetposition();
                Player.Resethealth();
            }
        } 
        //
        private void Trapcollision() //Collision with traps
        {
            if (Bottom_collision(Level.Traplist) || Right_collision(Level.Traplist) || Left_collision(Level.Traplist))
            {
                Player.Resetposition();
                Player.Receivedamage();
            }
        }
        //
        private void Checkhealth()
        {
            if (Player.Health <= 0)
            {
                Level.Currentlevel = 0;
                Level.Changelevel();
                Player.Health = 3;
            }
        }
        //
        private void Enemymovement()
        {
            foreach(EnemyBlock b in Level.Enemylist)
            {
                b.Enemymovements();
            }
        }
        //
        private bool Bottom_collision(ObservableCollection<Block> O) //left side of the Player and the right side of a Block
        {
            bool collision = false;
            foreach (Block b in O)
            {
                int distanceleft = Player.X - (b.X + b.W);
                int distanceright = b.X - (Player.X + Player.Width);
                if (distanceleft < 0 && distanceleft > 0 - 100 || distanceright < 0 && distanceright > 0 - 100)
                {
                    int Bottomdistance = b.Y - (Player.Y + Player.Height);
                    if (Bottomdistance == 0)
                    {
                        collision = true;
                    }
                }
            }
            return collision;
        }
        //
        private bool Left_collision(ObservableCollection<Block> O) //left side of the Player and the right side of a Block
        {
            bool collision = false;
            foreach (Block b in O)
            {
                int y_distancetop = b.Y - Player.Y;
                int y_distancebottom = b.Y - (Player.Y + Player.Width);
                if (y_distancetop < 0 && y_distancetop > 0 - 100 || y_distancebottom < 0 && y_distancebottom > 0 - 100)
                {
                    int distanceleft = Player.X - (b.X + b.W);
                    if (distanceleft == 0)
                    {
                        collision = true;
                    }
                }
            }
            return collision;
        }
        //
        private bool Right_collision(ObservableCollection<Block> O) //right side of the Player and right side of a Block
        {
            bool collision = false;
            foreach (Block b in O)
            {
                double y_distancetop = b.Y - Player.Y;
                double y_distancebottom = b.Y - (Player.Y + Player.Height);
                if (y_distancetop < 0 && y_distancetop > 0 - 100 || y_distancebottom < 0 && y_distancebottom > 0 - 100)
                {
                    int distanceright = b.X - (Player.X + Player.Width);
                    if(distanceright == 0)
                    {
                        collision = true;
                    }
                }
            }
            return collision;
        }
    }
}
