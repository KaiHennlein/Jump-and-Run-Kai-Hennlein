
using System.ComponentModel;

namespace Jump_and_Run
{
    public class Block : INotifyPropertyChanged
    {

        public int W { get; set; }
        public int H { get; set; }

        private int x;
        private int y;

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
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        private void OnPropertyChanged(string propertyname)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyname));
        }
        public Block(int xs, int ys)
        {
            x = xs;
            y = ys;
            W = 100;
            H = 100;

        }
    }
}

