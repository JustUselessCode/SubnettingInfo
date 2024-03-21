
using System;
using System.Collections;
using System.Text;
namespace IpAddressAnalyzer.Classes
{
    internal class Formater
    {
        public static byte[][] SplitAndConvert(string IpAddr, string subMask)
        {
            string[] ipWorker = IpAddr.Split('.');
            string[] subnetWorker = subMask.Split('.');

            byte[] ipNums = new byte[ipWorker.Length];
            byte[] subNums = new byte[subnetWorker.Length];

            for (int i = 0; i < ipWorker.Length; i++)
            {
                ipNums[i] = (byte) Convert.ToInt32(ipWorker[i]);
            }

            for (int i = 0; i < subnetWorker.Length; i++)
            {
                subNums[i] = (byte) Convert.ToInt32(subnetWorker[i]);
            }

            return new byte[2][] { ipNums, subNums };
        }


        public static string GetNetworkAddress(byte[] ipParts, byte[] subnetmaskParts)
        {
            if (ipParts.Length != subnetmaskParts.Length)
            {
                throw new ArgumentException("Die beiden Adressen müssen gleich lang sein!");
            }

            StringBuilder NetworkAddress = new StringBuilder();

            for (int i = 0; i < ipParts.Length; i++)
            {
                if (subnetmaskParts[i] == 255)
                {
                    NetworkAddress.Append(ipParts[i].ToString() + ".");
                }

                else
                {
                    var NetworkAddressByte = ipParts[i] & subnetmaskParts[i];

                    NetworkAddress.Append(NetworkAddressByte.ToString() + ".");

                    if (i == ipParts.Length - 1)
                    {
                        NetworkAddress.Remove(NetworkAddress.Length - 1, 1);
                    }
                }

            }

            return NetworkAddress.ToString();
        }

        public static string GetBroadCastAddress(byte[] ipParts, byte[] subnetMaskParts)
        {
            if (ipParts.Length != subnetMaskParts.Length)
            {
                throw new ArgumentException("Die beiden Addressen müssen gleich lang sein!");
            }

            StringBuilder BroadcastAddress = new();

            byte[] invertedSubnetMaskParts = Helper.InvertSubnetMask(subnetMaskParts);

            for (int i = 0; i < invertedSubnetMaskParts.Length; i++)
            {
                BroadcastAddress.Append((invertedSubnetMaskParts[i] | ipParts[i]).ToString() + ".");

                if (i == invertedSubnetMaskParts.Length)
                {
                    BroadcastAddress.Remove(BroadcastAddress.Length - 1, 1);
                }
            }

            return BroadcastAddress.ToString();
        }
    }
}
