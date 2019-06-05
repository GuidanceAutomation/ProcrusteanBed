using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace ProcrusteanBed.Core
{
	[DataContract]
	public class JobTemplate
	{
		private string description = string.Empty;

		private string category = string.Empty;

		private string site = string.Empty;

		private Job job = new Job();

		[DataMember]
		public Job Job
		{
			get { return job; }
			set
			{
				if (job != value)
				{
					job = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		[DataMember]
		public string Site
		{
			get { return site; }
			set
			{
				if (value == null) value = string.Empty;

				if (site != value)
				{
					site = value;
					OnNotifyPropertyChanged();
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		[DataMember]
		public string Category
		{
			get { return category; }
			set
			{
				if (value == null) value = string.Empty;

				if (category != value)
				{
					category = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		[DataMember]
		public string Description
		{
			get { return description; }
			set
			{
				if (value == null) value = string.Empty;

				if (description != value)
				{
					description = value;
					OnNotifyPropertyChanged();
				}
			}
		}
	}
}
