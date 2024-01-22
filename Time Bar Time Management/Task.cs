using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Time_Bar_Time_Management
{
    public class Task : INotifyPropertyChanged
    {
        public string Description { get; set; }
        public int PercentTime { get; set; }
        public double Completion { get; set; } = 0;
        public double completion
        {
            get { return Completion * 100; }
            set
            {
                if (value != Completion * 100)
                {
                    Completion = value / 100;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FormattedCompletion));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string FormattedCompletion => $"{completion:F2}%";

    }
}