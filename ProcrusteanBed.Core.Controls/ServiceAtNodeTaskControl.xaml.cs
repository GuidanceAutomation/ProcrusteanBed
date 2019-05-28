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
using SchedulingClients.JobBuilderServiceReference;

namespace ProcrusteanBed.Core.Controls
{
    /// <summary>
    /// Interaction logic for ServiceAtNodeTask.xaml
    /// </summary>
    public partial class ServiceAtNodeTaskControl : UserControl
    {
        public ServiceAtNodeTaskControl()
        {
            InitializeComponent();

            serviceTypeComboBox.ItemsSource = Enum.GetValues(typeof(ServiceType));
        }
    }
}
