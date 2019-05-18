using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace signalR {
    public class ChatHub : Hub {
        public void NewMessage ( string name , string message ) {
            // all clients that use signal r 
            // .All a dynamic property  has the function named that suposed to run in client that client have
            Clients.All.onMessage(name , message);
            //rub http://localhost/signalr/hubs contains the script of signalr
            //Clients.Caller talk to urself
            //Clients.AllExcept() send to all connection id
            //Clients.Client send to only 1 with connection id

            // groups / list of group names
        }
        public void NewPosition ( int top , int left ) {
            //send to all clients except me  
            // problem because the return value from server for each value
            Clients.Others.onMove(top , left);
        }
        // to make id
        public void JoinGroup ( string name , string gName ) {

            // connection id is created for every client
            Groups.Add(Context.ConnectionId , gName);

            //send all group except the client who enter
            Clients.OthersInGroup(gName).onMessage(name , "joins Group" + gName);
        }
        public void SendGroup ( string name , string gName , string message ) {
            Clients.Group(gName).onMessage(name , message);
        }

        /* windos form create 2 text 1 btn 1 txtarea
         * download signal r client 
         * > in form initialize hubconnection ihubproxy
         * > in public form 1 constructor
         * hubconnection con = new hubConnection("http://localhost:port/signalr");
         * IhubProxy chathub = con.createhubproxy("chatHub"); order matter b4 con.start()
         * con.start();
         * chathub.On<string,string>("onMessage",(name,message)=> listbox.items.add(name+" : "+Message));
         * > btnsend click handler
         * chathub.invoke("newMessage",name,message);
         */

        public override Task OnConnected () {
            var x = Context.ConnectionId; // on connection.hub.start() this runs
            return base.OnConnected();
        }
        public override Task OnDisconnected ( bool stopCalled ) {
            var x = Context.ConnectionId; // on closing browser 
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected () {
            var x = Context.ConnectionId;
            return base.OnReconnected();
        }
        
    }
}