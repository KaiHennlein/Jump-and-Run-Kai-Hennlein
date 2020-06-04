using System.Collections.ObjectModel;

namespace Jump_and_Run
{
    class Level
    {
        public ObservableCollection<Block> Blocklist { get; set; }
        public ObservableCollection<Block> Enemylist { get; set; }
        public ObservableCollection<Block> Traplist { get; set; }
        public ObservableCollection<Block> Finish { get; set; }
        public int Currentlevel { get; set; }
        public Level()
        {
            Blocklist = new ObservableCollection<Block>();
            Enemylist = new ObservableCollection<Block>();
            Traplist = new ObservableCollection<Block>();
            Finish = new ObservableCollection<Block>();
        }
        public void Changelevel()
        {
            Clearlevel();
            switch (Currentlevel)
            {
                case 0: Tutorial(); break;
                case 1: Level1(); break;
                case 2: Level2(); break;
                case 3: Level3(); break;
                case 4: Level4(); break;
            }
        }
        private void Clearlevel()
        {
            Blocklist.Clear();
            Enemylist.Clear();
            Traplist.Clear();
            Finish.Clear();
        }
        private void Tutorial()
        {
            for (int i = 0; i < 4; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            //
            for (int i = 12; i < 16; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            //
            Blocklist.Add(new LevelBlock(300, 500));
            Blocklist.Add(new LevelBlock(400, 500));
            Blocklist.Add(new LevelBlock(500, 500));
            //
            Blocklist.Add(new LevelBlock(500, 300));
            Blocklist.Add(new LevelBlock(600, 300));
            Blocklist.Add(new LevelBlock(700, 300));
            //
            Blocklist.Add(new LevelBlock(700, 100));
            Blocklist.Add(new LevelBlock(800, 100));
            Blocklist.Add(new LevelBlock(900, 100));
            //
            Blocklist.Add(new LevelBlock(900, 300));
            Blocklist.Add(new LevelBlock(1000, 300));
            Blocklist.Add(new LevelBlock(1100, 300));
            //
            Blocklist.Add(new LevelBlock(1100, 500));
            Blocklist.Add(new LevelBlock(1200, 500));
            Blocklist.Add(new LevelBlock(1300, 500));
            //
            Finish.Add(new FinishBlock(1550, 650));
        }
        private void Level1()
        {
            for (int i = 0; i < 16; i++)
                Blocklist.Add(new Block(i * 100, 700));
            //
            Blocklist.Add(new LevelBlock(200, 600));
            Traplist.Add(new TrapBlock(300, 690));
            Traplist.Add(new TrapBlock(350, 690));
            Traplist.Add(new TrapBlock(400, 690));
            Traplist.Add(new TrapBlock(450, 690));
            Blocklist.Add(new LevelBlock(500, 600));
            //
            Traplist.Add(new TrapBlock(700, 690));
            Traplist.Add(new TrapBlock(750, 690));
            //
            Blocklist.Add(new LevelBlock(900, 600));
            Traplist.Add(new TrapBlock(1000, 690));
            Traplist.Add(new TrapBlock(1050, 690));
            Traplist.Add(new TrapBlock(1100, 690));
            Traplist.Add(new TrapBlock(1150, 690));
            Blocklist.Add(new LevelBlock(1200, 600));
            //
            Finish.Add(new FinishBlock(1550, 650));
        }
        private void Level2()
        {
            for (int i = 0; i < 4; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            //
            for (int i = 3; i < 7; i++)
                Blocklist.Add(new LevelBlock(i * 100, 500));
            Enemylist.Add(new EnemyBlock(650, 450, 250));
            //
            for (int i = 7; i < 11; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            Enemylist.Add(new EnemyBlock(1050, 650, 350));
            //
            for (int i = 10; i < 16; i++)
                Blocklist.Add(new LevelBlock(i * 100, 500));
            Enemylist.Add(new EnemyBlock(1450, 450, 450));
            //
            Finish.Add(new FinishBlock(1550, 450));   
        }
        private void Level3()
        {
            for (int i = 0; i < 11; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            //
            Traplist.Add(new TrapBlock(150, 690));
            for (int i = 8; i < 20; i++)
                Traplist.Add(new TrapBlock(i * 50, 690));
            //
            Blocklist.Add(new LevelBlock(200, 600));
            Blocklist.Add(new LevelBlock(300, 600));
            Blocklist.Add(new LevelBlock(200, 500));
            Blocklist.Add(new LevelBlock(300, 500));
            Blocklist.Add(new LevelBlock(300, 400));
            //
            Blocklist.Add(new LevelBlock(600, 400));
            Blocklist.Add(new LevelBlock(700, 400));
            Enemylist.Add(new EnemyBlock(750, 350, 150));
            //
            Blocklist.Add(new LevelBlock(1000, 500));
            Blocklist.Add(new LevelBlock(1000, 600));
            //
            Blocklist.Add(new LevelBlock(1200, 500));
            //
            Blocklist.Add(new LevelBlock(1400, 500));
            //
            Blocklist.Add(new LevelBlock(1500, 300));
            //
            Finish.Add(new FinishBlock(1550, 250));

        }
        private void Level4()
        {
            for (int i = 0; i < 3; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            for (int i = 0; i < 3; i++)
                Blocklist.Add(new LevelBlock(i * 100, 500));
            for (int i = 0; i < 3; i++)
                Blocklist.Add(new LevelBlock(i * 100, 300));
            for (int i = 0; i < 3; i++)
                Blocklist.Add(new LevelBlock(i * 100, 100));
            Blocklist.Add(new LevelBlock(200, 600));
            Blocklist.Add(new LevelBlock(200, 400));
            Blocklist.Add(new LevelBlock(200, 200));
            //
            for (int i = 0; i < 4; i++)
                Blocklist.Add(new LevelBlock(600, 100 * i));
            for (int i = 3; i < 6; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            for (int i = 7; i < 12; i++)
                Blocklist.Add(new LevelBlock(i * 100, 700));
            Blocklist.Add(new LevelBlock(1100, 600));
            //
            for (int i = 0; i < 6; i++)
                Blocklist.Add(new LevelBlock(1500, 100 * i));
            for (int i = 11; i < 15; i++)
                Blocklist.Add(new LevelBlock(i * 100, 500));
            for (int i = 7; i < 10; i++)
                Blocklist.Add(new LevelBlock(i * 100, 300));
            for (int i = 11; i < 15; i++)
                Blocklist.Add(new LevelBlock(i * 100, 100));
            //
            Traplist.Add(new TrapBlock(1050, 690));
            Traplist.Add(new TrapBlock(1450, 490));
            //
            Enemylist.Add(new EnemyBlock(150, 450, 150));
            Enemylist.Add(new EnemyBlock(150, 250, 150));
            Enemylist.Add(new EnemyBlock(550, 650, 250));
            Enemylist.Add(new EnemyBlock(1000, 650, 300));
            Enemylist.Add(new EnemyBlock(1400, 450, 300));
            Enemylist.Add(new EnemyBlock(950, 250, 250));
            //
            Finish.Add(new FinishBlock(1450, 50));
            //
            Currentlevel = 0;
            Changelevel();
        }
    }
}