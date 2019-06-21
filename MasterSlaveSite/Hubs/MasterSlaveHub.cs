using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MasterSlaveSite.Hubs
{
    public class MasterSlaveHub : Hub
    {
        public static ConcurrentDictionary<string, string> _slaves = new ConcurrentDictionary<string, string>();

        public void RegisterSlave()
        {
            var slaveCode = Context.RequestCookies["SlaveCode"].Value;
            if (!string.IsNullOrEmpty(slaveCode))
            {
                _slaves.AddOrUpdate(slaveCode, Context.ConnectionId, (s, s1) => Context.ConnectionId );
                Clients.Caller.SlaveCodeRegistered(slaveCode);
            }

            //Clients.All.hello();
        }

        public void OpenThisUrl(string slave, string url, string mode)
        {
            if (_slaves.TryGetValue(slave, out var slaveId))
            {
                var client = Clients.Client(slaveId);
                if (client != null)
                {
                    client.SlaveOpenThisUrl(slave, url, mode);
                }
            }
        }
    }
}