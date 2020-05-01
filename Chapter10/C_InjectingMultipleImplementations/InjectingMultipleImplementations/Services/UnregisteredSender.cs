using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjectingMultipleServices.Services
{
    public class UnregisteredSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            throw new Exception("I'm never registered so shouldn't be called");
        }
    }
}
