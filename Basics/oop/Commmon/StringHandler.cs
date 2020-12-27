using System;

namespace Commmon
{
    ///<summary>
    ///Insert spaces before each capital leter in the string
    ///</summary>
    ///<param name="string"></param>
    ///<returns></returns>
    public static class StringHandler
    {
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;

            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
            }
            return result.Trim();
        }
    }
}
