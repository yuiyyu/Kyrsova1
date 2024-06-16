using System.Security.Cryptography;
using System.Text;
using System;

public class SHA128
{
    public static string Hash(string input)
    {
        using (var sha128 = SHA1.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha128.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
