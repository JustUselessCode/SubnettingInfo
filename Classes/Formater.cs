using System.Text;

namespace IpAddressAnalyzer.Classes
{
    internal static class Formater
    {
        internal static class IPV4
        {
            public static byte[][] SplitAndConvert(string IpAddr, string SubMask)
            {
                if (IpAddr.Length > 15 || SubMask.Length > 15)
                {
                    throw new ArgumentException("Invalid Length of IPv4 Address and/ or Subnet Mask!");
                }

                string[] IpWorker = IpAddr.Split('.');
                string[] SubnetWorker = SubMask.Split('.');

                byte[] IpNums = new byte[IpWorker.Length];
                byte[] SubNums = new byte[SubnetWorker.Length];

                for (int i = 0; i < IpWorker.Length; i++)
                {
                    IpNums[i] = Convert.ToByte(IpWorker[i]);
                }

                for (int i = 0; i < SubnetWorker.Length; i++)
                {
                    SubNums[i] = Convert.ToByte(SubnetWorker[i]);
                }

                return new byte[2][] { IpNums, SubNums };
            }


            public static string GetNetworkAddress(byte[] _IpParts, byte[] _SubnetmaskParts)
            {
                if (_IpParts.Length != _SubnetmaskParts.Length || _IpParts.Length != 4)
                {
                    throw new ArgumentException("The Addresses must be the same Size!");
                }

                StringBuilder NetworkAddress = new StringBuilder();

                for (int i = 0; i < _IpParts.Length; i++)
                {
                    if (_SubnetmaskParts[i] == 255)
                    {
                        NetworkAddress.Append(_IpParts[i].ToString() + ".");
                    }

                    else
                    {
                        var NetworkAddressByte = _IpParts[i] & _SubnetmaskParts[i];

                        NetworkAddress.Append(NetworkAddressByte.ToString() + ".");

                        if (i == _IpParts.Length - 1)
                        {
                            NetworkAddress.Remove(NetworkAddress.Length - 1, 1);
                        }
                    }

                }

                return NetworkAddress.ToString();
            }

            public static string GetBroadCastAddress(byte[] _IpParts, byte[] _SubnetMaskParts)
            {
                if (_IpParts.Length != _SubnetMaskParts.Length || _IpParts.Length != 4)
                {
                    throw new ArgumentException("The Addresses must be the same Size!");
                }

                StringBuilder BroadcastAddress = new();

                byte[] invertedSubnetMaskParts = Helper.InvertSubnetMask(_SubnetMaskParts);

                for (int i = 0; i < invertedSubnetMaskParts.Length; i++)
                {
                    var BroadCastByte = invertedSubnetMaskParts[i] | _IpParts[i];

                    BroadcastAddress.Append(BroadCastByte.ToString() + ".");

                    if (i == invertedSubnetMaskParts.Length - 1)
                    {
                        BroadcastAddress.Remove(BroadcastAddress.Length - 1, 1);
                    }
                }

                return BroadcastAddress.ToString();
            }

            public static uint GetSubnettingHostAmount(byte[] _IpParts, byte[] _SubnetParts)
            {
                if (_IpParts.Length != _SubnetParts.Length || _IpParts.Length != 4)
                {
                    throw new ArgumentException("The Addresses must be the same Size!");
                }

                var formula = (uint number) =>
                {
                    return (Math.Pow(2, number) - 2);
                };

                uint bits = Helper.CalculateNumberOfHostBits(_SubnetParts);

                return (uint)formula(bits);
            }

            public static string GetSubnettingPrefix(byte[] subnetMask)
            {
                return $"/{Helper.CalculateNumberOfHostBits(subnetMask)}";
            }
        }
        
        public static class IPV6
        {

        }
    }
}
