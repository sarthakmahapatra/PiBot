using System;
using System.Collections.Generic;
using System.Text;

namespace PiBot
{
    static class MessageProcessor
    {
        public static string Process(string message)
        {
            message = message.ToLower();

            string response;

            if (message == "hi")
            {
                return "Hello there!! How are you !!!";
            }
            else if (message.Contains("is the light on"))
            {
                response = PiGPIO.SendCommand("GPIO/4/function", "", MessageType.GET);

                if (response.ToUpper() == "IN")
                {
                    return "yes";
                }
                else
                {
                    return "no";
                }
            }
            else if (message.Contains( "turn on"))
            {
                response = PiGPIO.SendCommand("GPIO/4/function/IN", "", MessageType.POST);
                return "done, light is on";

            }
            else if (message.Contains("turn off"))
            {
                response = PiGPIO.SendCommand("GPIO/4/function/OUT", "", MessageType.POST);
                return "done, light is off";
            }

            return "Not sure what you mean.";
        }
    }




    enum MessageType
    {
        GET,
        POST
    }
}
