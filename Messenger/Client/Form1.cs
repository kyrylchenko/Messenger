using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form,MessengerService.IMessengerServiceCallback
    {
        int id;
        public Form1()
        {
            InitializeComponent();
            buttonDisconnect.Enabled = false;
        }
        MessengerService.MessengerServiceClient client ;
        public void CallBackMsg(string msg)
        {
            listBoxMessages.Items.Add(msg);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            client = new MessengerService.MessengerServiceClient(new System.ServiceModel.InstanceContext(this));
            textBoxUserName.ReadOnly = true;
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
           id =  client.Connect(textBoxUserName.Text);
           
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            textBoxUserName.Enabled = true;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            client.Disconnect(id);
            this.Close();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            client.SendMsg(textBoxMessage.Text, id);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
