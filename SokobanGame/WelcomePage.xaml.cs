using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for WelcomePage.xaml
  /// </summary>
  public partial class WelcomePage : Page
  {
    public WelcomePage()
    {
      InitializeComponent();
    }

    private void StartGame(object sender, RoutedEventArgs e)
    {
      // Go on to level select.
      NavigationService.Navigate(new LevelSelect());
    }
  }
}
