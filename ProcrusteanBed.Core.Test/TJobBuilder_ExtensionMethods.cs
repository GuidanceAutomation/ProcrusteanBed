using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients;
using ProcrusteanBed.Core;
using BaseClients;
using System.Net;
using System.IO;

namespace ProcrusteanBed.Core.Test
{
    [TestFixture]
    public class TJobBuilder_ExtensionMethods
    {
        IJobBuilderClient client; 

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            IPAddress ipAddress = IPAddress.Loopback;
            EndpointSettings endpointSettings = new EndpointSettings(ipAddress);

            client = ClientFactory.CreateTcpJobBuilderClient(endpointSettings);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (client != null) client.Dispose();
        }

        [Test]
        public void GoToNode2()
        {
            Job populatedJob = client.BuildJobFromJson(Properties.Resources.GoToNode2);
        }

		[Test]
		public void Nooooo()
		{
			for (int i = 0; i <2; i++)
			{
				string json = File.ReadAllText(@"C:\Users\martin.davies.AUTOMATION1\Documents\json\BagV-3896 Doorn.txt");
				//string json = File.ReadAllText(@"C:\Users\martin.davies.AUTOMATION1\Documents\json\nooGoTo.txt");
				//string json = File.ReadAllText(@"C:\Users\martin.davies.AUTOMATION1\Documents\json\leyley.txt");
				Job populatedJob = client.BuildJobFromJson(json);
			}


		}
    }
}
