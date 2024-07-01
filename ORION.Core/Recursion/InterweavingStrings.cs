using System;

namespace InterweavingStrings
{
    /// <summary>
    /// Write a function that takes in three strings and returns a boolean representing whether 
    /// the third string can be formed by interweaving  the first two string.
    /// 
    /// To interweave strings means to merge them by alternating their letters without any specific
    /// pattern. For instance, the strings "abc"
    /// and "123" can be interwoven as "a1b2c3", as "abc123" (this list is nonexhaustive).
    /// 
    /// Letters within a string must maintain their relative ordering in the interwoven string.
    /// </summary>
    public class InterweavingStrings
    {
        public static bool Interweavingstrings(string one, string two, string three)
        {
            if (three.Length != one.Length + two.Length) {
            return false;
            }

            return areInterwoven(one, two,three, 0, 0);
        }

        public static bool areInterwoven(string one, string two,string three, int i, int j)
        {
            int k = i +j;
            if (k ==three.Length) {
            return true;
            }

            if (i < one.Length && one[i] == three[k])
            {
                if (areInterwoven(one,two,three,i +1,j))
                {
                    return true;
                }
            }

            if (j< two.Length && two[j] == three[k])
            {
                return areInterwoven(one, two, three, i, j + 1);
            }

            return false;
        }
    }
}