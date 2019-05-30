using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    // For playing lobby music in background
    MediaPlayer mediaPlayer = new MediaPlayer();

    public MainWindow()
    {
      InitializeComponent();

      // Go to welcome page
      _NavigationFrame.Navigate(new WelcomePage());

      // Start playing background music
      string lobbyMusicPath = "../../../Resources/music/LobbyMusic.mp3";
      mediaPlayer.Open(new Uri(lobbyMusicPath, UriKind.Relative));
      mediaPlayer.Play();
    }

    private void Media_Ended(object sender, EventArgs e)
    {
      // Start media from the top! On and on and on...
      mediaPlayer.Position = TimeSpan.Zero;
      mediaPlayer.Play();
    }

    private void DragWindow(object sender, MouseButtonEventArgs e)
    {
      // Implement a draggable window titlebar area
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
