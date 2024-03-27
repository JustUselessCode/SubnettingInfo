
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
        }
    }
}
