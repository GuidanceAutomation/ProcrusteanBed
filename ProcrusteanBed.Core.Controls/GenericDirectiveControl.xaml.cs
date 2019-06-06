using ProcrusteanBed.Architecture;
using ProcrusteanBed.Core.Controls.Directives;
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
	/// Interaction logic for GenericDirectiveControl.xaml
	/// </summary>
	public partial class GenericDirectiveControl : UserControl
	{
		public GenericDirectiveControl()
		{
			InitializeComponent();
		}

		private void GenericDirectiveControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			try
			{
				IDirective directive = e.NewValue as IDirective;
				Type type = directive.GetType();

				object value = type.GetProperty("DirectiveValue").GetValue(directive);

				switch(value)
				{
					case Byte byteValue:
						{
							ByteControl byteControl = new ByteControl();
							byteControl.DataContext = directive;
							mainStack.Children.Add(byteControl);

							break;
						}

					default:
						{
							throw new NotImplementedException();
						}
				}
			}
			catch (Exception ex)
			{

			}
		}
	}
}
