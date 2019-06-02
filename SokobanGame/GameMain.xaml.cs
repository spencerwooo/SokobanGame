using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for GameMain.xaml
  /// </summary>
  public partial class GameMain : Page
  {
    // Game main attributes
    private int gameLevel;
    private int currentHealth = 3;
    private int currentSteps = 0;

    private Storyboard countdownStoryboard = new Storyboard();
    private StringAnimationUsingKeyFrames countDownAnimation = new StringAnimationUsingKeyFrames();

    // Map
    StringBuilder mapString = new StringBuilder(70);

    // Level parameter, from 1 to 11 levels
    private Dictionary<int, int> levelParams = new Dictionary<int, int>
    {
      { 1, 0x00 }, { 2, 0x01 }, { 3, 0x02 },
      { 4, 0x03 }, { 5, 0x04 }, { 6, 0x05 },
      { 7, 0x06 }, { 8, 0x07 }, { 9, 0x08 },
      { 10, 0x09 }, { 11, 0x0A }
    };

    // Directions: up, down, left, right
    private Dictionary<string, int> directions = new Dictionary<string, int>
    {
      { "up", 0x10 },
      { "down", 0x11 },
      { "left", 0x12 },
      { "right", 0x13 }
    };

    // Map elements
    private Dictionary<char, string> mapElements = new Dictionary<char, string>
    {
      { 'P', "/SokobanGame;component/Resources/player/player1-1.png" },
      { 'Q', "/SokobanGame;component/Resources/player/player1-1.png" },
      { 'B', "/SokobanGame;component/Resources/map/box.png" },
      { 'T', "/SokobanGame;component/Resources/map/target.png" },
      { 'F', "/SokobanGame;component/Resources/map/box.png" },
      { 'W', "/SokobanGame;component/Resources/map/wall.png" },
      { 'G', "/SokobanGame;component/Resources/map/grass.png" },
      { 'E', "" }
    };

    // Heart stickers dictionary
    private Dictionary<string, Image> heartImageDict = new Dictionary<string, Image> { };

    // Game core logics, in Assembly
    [DllImport("SokobanASM.dll")]
    public static extern int control(StringBuilder a, int b);

    // Start game!
    public GameMain(int gameLevel)
    {
      InitializeComponent();

      // Get data from LevelSelect
      this.gameLevel = gameLevel;

      // Change player as levels get harder
      int player = gameLevel % 3 + 1;
      mapElements['P'] = "/SokobanGame;component/Resources/player/player" + player + "-1.png";
      mapElements['Q'] = "/SokobanGame;component/Resources/player/player" + player + "-1.png";

      initMap(gameLevel);
    }

    // Attach window key up event to page
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      Application.Current.MainWindow.KeyUp += new KeyEventHandler(Window_KeyUp);
      startCountDown(CountDownTimer);
    }

    // Remove window key up event on page unloaded event
    private void Page_Unloaded(object sender, RoutedEventArgs e)
    {
      // Remove key up listener
      Application.Current.MainWindow.KeyUp -= Window_KeyUp;

      // Remove countdown callback event on page unloaded
      countdownStoryboard.Completed -= CountdownTimerCompleted;
      countdownStoryboard.Stop(this);
      countdownStoryboard.Children.Remove(countDownAnimation);
    }

    private void startCountDown(FrameworkElement target)
    {
      var remainingTime = 120;

      for (var i = remainingTime; i > 0; i--)
      {
        var keyTime = TimeSpan.FromSeconds(remainingTime - i);
        var frame = new DiscreteStringKeyFrame("Time: " + i.ToString() + "s", KeyTime.FromTimeSpan(keyTime));
        countDownAnimation.KeyFrames.Add(frame);
      }

      countDownAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("Time's up!", 
        KeyTime.FromTimeSpan(TimeSpan.FromSeconds(remainingTime + 1))));
      Storyboard.SetTargetName(countDownAnimation, target.Name);
      Storyboard.SetTargetProperty(countDownAnimation, new PropertyPath(TextBlock.TextProperty));

      countdownStoryboard.Children.Add(countDownAnimation);
      countdownStoryboard.Completed += CountdownTimerCompleted;
      countdownStoryboard.Begin(this);
    }

    private void CountdownTimerCompleted(object sender, EventArgs e)
    {
      NavigationService.Navigate(new GameScore(gameLevel, 0));
    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
      var result = MessageBox.Show("Do you really want to leave this level?", "Abort level", 
        MessageBoxButton.YesNo, MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes)
      {
        NavigationService.Navigate(new LevelSelect(gameLevel));
        // NavigationService.GoBack();
      }
      else
      {
        // Do nothing.
      }
    }

    private void BackHome(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new WelcomePage());
    }

    private void initMap(int level)
    {
      // Init values
      GameLevelLabel.Content = "LEVEL #" + level.ToString();
      HealthLabel.Content = "HEALTH: " + currentHealth.ToString();
      MovesLabel.Content = "STEPS: " + currentSteps.ToString();

      Properties.Settings.Default.LevelSucceeded[gameLevel - 1] = "true";

      renderMap();
    }

    private void renderMap()
    {
      // Get map from control
      control(mapString, levelParams[gameLevel]);
      string mapMatrix = mapString.ToString();
      // Console.WriteLine(mapMatrix);

      // Render map elements
      for (int i = 0; i < 7; i++)
      {
        for (int j = 0; j < 9; j++)
        {
          // Map element at Row i Col j is Map[i * 9 + j]
          char elementName = mapMatrix[i * 9 + j];
          Image mapCell = (Image)FindName("Map" + i.ToString() + j.ToString());
          mapCell.Source = new BitmapImage(new Uri(mapElements[elementName], UriKind.Relative));

          if (elementName == 'T' || elementName == 'F')
          {
            Image heartyImage = new Image();
            heartyImage.Height = 38;
            heartyImage.Width = 32;
            heartyImage.Source = new BitmapImage(new Uri("/SokobanGame;component/Resources/map/heart.png", UriKind.Relative));
            heartyImage.Stretch = Stretch.None;
            heartyImage.RenderTransformOrigin = new Point(0.5, 0.5);
            heartyImage.Visibility = Visibility.Hidden;
            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.Y = -20;
            heartyImage.RenderTransform = translateTransform;

            heartImageDict.Add(i.ToString() + j.ToString(), heartyImage);

            MainMapGrid.Children.Add(heartyImage);
            Grid.SetRow(heartyImage, i);
            Grid.SetColumn(heartyImage, j);
          }

          if (elementName == 'F')
          {
            heartImageDict[i.ToString() + j.ToString()].Visibility = Visibility.Visible;
          }
        }
      }
    }

    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
      int gameResult = 0;

      switch (e.Key)
      {
        case Key.Up:
          gameResult = control(mapString, directions["up"]);
          break;
        case Key.Down:
          gameResult = control(mapString, directions["down"]);
          break;
        case Key.Left:
          gameResult = control(mapString, directions["left"]);
          break;
        case Key.Right:
          gameResult = control(mapString, directions["right"]);
          break;
      }

      string mapMatrix = mapString.ToString();

      // Render map elements
      for (int i = 0; i < 7; i++)
      {
        for (int j = 0; j < 9; j++)
        {
          // Map element at Row i Col j is Map[i * 9 + j]
          char elementName = mapMatrix[i * 9 + j];
          var mapCell = (Image)FindName("Map" + i.ToString() + j.ToString());
          mapCell.Source = new BitmapImage(new Uri(mapElements[elementName], UriKind.Relative));

          if (elementName == 'F')
          {
            heartImageDict[i.ToString() + j.ToString()].Visibility = Visibility.Visible;
          }
          else
          {
            if (heartImageDict.ContainsKey(i.ToString() + j.ToString()))
            {
              heartImageDict[i.ToString() + j.ToString()].Visibility = Visibility.Hidden;
            }
          }
        }
      }

      // Render statistics
      currentSteps++;
      MovesLabel.Content = "STEPS: " + currentSteps.ToString();

      if (gameResult == 1)
      {
        Properties.Settings.Default.LevelSucceeded[gameLevel - 1] = "true";
        Properties.Settings.Default.Save();

        NavigationService.Navigate(new GameScore(gameLevel, 1));
      }
    }

    private void GoBackOneStep(object sender, RoutedEventArgs e)
    {

    }

    private void RestartGame(object sender, RoutedEventArgs e)
    {
      var result = MessageBox.Show("Are you sure to restart level?", "Restart level",
        MessageBoxButton.YesNo, MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes)
      {
        NavigationService.Navigate(new GameMain(gameLevel));
      }
      else
      {
        // Do nothing.
      }
    }
  }
}
