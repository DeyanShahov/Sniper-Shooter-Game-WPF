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
            bottomLocation = new List<int> { 139, 670, 420, 670, 139, 420 };
        }

        private void GhostAnimation(object? sender, EventArgs e)
        {
  
        }

        private void DummyMoveTick(object? sender, EventArgs e)
        {
            removeThis.Clear();

            foreach (var i in MyCanvas.Children.OfType<Rectangle>())
            {
                if ((string)i.Tag == "top" || (string)i.Tag == "bottom")
                {
                    removeThis.Add(i);

                    topCount--;
                    bottomCount--;

                    miss++;
                }
            }

            if (topCount < 3)
            {
                ShowDummies(topLocation[random.Next(0, 6)], 35, random.Next(1, 5), "top");
                topCount++;
            }

            if (bottomCount < 3)
            {
                ShowDummies(bottomLocation[random.Next(0, 6)], 230, random.Next(1, 5), "bottom");
                bottomCount++;
            }
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRect = (Rectangle)e.OriginalSource;
                MyCanvas.Children.Remove(activeRect);
                score++;

                if ((string)activeRect.Tag == "top") topCount--;
                if((string)activeRect.Tag == "bottom") bottomCount--;
            }
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
            ImageBrush dummyBackground = new ImageBrush();

            switch (skin)
            {
                case 1:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/dummy01.png"));
                    break;
                case 2:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/dummy02.png"));
                    break;
                case 3:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/dummy03.png"));
                    break;
                case 4:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/dummy04.png"));
                    break;
            }

            Rectangle newRec = new Rectangle
            {
                Tag = tag,
                Width = 80,
                Height = 135,
                Fill = dummyBackground
            };

            Canvas.SetLeft(newRec, x);
            Canvas.SetTop(newRec, y);

            MyCanvas.Children.Add(newRec);
        }
    }
}
