using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;

namespace PiBot
{
    static class PiGPIO
    {
        public static string SendCommand(string cmd, string param, MessageType type)
        {
            string response = "";

            using (var wb = new WebClient())
            {
                NetworkCredential cred = new NetworkCredential(Config.WebIOPiUser, Config.WebIOPiPassword);
                wb.Credentials = cred;

                Console.WriteLine("Sending command to  Pi " + Config.WebIOPiURI + cmd);

                if (type == MessageType.GET)
                {
                    response = wb.DownloadString(Config.WebIOPiURI + cmd);
                }
                else if(type == MessageType.POST)
                {
                    var data = new NameValueCollection();

                    data["username"] = "webiopi";
                    data["password"] = "raspberry";

                    var result = wb.UploadValues(Config.WebIOPiURI + cmd, data);
                    response = Encoding.Default.GetString(result);
                }
            }

            Console.WriteLine("Received response from Pi : " + response);

            return response;
        }
    }
}
