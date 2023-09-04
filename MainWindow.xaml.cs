using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sniper_Shooter_Game_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageBrush backgroundImage = new ImageBrush();
        ImageBrush ghostSprite = new ImageBrush();

        DispatcherTimer dummyMoveTimer = new DispatcherTimer();
        DispatcherTimer showGhostTimer = new DispatcherTimer();

        int topCount = 0;
        int bottomCount = 0;

        int score;
        int miss;

        List<int> topLocation;
        List<int> bottomLocation;

        List<Rectangle> removeThis = new List<Rectangle>();
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ShowDummies(int x, int y, int skin, string tag)
        {

        }
    }
}
