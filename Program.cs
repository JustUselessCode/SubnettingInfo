
using IpAddressAnalyzer.Classes;

namespace IpAddressAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                try
                {
                    throw new ArgumentException("Enter An Ip Address and a Subnet Mask in the following Command Format: \n\nSubnettingInfo <Ip> <SubnetMask>\n\nExample: SubnettingInfo 192.168.10.183 255.255.240.0");
                }

                catch (ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }

            else
            {
                var mainIp = args[0];
                var mainSubnetMask = args[1];

                byte[][] worker = Formater.SplitAndConvert(mainIp, mainSubnetMask);
                AddressContext ctx = new AddressContext(worker[0][0], worker[0][1], worker[0][2], worker[0][3]);
                ctx.SubnetMask = mainSubnetMask;
                ctx.SubnetPrefix = Formater.GetSubnettingPrefix(worker[1]);
                ctx.NetworkAddress = Formater.GetNetworkAddress(worker[0], worker[1]);
                ctx.BroadcastAddress = Formater.GetBroadCastAddress(worker[0], worker[1]);
                ctx.TotalPossibleHosts = Formater.GetSubnettingHostAmount(worker[0], worker[1]);


                Console.WriteLine("\n" + ctx.ToString());
            }

            // FOR TESTING AND DEMONSTARTION PURPOSES ONLY

            //var IpAddress = "192.168.10.183";
            //var SubnetMask = "255.255.255.240";
            //var SubnetMask2 = "255.255.240.0";

            //byte[][] arr = Formater.SplitAndConvert(IpAddress, SubnetMask);
            //byte[][] arr2 = Formater.SplitAndConvert(IpAddress, SubnetMask2);

            //AddressContext adr = new();
            //adr.FirstOctet = arr[0][0];
            //adr.SecondOctet = arr[0][1];
            //adr.ThirdOctet = arr[0][2];
            //adr.FourthOctet = arr[0][3];
            //adr.SubnetMask = SubnetMask;
            //adr.NetworkAddress = Formater.GetNetworkAddress(arr[0], arr[1]);
            //adr.BroadcastAddress = Formater.GetBroadCastAddress(arr[0], arr[1]);
            //adr.TotalPossibleHosts = Formater.GetSubnettingHostAmount(arr[0], arr[1]);

            //AddressContext adr2 = new(arr2[0][0], arr2[0][1], arr2[0][2], arr2[0][3]);
            //adr2.SubnetMask = SubnetMask2;
            //adr2.NetworkAddress = Formater.GetNetworkAddress(arr2[0], arr2[1]);
            //adr2.BroadcastAddress = Formater.GetBroadCastAddress(arr2[0], arr2[1]);
            //adr2.TotalPossibleHosts = Formater.GetSubnettingHostAmount(arr2[0], arr2[1]);

            //Console.WriteLine(adr.ToString());

            //Console.WriteLine("\n" + adr2.ToString());

        }
    }
}
