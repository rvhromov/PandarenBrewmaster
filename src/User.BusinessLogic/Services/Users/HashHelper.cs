using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace User.BusinessLogic.Services.Users
{
    public class HashHelper
    {
        public static string Create(string value, string salt)  
        {  
            byte[] valueBytes = KeyDerivation.Pbkdf2(  
                value,  
                Encoding.UTF8.GetBytes(salt),  
                KeyDerivationPrf.HMACSHA512,  
                10000,  
                256 / 8);  

            return Convert.ToBase64String(valueBytes);  
        }
        
        public static bool Validate(string value, string salt, string hash)  
            => Create(value, salt) == hash;
    }
}