using System;
using System.Text;

namespace BCL.Utility.RandomString
{
    public class RandomStringsAndNumbers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [STAThread]
        public static string Generate()
        {
            //Generate a random number between 1000 and 9999.
            int intRandomNumber = GenerateRandomInteger(1000, 9999);
            //Generate a random string with the size of 16
            string strRandomString = GenerateRandomString(6);

            string str2 = strRandomString;
            return strRandomString.Substring(0, 4) + intRandomNumber.ToString() + str2.Substring(4);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intMin"></param>
        /// <param name="intMax"></param>
        /// <returns></returns>
        private static int GenerateRandomInteger(int intMin, int intMax)
        {
            //Create a new instance of the class Random
            Random randomNumber = new Random();
            //Generate a random number using intMin as the minimum and intMax as the maximum
            return randomNumber.Next(intMin, intMax);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intLenghtOfString"></param>
        /// <returns></returns>
        private static string GenerateRandomString(int intLenghtOfString)
        {
            //Create a new StrinBuilder that would hold the random string.
            StringBuilder randomString = new StringBuilder();
            //Create a new instance of the class Random
            Random randomNumber = new Random();
            //Create a variable to hold the generated charater.
            Char appendedChar;
            //Create a loop that would iterate from 0 to the specified value of intLenghtOfString
            for (int i = 0; i <= intLenghtOfString; ++i)
            {
                //Generate the char and assign it to appendedChar
                appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
                //Append appendedChar to randomString
                randomString.Append(appendedChar);
            }
            //Convert randomString to String and return the result.
            return randomString.ToString();
        }
    }
}
