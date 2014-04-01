using System;
using System.Collections.Generic;
using System.Text;
using agsXMPP;
using System.Text.RegularExpressions;
using System.Net;

namespace PiBot
{
    class Program
    {
        static XmppClientConnection xmppCon = new XmppClientConnection();

        static void Main(string[] args)
        {
            xmppCon.OnLogin += new ObjectHandler(xmppCon_OnLogin);
            xmppCon.OnRosterStart += new ObjectHandler(xmppCon_OnRosterStart);
            xmppCon.OnRosterEnd += new ObjectHandler(xmppCon_OnRosterEnd);
            xmppCon.OnRosterItem += new XmppClientConnection.RosterHandler(xmppCon_OnRosterItem);
            xmppCon.OnPresence += new agsXMPP.protocol.client.PresenceHandler(xmppCon_OnPresence);
            xmppCon.OnAuthError += new XmppElementHandler(xmppCon_OnAuthError);
            xmppCon.OnError += new ErrorHandler(xmppCon_OnError);
            xmppCon.OnClose += new ObjectHandler(xmppCon_OnClose);
            xmppCon.OnMessage += new agsXMPP.protocol.client.MessageHandler(xmppCon_OnMessage);

            Login();

            while (true)
            {
                string messg = Console.ReadLine();

                if (messg != null && messg != string.Empty)
                    Send(messg, Config.DefaultEmailID);
            }
        }

        static void xmppCon_OnLogin(object sender)
        {

            Console.WriteLine("OnLogin");

            Send("This is Pi Bot. I am up.", Config.DefaultEmailID);

        }
        static private void Send(string txt, string user)
        {
            // Send a message
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
            msg.Type = agsXMPP.protocol.client.MessageType.chat;
            msg.To = new Jid(user);
            msg.Body = txt;

            xmppCon.Send(msg);
        }

        static void Login()
        {
            Jid jidUser = new Jid(Config.BotUserID);
            xmppCon.Username = jidUser.User;
            xmppCon.Server = jidUser.Server;
            xmppCon.Password = Config.BotPassword;
            xmppCon.AutoResolveConnectServer = false;
            xmppCon.Port = Config.Port;
            xmppCon.ConnectServer = Config.Server;

            xmppCon.Open();
        }

        static void xmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            // ignore empty messages (events)
            if (msg.Body == null)
                return;

            Console.WriteLine(String.Format("OnMessage from:{0} type:{1}", msg.From.Bare, msg.Type.ToString()));
            Console.WriteLine(msg.Body);

            var response = MessageProcessor.Process(msg.Body);

            Send(response, msg.From.Bare);

        }

        static void xmppCon_OnClose(object sender)
        {

            Console.WriteLine("OnClose Connection closed");

        }

        static void xmppCon_OnError(object sender, Exception ex)
        {

            Console.WriteLine(ex.StackTrace);

        }

        static void xmppCon_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {

            Console.WriteLine("OnAuthError");

        }

        static void xmppCon_OnPresence(object sender, agsXMPP.protocol.client.Presence pres)
        {
            Console.WriteLine(String.Format("Received Presence from:{0} show:{1} status:{2}", pres.From.ToString(), pres.Show.ToString(), pres.Status));

        }

        static void xmppCon_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            Console.WriteLine(String.Format("Received Contact {0}", item.Jid.Bare));
        }

        static void xmppCon_OnRosterEnd(object sender)
        {
            Console.WriteLine("OnRosterEnd");


            // Send our own presence to teh server, so other epople send us online
            // and the server sends us the presences of our contacts when they are
            // available
            xmppCon.SendMyPresence();
        }

        static void xmppCon_OnRosterStart(object sender)
        {
            Console.WriteLine("OnRosterStart");

        }


    }
}
