
using IpAddressAnalyzer.Classes;
using System.Diagnostics;
using System.Runtime.Serialization;


namespace IpAddressAnalyzer
{
    internal class Program
    {
        



        static void Main(string[] args)
        {
            var IpAddress = "192.168.100.10";
            var SubnetMask = "255.255.255.240";
            int[][] arr = Formater.SplitAndConvert(IpAddress, SubnetMask);

            Console.WriteLine(Formater.GetNetworkAddress(arr[0], arr[1]));

        }
    }
}