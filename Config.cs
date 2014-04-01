using System;
using System.Collections.Generic;
using System.Text;

namespace PiBot
{
    static class Config
    {
        //Default emailID for notification(human's :))
        public static string DefaultEmailID = "<YOUR EMAIL ID>";

        //Bots email id
        public static string BotUserID = "<BOT's EMAIL ID";

        //Bots email password
        public static string BotPassword = "<BOT's EMAIL PASSWORD>";

        //XMPP server port, default is 5222
        public static int Port = 5222;

        //XMPP server, google's is xmpp.l.google.com
        public static string Server = "xmpp.l.google.com";

        //WebIOpi user id
        public static string WebIOPiUser = "webiopi";

        //WebIOpi password
        public static string WebIOPiPassword = "raspberry";

        //WebIOpi URI
        public static string WebIOPiURI = "http://localhost:8000/";



    }
}
