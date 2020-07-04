using System;
using System.Diagnostics;

using NativeWifi;

namespace WLANBooster
{
    public class StartUp
    {
        private static void Main()
        {
            Console.WriteLine("Select 0 to disable WLAN autoconfig or 1 to enable it:");

            var command = string.Empty;
            int? option = null;

            while (string.IsNullOrWhiteSpace(command) && !option.HasValue)
            {
                command = Console.ReadLine();
                if (int.TryParse(command, out var result))
                {
                    option = result;
                }
                else
                {
                    Console.WriteLine("Invalid parameters. Try again.");
                }
            }

            var wlanClient = new WlanClient();

            foreach (var client in wlanClient.Interfaces)
            {
                if (option == 0)
                {
                    var cmdCommand = $@"/C netsh wlan set autoconfig enabled=no interface=""{client.InterfaceName}""";
                    Process.Start("CMD.exe", cmdCommand);
                }
                else if (option == 1)
                {
                    var cmdCommand = $@"/C netsh wlan set autoconfig enabled=yes interface=""{client.InterfaceName}""";
                    Process.Start("CMD.exe", cmdCommand);
                }
            }
        }
    }
}
