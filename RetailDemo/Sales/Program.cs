﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Sales";

            var endPointConfiguration = new EndpointConfiguration("Sales");

            var transport = endPointConfiguration.UseTransport<LearningTransport>();

            var endPointInstance = await Endpoint.Start(endPointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endPointInstance.Stop().ConfigureAwait(false);
        }
    }
}
