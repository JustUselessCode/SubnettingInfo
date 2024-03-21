
using IpAddressAnalyzer.Classes;

namespace IpAddressAnalyzer
{
    internal class Program
    {
        



        static void Main(string[] args)
        {
            var IpAddress = "192.168.10.183";
            var SubnetMask = "255.255.255.248";
            byte[][] arr = Formater.SplitAndConvert(IpAddress, SubnetMask);
            Address adr = new();
            adr.FirstOctet = arr[0][0];
            adr.SecondOctet = arr[0][1];
            adr.ThirdOctet = arr[0][2];
            adr.FourthOctet = arr[0][3];
            adr.SubnetMask = SubnetMask;
            adr.NetworkAddress = Formater.GetNetworkAddress(arr[0], arr[1]);


            Console.WriteLine("Network Address: " + Formater.GetNetworkAddress(arr[0], arr[1]));
            Console.WriteLine("Broadcast Address: " + Formater.GetBroadCastAddress(arr[0], arr[1]));

        }
    }
}