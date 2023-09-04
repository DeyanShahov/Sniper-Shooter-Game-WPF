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

            MyCanvas.Focus();
            this.Cursor = Cursors.None;

            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/background.png"));
            MyCanvas.Background = backgroundImage;

            scopeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/sniper-aim.png"));
            scopeImage.IsHitTestVisible = false;

            ghostSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/ghost.png"));

            dummyMoveTimer.Tick += DummyMoveTick;
            dummyMoveTimer.Interval = TimeSpan.FromMilliseconds(random.Next(800, 2000));
            dummyMoveTimer.Start();

            showGhostTimer.Tick += GhostAnimation;
            showGhostTimer.Interval = TimeSpan.FromMilliseconds(20);
            showGhostTimer.Start();

            topLocation = new List<int> { 270, 540, 23, 540, 270, 23};
            bottomLocation = new List<int> { 128, 678, 138, 678, 128, 128 };
        }

        private void GhostAnimation(object? sender, EventArgs e)
        {
  
        }

        private void DummyMoveTick(object? sender, EventArgs e)
        {

        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            double pX = position.X;
            double pY = position.Y;

            Canvas.SetLeft(scopeImage, pX - scopeImage.Width / 2);
            Canvas.SetTop(scopeImage, pY - scopeImage.Height / 2);
        }

        private void ShowDummies(int x, int y, int skin, string tag)
        {

        }
    }
}
