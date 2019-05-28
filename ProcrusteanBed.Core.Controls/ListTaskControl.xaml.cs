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

namespace ProcrusteanBed.Core.Controls
{
    /// <summary>
    /// Interaction logic for ListTaskControl.xaml
    /// </summary>
    public partial class ListTaskControl : UserControl
    {
        public ListTaskControl()
        {
            InitializeComponent();
        }

        private void AddOrderedListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AbstractListTask listTask = DataContext as AbstractListTask;
            listTask.AddSubtask(new OrderedListTask());           

        }

        private void AddGoToNodeTaskMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AbstractListTask listTask = DataContext as AbstractListTask;
            listTask.AddSubtask(new GoToNodeTask());
        }

        private void AddServicingTask_Click(object sender, RoutedEventArgs e)
        {
            AbstractListTask listTask = DataContext as AbstractListTask;
            listTask.AddSubtask(new ServiceAtNodeTask());
        }
    }
}
