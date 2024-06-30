using System.Text;

namespace RunLengthEncoding
{
    public class RunLengthEncodingClass
    {
        /// <summary>
        /// Write a function that takes in a non-empty
        /// string and returns it's run-length encoding.
        /// From Wikipedia, "run-length encoding is a form
        /// of lossless data compression in which runs of
        /// data are stored as a single data value and count
        /// rather than as the original run". For this problem,
        /// a run of data is any sequence consecutive, identical
        /// characters. So the run "AAA" would be run-length-encoded
        /// as "3A".
        /// 
        /// To make things more complicated, however, the input string
        /// can contain all sorts of special characters, including numbers
        /// And since encoded data must be decodable, this means that
        /// we can't naively run-length-encode long runs. For example,
        /// the run "AAAAAAAAAAAA" (12A)s, can naively be decoded as "12A"
        /// sinc this string can be decoded as either "AAAAAAAAAAAA" or
        /// "1AA". Thus, long runs(runs of 10 or more characters) should
        /// be encoded in a split fashion; the aforementioned run should be
        /// encoded as "9A3A".
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns>String</returns>
        public string RunLengthEncoding(string stringArray)
        {
            //O(n) time | O(n) space - where n is the length of the input string
            StringBuilder stringBuilder = new StringBuilder();
            int currentLength = 1;
            for (int i = 1; i < stringArray.Length; i++)
            {
                char currentChar= stringArray[i];
                char previousChar= stringArray[i-1];    

                if ((currentChar != previousChar) ||  (currentLength == 9))
                {
                    stringBuilder.Append(currentLength.ToString());
                    stringBuilder.Append(previousChar);
                    currentLength =0;
                }

                currentLength += 1;
            }

            stringBuilder.Append(currentLength.ToString());

            stringBuilder.Append(stringArray[stringArray.Length -1]);

            return stringBuilder.ToString();
        }
    }
}