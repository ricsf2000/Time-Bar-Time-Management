using System.Collections.ObjectModel;

namespace Time_Bar_Time_Management
{
    public class TaskManager
    {
        public ObservableCollection<Task> Tasks { get; set;}

        public TaskManager()
        {
            Tasks = new ObservableCollection<Task>();
        }

        private static TaskManager instance;
        public static TaskManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskManager();
                }
                return instance;
            }
        }
    }
}
