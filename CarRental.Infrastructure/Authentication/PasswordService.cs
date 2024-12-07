using CarRental.Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Authentication
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string newHashedPassword = HashPassword(password);

            return string.Equals(hashedPassword, newHashedPassword);
        }
    }
}
