﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Commands
{
    public class PlaceOrder: ICommand
    {
        public string OrderId { get; set; }

    }
}
