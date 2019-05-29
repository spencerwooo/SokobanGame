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
    public LevelSelect()
    {
      InitializeComponent();
    }

    private void PlayLevel(object sender, RoutedEventArgs e)
    {
      // MessageBox.Show("Yeah! Play level", "Retro Sokuban");
      NavigationService.Navigate(new Uri("GameMain.xaml", UriKind.Relative));
    }

    private void BackHome(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("WelcomePage.xaml", UriKind.Relative));
    }
  }
}
