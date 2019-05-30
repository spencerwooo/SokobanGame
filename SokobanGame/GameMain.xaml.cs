using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace SokobanGame
{
  /// <summary>
  /// Interaction logic for GameMain.xaml
  /// </summary>
  public partial class GameMain : Page
  {
    private int gameLevel;
    private int currentHealth = 3;
    private int currentSteps = 0;
    public GameMain(int gameLevel)
    {
      InitializeComponent();

      // Get data from LevelSelect
      this.gameLevel = gameLevel;

      initMap(gameLevel);

      startCountDown(CountDownTimer);
    }

    private void startCountDown(FrameworkElement target)
    {
      var countDownAnimation = new StringAnimationUsingKeyFrames();
      var remainingTime = 60;

      for (var i = remainingTime; i > 0; i--)
      {
        var keyTime = TimeSpan.FromSeconds(remainingTime - i);
        var frame = new DiscreteStringKeyFrame("Time: " + i.ToString() + "s", KeyTime.FromTimeSpan(keyTime));
        countDownAnimation.KeyFrames.Add(frame);
      }

      countDownAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("Time's up!", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(remainingTime + 1))));
      Storyboard.SetTargetName(countDownAnimation, target.Name);
      Storyboard.SetTargetProperty(countDownAnimation, new PropertyPath(TextBlock.TextProperty));

      var countdownStoryboard = new Storyboard();
      countdownStoryboard.Children.Add(countDownAnimation);
      countdownStoryboard.Completed += CountdownTimerCompleted;
      countdownStoryboard.Begin(this);
    }

    private void CountdownTimerCompleted(object sender, EventArgs e)
    {
      MessageBox.Show("Time's up!");
    }

    private void GoBack(object sender, RoutedEventArgs e)
    {
      var result = MessageBox.Show("Do you really want to leave this level?", "Abort level", MessageBoxButton.YesNo, MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes)
      {
        // NavigationService.Navigate(new Uri("LevelSelect.xaml", UriKind.Relative));
        NavigationService.GoBack();
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
      GameLevelLabel.Content = "LEVEL #" + level.ToString();
      HealthLabel.Content = "HEALTH: " + currentHealth.ToString();
      MovesLabel.Content = "STEPS: " + currentSteps.ToString();
    }
  }
}
