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
	/// Interaction logic for AtomicMoveListControl.xaml
	/// </summary>
	public partial class AtomicMoveListControl : UserControl
	{
		public AtomicMoveListControl()
		{
			InitializeComponent();
		}

		private void AddAtomicMoveMenuItem_Click(object sender, RoutedEventArgs e)
		{
			AbstractListTask listTask = DataContext as AbstractListTask;
			listTask.AddSubtask(new AtomicMoveTask());
		}
	}
}
