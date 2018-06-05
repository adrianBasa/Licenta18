using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
namespace TelecomDataBase
{
    public class Helper
    {
        public static byte[] GetHashPass(string pass, byte[] salt)
        {
            //Convertim stringul în array de bytes. 
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(pass);
            
            // lipim salt-ul înainte de hashare
            byte[] combinedBytes = new byte[passBytes.Length + salt.Length];
            Buffer.BlockCopy(passBytes, 0, combinedBytes, 0, passBytes.Length);
            Buffer.BlockCopy(salt, 0, combinedBytes, passBytes.Length, salt.Length);
            
            //Genereaza hash pentru parola+salt
            HashAlgorithm algoritmHashare = new SHA256Managed();
            byte[] hash = algoritmHashare.ComputeHash(combinedBytes);
            
            //lipim saltul la  hash
            byte[] hashPlusSalt = new byte[hash.Length + salt.Length];
            Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hash.Length);
            Buffer.BlockCopy(salt, 0, hashPlusSalt, hash.Length, salt.Length);

            return hashPlusSalt;
        }

        public static byte[] GenerateSalt()
        {
           byte[] salt = new byte[32];
           System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(salt);
           return salt;
        }

    }
       
}