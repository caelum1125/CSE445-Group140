using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PasswordGenerator
{
   
    public class Service1 : IService1
    {
        public string GeneratePassword()
        {
            int length = 12;
            bool includeNumbers = true;
            bool includeSpecialChars = true;

            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specials = "!@#$%^&*()-_=+";

            string validChars = lowercase + uppercase;

            if (includeNumbers) validChars += numbers;
            if (includeSpecialChars) validChars += specials;

            byte[] randomBytes = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = validChars[randomBytes[i] % validChars.Length];
            }

            return new string(password);
        }
    }
}
