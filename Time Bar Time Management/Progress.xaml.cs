using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Time_Bar_Time_Management
{
    /// <summary>
    /// Interaction logic for Progress.xaml
    /// </summary>
    public partial class Progress : Window
    {
        double totalTime;
        DateTime startingTime;
        private DispatcherTimer timer;
        public Progress(double hours, double minutes)
        {
            InitializeComponent();
            ObservableCollection<Task> Tasks = TaskManager.Instance.Tasks;
            taskListBox.ItemsSource = TaskManager.Instance.Tasks;
            startingTime = DateTime.Now;
            totalTime = (hours*60) + minutes;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(0.001); 
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateOverallProgress();
        }
        private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double currentProgress = 0;
            foreach (Task task in TaskManager.Instance.Tasks)
            {
                int intPercentTime = task.PercentTime;
                double doublePercentTime = (double)intPercentTime;
                currentProgress += (doublePercentTime*(task.completion))/100;
            }
            OverallProgress.Value = currentProgress;
        }
        private void UpdateOverallProgress()
        {
            // Calculate progress based on real-world time or any other criteria
            // For example, use the current time or other external factors
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime - startingTime;
            double progress = (elapsedTime.TotalMinutes) / (totalTime) * 100.0;
            TimeLeft.Value = progress;
        }
    }
}
