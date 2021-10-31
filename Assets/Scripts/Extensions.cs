using System.Text;

namespace Etched
{
    public static class Extensions
    {
        public static string OnlyLetters(this string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s) if (char.IsLetter(c)) sb.Append(c);
            
            return sb.ToString();
        }
    }
}