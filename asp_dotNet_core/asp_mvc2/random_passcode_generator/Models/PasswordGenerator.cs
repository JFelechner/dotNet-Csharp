

using System;
using System.Text;

namespace random_passcode_generator.Models
{
    public class generatePassword
    {
        public char[] passwordValues = new char[] {'1','2','3','4','5','6','7','8','9','0','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','!','@','#','$','%','&','*'};
        public string suggestedPassword {get;set;} = "";
        public int numberOfPasscodes {get;set;} = 0;

        public void Generate(int length){
            Random rand = new Random();
            StringBuilder password = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                password.Append(passwordValues[rand.Next(passwordValues.Length)]);
            }
            suggestedPassword  = password.ToString();
            numberOfPasscodes ++;
            Console.WriteLine("Suggested Password: " + suggestedPassword);
        }
    }
}