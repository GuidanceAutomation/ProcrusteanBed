using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetClients;
using MoreLinq;
using System.Net;
using FleetClients.FleetManagerServiceReference;

namespace ProcrusteanBed.Core
{
	public static class FleetManagerClient_ExtensionMethods
	{
		public static void CreateVirtualVehicles(this IFleetManagerClient client, IEnumerable<VehiclePose> vehiclePoses)
		{
			vehiclePoses.ForEach(e => client.CreateVirtualVehicle(e));
		}

		public static void CreateVirtualVehicle(this IFleetManagerClient fleetManagerClient, VehiclePose vehiclePose)
		{
			fleetManagerClient.TryCreateVirtualVehicle(vehiclePose.IPAddress, vehiclePose.PoseData, out bool success);
		}

	}
}
