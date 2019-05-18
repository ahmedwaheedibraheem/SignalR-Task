using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(signalR.Startup))]

namespace signalR {
    public class Startup {
        public void Configuration ( IAppBuilder app ) {
            app.MapSignalR(); // create signalr 
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
