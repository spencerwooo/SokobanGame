using System;
using System.Windows;
using System.Windows.Controls;
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

    public LevelSelect()
    {
      InitializeComponent();
      SelectedLevelLabel.Content = "SELECT LEVEL #" + currentLevel;
    }

    private void PlayLevel(object sender, RoutedEventArgs e)
    {
      // Start playing level
      // NavigationService.Navigate(new Uri("GameMain.xaml", UriKind.Relative), currentLevel.ToString());
      NavigationService.Navigate(new GameMain(currentLevel));
    }

    private void BackHome(object sender, RoutedEventArgs e)
    {
      // NavigationService.Navigate(new Uri("WelcomePage.xaml", UriKind.Relative));
      NavigationService.GoBack();
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
      SelectedLevelLabel.Content = "SELECT LEVEL #" + currentLevel;
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
    }

    private string imagePathBuilder(int level)
    {
      string imagePath = "/SokobanGame;component/Resources/levels/level" + level.ToString() + ".png";
      return imagePath;
    }
  }
}
