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

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for LevelSelect.xaml
  /// </summary>
  public partial class LevelSelect : Page
  {
    private int currentLevel = 1;
    public LevelSelect()
    {
      InitializeComponent();
      SelectedLevelLabel.Content = "SELECT LEVEL #" + currentLevel;
    }

    private void PlayLevel(object sender, RoutedEventArgs e)
    {
      // Start playing level
      NavigationService.Navigate(new Uri("GameMain.xaml", UriKind.Relative), currentLevel.ToString());
    }

    private void BackHome(object sender, RoutedEventArgs e)
    {
      // NavigationService.Navigate(new Uri("WelcomePage.xaml", UriKind.Relative));
      NavigationService.GoBack();
    }

    private void NextLevel(object sender, RoutedEventArgs e)
    {
      if (currentLevel >= 11)
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
        currentLevel = 11;
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
      string imagePath = "Resources/levels/level" + level.ToString() + ".png";
      return imagePath;
    }
  }
}
