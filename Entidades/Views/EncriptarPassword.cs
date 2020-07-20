﻿using System.Security.Cryptography; // Libreria que se agregan si o si
using System.Text; // Libreria que se agregan si o si

namespace Entidades.Views
{
    /// <summary>
    /// La siguiente funcion sirve para realizar una encriptación.
    /// </summary>
    public class EncriptarPassword
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < 20; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
    }
}
