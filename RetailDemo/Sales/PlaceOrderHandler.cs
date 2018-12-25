using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Received Place Order, Order Id  = { message.OrderId} ");

            var orderPlaced = new OrderPlaced()
            {
                OrderId = message.OrderId
            };

            return context.Publish(orderPlaced);
        }
    }
}
