
using IpAddressAnalyzer.Classes;
using System.CommandLine;
using System.CommandLine.Parsing;

namespace IpAddressAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var SubnettingInfoCommand = new Command("SubnettingInfo")
            {
                Description = "A CLI Tool that provides Subnetting Information based on Ip-Address and SubnetMask"
            };

            var Ipv4Option = new Option<bool>("--ipv4")
            {
                IsRequired = false,
                IsHidden = false,
            };

            var Ipv6Option = new Option<bool>("--ipv6")
            {
                IsRequired = false,
                IsHidden = false,
            };

            SubnettingInfoCommand.AddOption(Ipv4Option);
            SubnettingInfoCommand.AddOption(Ipv6Option);


            var Parser = new Parser(SubnettingInfoCommand);
            var argOne = args[0];
            var Result = Parser.Parse(argOne);

            if (Result.Errors.Count > 0)
            {
                foreach (var err in Result.Errors)
                {
                    Console.WriteLine(err.ToString());
                }
                return;
            }

            if (Result.GetValueForOption(Ipv4Option))
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Enter An Ip Address and a Subnet Mask in the following Command Format: \n\nSubnettingInfo <--ipv4 | --ipv6> <Ip> <SubnetMask>\n\nExample: SubnettingInfo 192.168.10.183 255.255.240.0");
                }

                else
                {
                    string mainIp = args[1];
                    string mainSubnetMask = args[2];

                    byte[][] worker = Formater.IPV4.SplitAndConvert(mainIp, mainSubnetMask);
                    AddressContext ctx = new AddressContext(mainIp, mainSubnetMask);
                    ctx.SubnetMask = mainSubnetMask;
                    ctx.SubnetPrefix = Formater.IPV4.GetSubnettingPrefix(worker[1]);
                    ctx.NetworkAddress = Formater.IPV4.GetNetworkAddress(worker[0], worker[1]);
                    ctx.BroadcastAddress = Formater.IPV4.GetBroadCastAddress(worker[0], worker[1]);
                    ctx.TotalPossibleHosts = Formater.IPV4.GetSubnettingHostAmount(worker[0], worker[1]);

                    Console.WriteLine("\n" + ctx.ToString());
                }
            }

            if (Result.GetValueForOption(Ipv6Option))
            {
                Console.WriteLine("The SubnettingInfo CLI Tool is not yet equiped with Ipv6 Capabilities. Ipv6 will be added in the future!");
                return;
            }

        }
    }
}
