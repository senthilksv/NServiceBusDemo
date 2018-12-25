using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "ClientUI";

            var endPointConfiguration = new EndpointConfiguration("ClientUI");

            var transport = endPointConfiguration.UseTransport<LearningTransport>();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            var endpointInstance = await Endpoint.Start(endPointConfiguration).ConfigureAwait(false);

            await RunLoop(endpointInstance).ConfigureAwait(false);

            await endpointInstance.Stop().ConfigureAwait(false);
        }

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Press P to Place an order, or 'Q' to quit");

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                      
                            var command = new PlaceOrder()
                            {
                                OrderId = Guid.NewGuid().ToString()
                            };

                        log.Info($"Sending PlaceOrde command, Order Id = {command.OrderId } ");

                        await endpointInstance.Send(command).ConfigureAwait(false);

                        break;

                    case ConsoleKey.Q:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
