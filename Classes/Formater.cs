
using System;
using System.Collections;
using System.Text;
namespace IpAddressAnalyzer.Classes
{
    internal class Formater
    {
        public static int[][] SplitAndConvert(string IpAddr, string subMask)
        {
            string[] ipWorker = IpAddr.Split('.');
            string[] subnetWorker = subMask.Split('.');

            int[] ipNums = new int[ipWorker.Length];
            int[] subNums = new int[subnetWorker.Length];

            for (int i = 0; i < ipWorker.Length; i++)
            {
                ipNums[i] = Convert.ToInt32(ipWorker[i]);
            }

            for (int i = 0; i < subnetWorker.Length; i++)
            {
                subNums[i] = Convert.ToInt32(subnetWorker[i]);
            }

            return new int[2][] { ipNums, subNums };
        }

        
        public static string GetNetworkAddress(int[] ipParts, int[] subnetmaskParts)
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
                    //byte IpByte = Convert.ToByte(ipParts[i]);
                    //byte SubnetByte = Convert.ToByte(subnetmaskParts[i]);
                    byte NetworkAddressByte = 0;
                    string NetworkAddressByteString;

                    for (int j = 0; j < 8; j++)
                    {
                        if (Helper.IsBitSet((byte)subnetmaskParts[i], j))
                        {
                            NetworkAddressByte |= (byte)(1 << j);
                        }

                        else
                        {
                            NetworkAddressByte |= (byte)(0 << j);
                        }
                    }

                    NetworkAddress.Append(Helper.ConvertBinToDez(NetworkAddressByte) + ".").Remove(NetworkAddress.Length - 1, 1);
                }
                
            }

            return NetworkAddress.ToString();
        }
    }
}
