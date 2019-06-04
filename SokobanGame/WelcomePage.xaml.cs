using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for WelcomePage.xaml
  /// </summary>
  public partial class WelcomePage : Page
  {
    private bool darkModeEnabled = false;

    public WelcomePage(bool darkModeEnabled)
    {
      InitializeComponent();
      this.darkModeEnabled = darkModeEnabled;

      if (darkModeEnabled)
      {
        WelcomePageBackground.Background = new SolidColorBrush(Color.FromRgb(37, 37, 38));
        ModeToggleBtn.IsChecked = true;

        Uri resourceUri = new Uri("/SokobanGame;component/Resources/darkmode.png", UriKind.Relative);
        StreamResourceInfo streamResourceInfo = Application.GetResourceStream(resourceUri);
        BitmapFrame bitmapFrame = BitmapFrame.Create(streamResourceInfo.Stream);
        ImageBrush imageBrush = new ImageBrush();
        imageBrush.ImageSource = bitmapFrame;
        ModeToggleBtn.Background = imageBrush;

        ModeLabel.Content = "DARK MODE";
      }

      jumpAnimation(PlayerIcon1, 15, 2.0);
      jumpAnimation(PlayerIcon2, 15, 1.5);
      jumpAnimation(PlayerIcon3, 15, 1.8);
    }

    private void StartGame(object sender, RoutedEventArgs e)
    {
      // Go on to level select.
      NavigationService.Navigate(new LevelSelect(1, darkModeEnabled));
    }

    private void jumpAnimation(Image target, double newY, double duration)
    {
      Vector offset = VisualTreeHelper.GetOffset(target);
      var top = offset.X;

      TranslateTransform translateTransform = new TranslateTransform();
      target.RenderTransform = translateTransform;

      DoubleAnimation animate = new DoubleAnimation(0, newY - top, TimeSpan.FromSeconds(duration));

      BounceEase bounce = new BounceEase();
      bounce.EasingMode = EasingMode.EaseOut;

      animate.EasingFunction = bounce;
      animate.AutoReverse = true;
      animate.RepeatBehavior = RepeatBehavior.Forever;

      translateTransform.BeginAnimation(TranslateTransform.YProperty, animate);
    }

    private void EnableDarkMode(object sender, RoutedEventArgs e)
    {
      WelcomePageBackground.Background = new SolidColorBrush(Color.FromRgb(37, 37, 38));
      ModeLabel.Content = "DARK MODE";

      Uri resourceUri = new Uri("/SokobanGame;component/Resources/darkmode.png", UriKind.Relative);
      StreamResourceInfo streamResourceInfo = Application.GetResourceStream(resourceUri);
      BitmapFrame bitmapFrame = BitmapFrame.Create(streamResourceInfo.Stream);
      ImageBrush imageBrush = new ImageBrush();
      imageBrush.ImageSource = bitmapFrame;
      ModeToggleBtn.Background = imageBrush;

      darkModeEnabled = true;
    }

    private void DisableDarkMode(object sender, RoutedEventArgs e)
    {
      WelcomePageBackground.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
      ModeLabel.Content = "NORMAL MODE";

      Uri resourceUri = new Uri("/SokobanGame;component/Resources/lightmode.png", UriKind.Relative);
      StreamResourceInfo streamResourceInfo = Application.GetResourceStream(resourceUri);
      BitmapFrame bitmapFrame = BitmapFrame.Create(streamResourceInfo.Stream);
      ImageBrush imageBrush = new ImageBrush();
      imageBrush.ImageSource = bitmapFrame;
      ModeToggleBtn.Background = imageBrush;

      darkModeEnabled = false;
    }
  }
}
