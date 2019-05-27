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
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace ProcrusteanBed.Core.Controls
{
    public partial class JobTemplateControl : UserControl
    {
        public static readonly DependencyProperty JobProperty =
            DependencyProperty.Register(
            "Job", typeof(Job),
            typeof(JobTemplateControl),
            new PropertyMetadata(new Job())
            );

        public Job Job
        {
            get { return (Job)GetValue(JobProperty); }
            set { SetValue(JobProperty, value); }
        }

        public JobTemplateControl()
        {
            InitializeComponent();
        }

        private void ConvertToJsonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonTools.ToJson(Job);

            string tempFileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            File.WriteAllText(tempFileName, json);

            Process.Start(tempFileName);
        }

        private void ClearMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Job = new Job();
        }

        private void LoadFromJsonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = DialogFactory.GetOpenJsonDialog();

            if (dialog.ShowDialog() == true)
            {
                Job = Factory.JobFromFile(dialog.FileName);
            }
        }
    }
}
