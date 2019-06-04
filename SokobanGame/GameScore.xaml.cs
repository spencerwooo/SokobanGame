using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for GameScore.xaml
  /// </summary>
  public partial class GameScore : Page
  {
    private int level;
    private int result;
    private bool darkModeEnabled;

    public GameScore(int level, int result, bool darkModeEnabled)
    {
      InitializeComponent();

      this.level = level;
      this.result = result;
      this.darkModeEnabled = darkModeEnabled;

      if (darkModeEnabled)
      {
        BackgroundGrid.Background = new SolidColorBrush(Color.FromRgb(37, 37, 38));
      }

      if (result == 1)
      {
        if (level == 11)
        {
          TitleText.Content = "You have completed all levels!";
        }
        else
        {
          TitleText.Content = "You have completed level #" + level + "!";
        }
      }

      if (result == 0)
      {
        TitleText.Content = "Time is up, you are dead now.";
        CaptionText.Content = "Oh, snap!";
        AwardImage.Source = new BitmapImage(new Uri("/SokobanGame;component/Resources/rip.png", UriKind.Relative));

        Uri buttonBrushBg = new Uri("/SokobanGame;component/Resources/restart.png", UriKind.Relative);
        StreamResourceInfo streamInfo = Application.GetResourceStream(buttonBrushBg);
        BitmapFrame bitmapFrame = BitmapFrame.Create(streamInfo.Stream);
        ImageBrush brush = new ImageBrush
        {
          ImageSource = bitmapFrame
        };
        ContinueButton.Background = brush;
      }
    }

    private void ContinueOrRestart(object sender, RoutedEventArgs e)
    {
      int nextLevel = 0;

      if (result == 1)
      {
        if (level >= 11)
        {
          nextLevel = 1;
        }
        else
        {
          nextLevel = level + 1;
        }
      }

      if (result == 0)
      {
        nextLevel = level;
      }

      NavigationService.Navigate(new GameMain(nextLevel, darkModeEnabled));
    }
  }
}
