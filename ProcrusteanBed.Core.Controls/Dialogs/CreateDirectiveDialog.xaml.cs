using ProcrusteanBed.Architecture;
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

namespace ProcrusteanBed.Core.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateDirectiveDialog.xaml
    /// </summary>
    public partial class CreateDirectiveDialog : Window
    {
        public CreateDirectiveDialog()
        {
            InitializeComponent();
            listBox.ItemsSource = Enumerators.DirectiveTypes;
            listBox.SelectedIndex = 0;
        }

        public Type SelectedDirective => (Type)listBox.SelectedItem;

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
