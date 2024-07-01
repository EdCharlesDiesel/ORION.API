using System;
using System.Collections.Generic;
using System.Text;

namespace ORION.Core.Strings
{
    /// <summary>
    /// You're given a string of length 12 or smaller, containing
    /// only digits. Write a function that returns all the possible
    /// IP addresses that can be created by inserting three .s in the
    /// string.
    /// 
    /// An IP address is a sequence of four positive integers that
    /// are separated by .s, where each individual integer is within
    /// range 0 - 255, inclusive.
    /// 
    /// An IP address isn't if any of the individua integers contains
    /// leading 0s. For example, "192.168.0.1" is a valid IP address,
    /// but "192.168.00.1" and "192.168.0.01" aren't, because they
    /// contain "00" and 01, respectively. Another example of a valid
    /// IP address is "99.1.1.10"; conversely, "991.1.1.10" isn't valid
    /// , because "991" is greater than 255.
    /// 
    /// Your function should return the IP addresses in string format
    /// and in no particular order. If no valid IP address can be created
    /// from the string , your function should  return an empty list.
    /// 
    /// </summary>
    public class ValidIPAddressesClass
    {
        public List<string> ValidIPAddresses(string input)
        {
            List<string> ipAddressesFound = new List<string>();
            for (int i = 1; i < Math.Min((int)input.Length, 4); i++)
            {
                string[] currentIpAddressPart = new string[] { "", "", "", "" };
                currentIpAddressPart[0] = input.Substring(0, i - 0);
                if (!ValidPart(currentIpAddressPart[0]))
                {
                    continue;
                }

                for (int j = i + 1; j < i + Math.Min((int)input.Length - 1, 4); j++)
                {
                    currentIpAddressPart[1] = input.Substring(i, j - i);
                    if (!ValidPart(currentIpAddressPart[1]))
                    {
                        continue;
                    }
                    for (int k = j + 1; k < j + Math.Min((int)input.Length - j, 4); k++)
                    {
                        currentIpAddressPart[2] = input.Substring(j, k - j);
                        currentIpAddressPart[3] = input.Substring(k);
                        if (ValidPart(currentIpAddressPart[2]) && ValidPart(currentIpAddressPart[3]))
                        {
                            ipAddressesFound.Add(Join(currentIpAddressPart));
                        }
                    }
                }
            }

            return ipAddressesFound;
        }

        private string Join(string[] currentIpAddressPart)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < currentIpAddressPart.Length; i++)
            {
                stringBuilder.Append(currentIpAddressPart[i]);
                if (i < currentIpAddressPart.Length - 1)
                {
                    stringBuilder.Append('.');

                }
            }
            return stringBuilder.ToString();
        }

        private bool ValidPart(string v)
        {
            int stringAsInt = Int32.Parse(v);
            if (stringAsInt > 255)
            {
                return false;
            }

            return v.Length == stringAsInt.ToString().Length; // Check for leading 0
        }
    }
}