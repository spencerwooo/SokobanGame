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
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      _NavigationFrame.Navigate(new WelcomePage());
    }

    //private void StartGame(object sender, RoutedEventArgs e)
    //{

    //}

    private void DragWindow(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left)
      {
        DragMove();
      }
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
      var result = MessageBox.Show("Do you really want to quit?", "Quit Game", MessageBoxButton.YesNo, MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes)
      {
        Close();
      }
      else
      {
        // Do nothing.
      }
    }
  }
}
