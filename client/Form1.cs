using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client {
    public partial class Form1 : Form {
        HubConnection con;
        IHubProxy prox;
        public Form1 () {
            con = new HubConnection("http://localhost:61660/signalr");
            prox = con.CreateHubProxy("chatHub");
            con.Start();
            InitializeComponent();
            prox.On<string , string>("onMessage" , ( name , message ) => listBox1.Invoke(new Action(() =>  listBox1.Items.Add(name + " : " + message))));
        }

        private void textBox2_TextChanged ( object sender , EventArgs e ) {

            prox.Invoke("newMessage" , textBox1.Text , textBox2.Text);
        }

        private void textBox3_TextChanged ( object sender , EventArgs e ) {
            prox.Invoke("joinGroup" , textBox1.Text , textBox3.Text);
        }

        private void button1_Click ( object sender , EventArgs e ) {
            prox.Invoke("sendGroup" , textBox1.Text , textBox3.Text , textBox2.Text);
        }
    }
}
