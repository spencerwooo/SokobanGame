using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for LevelSelect.xaml
  /// </summary>
  public partial class LevelSelect : Page
  {
    private int currentLevel = 1;
    private int totalLevels = 11;
    private bool darkModeEnabled = false;

    public LevelSelect(int currentLevel, bool darkModeEnabled)
    {
      InitializeComponent();

      this.currentLevel = currentLevel;
      this.darkModeEnabled = darkModeEnabled;

      if (darkModeEnabled)
      {
        BackgroundGrid.Background = new SolidColorBrush(Color.FromRgb(37, 37, 38));
      }

      string imagePath = imagePathBuilder(currentLevel);
      LevelPreviewImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));

      SelectedLevelLabel.Content = "SELECTED LEVEL #" + currentLevel;
    }

    private void PlayLevel(object sender, RoutedEventArgs e)
    {
      // Start playing level
      // NavigationService.Navigate(new Uri("GameMain.xaml", UriKind.Relative), currentLevel.ToString());
      string levelSucceeded = Properties.Settings.Default.LevelSucceeded[currentLevel - 1];
      if (levelSucceeded == "true")
      {
        NavigationService.Navigate(new GameMain(currentLevel, darkModeEnabled));
      }
      else
      {
        MessageBox.Show("You need to complete the previous levels first.");
      }

    }

    private void BackHome(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new WelcomePage(darkModeEnabled));
      // NavigationService.Navigate(new Uri("WelcomePage.xaml", UriKind.Relative));
      // NavigationService.GoBack();
    }

    private void NextLevel(object sender, RoutedEventArgs e)
    {
      if (currentLevel >= totalLevels)
      {
        currentLevel = 1;
      }
      else
      {
        currentLevel += 1;
      }

      string imagePath = imagePathBuilder(currentLevel);
      LevelPreviewImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
      SelectedLevelLabel.Content = "SELECTED LEVEL #" + currentLevel;

      string levelSucceeded = Properties.Settings.Default.LevelSucceeded[currentLevel - 1];
      if (levelSucceeded == "true")
      {
        LevelStatus.Source = new BitmapImage(new Uri("/SokobanGame;component/Resources/stats/star.png", UriKind.Relative));
        LevelPreviewMask.Opacity = 0.0;
      }
      else
      {
        LevelStatus.Source = new BitmapImage(new Uri("/SokobanGame;component/Resources/stats/no.png", UriKind.Relative));
        LevelPreviewMask.Opacity = 0.8;
      }
    }

    private void PreviousLevel(object sender, RoutedEventArgs e)
    {
      if (currentLevel <= 1)
      {
        currentLevel = totalLevels;
      }
      else
      {
        currentLevel -= 1;
      }

      string imagePath = imagePathBuilder(currentLevel);
      LevelPreviewImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
      SelectedLevelLabel.Content = "SELECTED LEVEL #" + currentLevel;

      string levelSucceeded = Properties.Settings.Default.LevelSucceeded[currentLevel - 1];
      if (levelSucceeded == "true")
      {
        LevelStatus.Source = new BitmapImage(new Uri("/SokobanGame;component/Resources/stats/star.png", UriKind.Relative));
        LevelPreviewMask.Opacity = 0.0;
      }
      else
      {
        LevelStatus.Source = new BitmapImage(new Uri("/SokobanGame;component/Resources/stats/no.png", UriKind.Relative));
        LevelPreviewMask.Opacity = 0.8;
      }
    }

    private void ResetGame(object sender, RoutedEventArgs e)
    {
      var result = MessageBox.Show("Are you sure to wipe game history?", "Reset Game",
        MessageBoxButton.YesNo, MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes)
      {
        for (int i = 0; i < 11; i++)
        {
          Console.WriteLine(i + ": " + Properties.Settings.Default.LevelSucceeded[i]);
          Properties.Settings.Default.LevelSucceeded[i] = "false";
        }
        Properties.Settings.Default.LevelSucceeded[0] = "true";

        Properties.Settings.Default.GodModeEnabled = false;
        Properties.Settings.Default.Save();
      }
      else
      {
        // Do nothing.
      }
    }

    private string imagePathBuilder(int level)
    {
      string imagePath = "/SokobanGame;component/Resources/levels/level" + level.ToString() + ".png";
      return imagePath;
    }
  }
}
