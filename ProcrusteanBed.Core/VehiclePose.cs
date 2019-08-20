using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using FleetClients;
using System.Runtime.Serialization;
using FleetClients.FleetManagerServiceReference;

namespace ProcrusteanBed.Core
{
	[DataContract]
	public class VehiclePose : INotifyPropertyChanged
	{
		private PoseData poseData = null;

		[DataMember]
		public PoseData PoseData
		{
			get { return poseData; }
			set
			{
				if (poseData != value)
				{
					poseData = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private string ipv4Address = string.Empty;

		public IPAddress IPAddress => IPAddress.Parse(IPv4Address);

		[DataMember]
		public string IPv4Address
		{
			get { return ipv4Address; }
			set
			{
				if (ipv4Address != value)
				{
					ipv4Address = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public VehiclePose()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
