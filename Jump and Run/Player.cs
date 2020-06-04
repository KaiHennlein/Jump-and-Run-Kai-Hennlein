using System.ComponentModel;

namespace Jump_and_Run
{
    public class Player : INotifyPropertyChanged
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Jumpstate { get; set; }
        public int Jumptime { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private int x;
        private int y;
        private int health;

        public int X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                OnPropertyChanged("Health");
            }
        } 
        private void OnPropertyChanged(string propertyname)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyname));
        }
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        public Player()
        {
            Height = 50;
            Width = 50;
            Health = 3;
            Jumptime = 0;
        }
        //Player methods
        public void Resetposition()
        {
            X = 50;
            Y = 650;
        }
        public void Resethealth()
        {
            Health = 3;
        }
        public void Receivedamage()
        {
            Health--;
            System.Console.WriteLine(Health);
        }
        //Move methods seperated to allow movent in differnt directs at the same time
        public void Moveright(int d)
        {
            X += d;
        }
        public void Moveleft(int d)
        {
            X -= d;
        }
        public void Movedown(int d)
        {
            Y += d;
        }
        public void Moveup(int d)
        {
            Y -= d;
        }
    }
}
