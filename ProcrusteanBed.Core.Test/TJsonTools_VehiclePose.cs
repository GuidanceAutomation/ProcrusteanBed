using FleetClients.FleetManagerServiceReference;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using BaseClients;
using System.Net;
using FleetClients;
using System;

namespace ProcrusteanBed.Core.Test
{
	[TestFixture]
	public class TJsonTools_VehiclePose
	{
		private IFleetManagerClient client;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			IPAddress ipAddress = IPAddress.Loopback;
			EndpointSettings endpointSettings = new EndpointSettings(ipAddress);

			client = ClientFactory.CreateTcpFleetManagerClient(endpointSettings);
		}

		[Test]
		public void Ley()
		{
			List<VehiclePose> vehiclePoses = new List<VehiclePose>()
			{
				CreateVehiclePose("192.168.0.1", 15.92, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.2", 18.44, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.3", 27.63, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.4", 30.15, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.5", 32.64, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.6", 35.15, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.7", 37.62, 21.95, Math.PI/2),
				CreateVehiclePose("192.168.0.8", 40.12, 21.95, Math.PI/2),
			};

			client.CreateVirtualVehicles(vehiclePoses);
		}

		[Test]
		public void DOORN()
		{
			List<VehiclePose> vehiclePoses = new List<VehiclePose>()
			{
				CreateVehiclePose("192.168.0.1", 6.03, 1.4, Math.PI/2),
				CreateVehiclePose("192.168.0.2", 2.43, 22.15, 0),
				CreateVehiclePose("192.168.0.3", 2.43, 20.34, 0),
				CreateVehiclePose("192.168.0.4", 23.58, 7.12, Math.PI),
				CreateVehiclePose("192.168.0.5", 23.65, 5.59, Math.PI)
			};

			client.CreateVirtualVehicles(vehiclePoses);
		}

		[Test]
		public void Enumerable_ToJson()
		{
			List<VehiclePose> vehiclePoses = new List<VehiclePose>()
			{
				CreateVehiclePose("192.168.0.1"),
				CreateVehiclePose("192.168.0.2")
			};

			string json = JsonTools.ToJson(vehiclePoses);

			IEnumerable<VehiclePose> obj = JsonTools.ToVehiclePoses(json);

			CollectionAssert.IsNotEmpty(obj);

			Assert.AreEqual("192.168.0.1", obj.First().IPv4Address);
			Assert.AreEqual("192.168.0.2", obj.Last().IPv4Address);
		}

		private VehiclePose CreateVehiclePose(string ipV4string, double x = 0 , double y = 0, double heading = 0)
		{
			return new VehiclePose()
			{
				IPv4Address = ipV4string,
				PoseData = new PoseData()
				{
					X = x,
					Y = y,
					Heading = heading
				}
			};
		}

		[Test]
		public void ToJson()
		{
			string ipv4string = "192.168.1.1";
			PoseData poseData = new PoseData()
			{
				X = 1,
				Y = 2,
				Heading = 0.5
			};

			VehiclePose vehiclePose = new VehiclePose()
			{
				IPv4Address = ipv4string,
				PoseData = poseData
			};

			string json = JsonTools.ToJson(vehiclePose);
			VehiclePose obj = JsonTools.ToVehiclePose(json);

			Assert.AreEqual(ipv4string, vehiclePose.IPv4Address);

			Assert.AreEqual(poseData.X, vehiclePose.PoseData.X);
			Assert.AreEqual(poseData.Y, vehiclePose.PoseData.Y);
			Assert.AreEqual(poseData.Heading, vehiclePose.PoseData.Heading);
		}
	}
}