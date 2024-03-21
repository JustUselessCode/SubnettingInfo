
using System;
using System.Collections;
using System.Text;
namespace IpAddressAnalyzer.Classes
{
    internal class Formater
    {
        public static byte[][] SplitAndConvert(string IpAddr, string SubMask)
        {
            string[] IpWorker = IpAddr.Split('.');
            string[] SubnetWorker = SubMask.Split('.');

            byte[] IpNums = new byte[IpWorker.Length];
            byte[] SubNums = new byte[SubnetWorker.Length];

            for (int i = 0; i < IpWorker.Length; i++)
            {
                IpNums[i] = (byte) Convert.ToInt32(IpWorker[i]);
            }

            for (int i = 0; i < SubnetWorker.Length; i++)
            {
                SubNums[i] = (byte) Convert.ToInt32(SubnetWorker[i]);
            }

            return new byte[2][] { IpNums, SubNums };
        }


        public static string GetNetworkAddress(byte[] _IpParts, byte[] _SubnetmaskParts)
        {
            if (_IpParts.Length != _SubnetmaskParts.Length && _IpParts.Length == 4)
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
            if (_IpParts.Length != _SubnetMaskParts.Length && _IpParts.Length == 4)
            {
                throw new ArgumentException("Die beiden Addressen müssen gleich lang sein!");
            }

            StringBuilder BroadcastAddress = new();

            byte[] invertedSubnetMaskParts = Helper.InvertSubnetMask(_SubnetMaskParts);

            for (int i = 0; i < invertedSubnetMaskParts.Length; i++)
            {
                BroadcastAddress.Append((invertedSubnetMaskParts[i] | _IpParts[i]).ToString() + ".");

                if (i == invertedSubnetMaskParts.Length - 1)
                {
                    BroadcastAddress.Remove(BroadcastAddress.Length - 1, 1);
                }
            }

            return BroadcastAddress.ToString();
        }

        public static uint GetSubnettingHostAmount(byte[] _IpParts, byte[] _SubnetParts)
        {
            if (_IpParts.Length != _SubnetParts.Length && _IpParts.Length == 4)
            {
                throw new ArgumentException("The Addresses must be the same Size!");
            }

            uint _TotalHostNumber = 0;

            for (int i = 0; i < _IpParts.Length; i++)
            {
                if (_SubnetParts[i] != 255)
                {
                    // Currently only works for the last Octet
                    // TODO: Fix implementation to support SubnetMasks with a value of e.g "255.255.240.0"
                    uint _CurrentHostNumber = (uint)(_IpParts[i] / (256 - _SubnetParts[i]) * (256 - _SubnetParts[i]));
                    _TotalHostNumber += _CurrentHostNumber;
                }
            }

            return _TotalHostNumber;
        }
    }
}
