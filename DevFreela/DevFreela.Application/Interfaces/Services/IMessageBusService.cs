using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.Services
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);   
    }
}
