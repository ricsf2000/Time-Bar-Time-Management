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
using System.Windows.Shapes;

namespace Time_Bar_Time_Management
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void GotFocus_Time(TextBox Time, string timeType)
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
        private void LostFocus_Time(TextBox Time, string timeType)
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

        }

        private void Hours_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox Time = (TextBox)sender;
            GotFocus_Time(Time, "Hours");
        }

        private void Hours_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Time = (TextBox)sender;
            LostFocus_Time(Time, "Hours");
        }

        private void Minutes_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox Time = (TextBox)sender;
            GotFocus_Time(Time, "Minutes");
        }

        private void Minutes_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Time = (TextBox)sender;
            LostFocus_Time(Time, "Minutes");
        }

        private void tasksListView(object sender, RoutedEventArgs e)
    }
}
