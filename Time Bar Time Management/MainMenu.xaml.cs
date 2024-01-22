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

namespace Time_Bar_Time_Management
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private int TotalPercent = 0;
        private double hours;
        private double minutes;
        private bool tmInitialized = false;

        public MainMenu()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void GotFocus_General(TextBox Time, string timeType)
        {
            if (Time != null)
            {
                if (Time.Text == timeType)
                {
                    Time.Text = string.Empty;
                    Time.Foreground = System.Windows.Media.Brushes.Black;
                    Time.FontFamily = new System.Windows.Media.FontFamily("Bookman Old Style");
                    Time.FontStyle = FontStyles.Normal;
                }
            }
        }
        private void LostFocus_General(TextBox Time, string timeType)
        {
            if (Time != null)
            {
                if (Time.Text == "")
                {
                    Time.Text = timeType;
                    Time.Foreground = System.Windows.Media.Brushes.Gray; ;
                    Time.FontFamily = new System.Windows.Media.FontFamily("Segoe UI");
                    Time.FontStyle = FontStyles.Italic;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double currentLeft = Left;
            double currentTop = Top;
            double currentWidth = Width;
            double currentHeight = Height;

            if (int.TryParse(Hours.Text, out int HoursOut) && int.TryParse(Minutes.Text, out int MinutesOut))
            {
                hours = HoursOut;
                minutes = MinutesOut;
            }
            else
            {
                MessageBox.Show("Invalid input.");
            }

            Progress progressWindow = new Progress(hours, minutes);

            progressWindow.Left = currentLeft;
            progressWindow.Top = currentTop;
            progressWindow.Width = currentWidth;
            progressWindow.Height = currentHeight;
            progressWindow.Show();

            Close();
        }

        private void Hours_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocus_General(Hours, "Hours");
        }

        private void Hours_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocus_General(Hours, "Hours");
        }

        private void Minutes_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocus_General(Minutes, "Minutes");
        }

        private void Minutes_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocus_General(Minutes, "Minutes");
        }

        //private void tasksListView(object sender, RoutedEventArgs e)

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tmInitialized == false) 
            {
                tasksListView.ItemsSource = TaskManager.Instance.Tasks;
                tmInitialized = true;
            }
            if (int.TryParse(TimeNeeded.Text, out int pTime))
            {

                if (TotalPercent + pTime <= 100)
                {
                    TaskManager.Instance.Tasks.Add(new Task { Description = Description.Text, PercentTime = pTime });
                    TotalPercent += pTime;
                    TimeNeeded.Text = "";
                    Description.Text = "";
                    LostFocus_General(TimeNeeded, "% Time");
                    LostFocus_General(Description, "Description");
                }
                else
                { MessageBox.Show("Percent is over 100."); }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter an integer.");
            }            
        }

        private void TimeNeeded_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocus_General(TimeNeeded, "% Time");
        }

        private void TimeNeeded_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocus_General(TimeNeeded, "% Time");
        }

        private void Description_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocus_General(Description, "Description");
        }

        private void Description_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocus_General(Description, "Description");
        }
    }
}
