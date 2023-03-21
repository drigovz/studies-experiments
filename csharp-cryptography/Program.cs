using System;
using System.Text;
using CSCriptography.Entities;

namespace CSCriptography
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "V3ryC0mpl3xP455w0rd";
            byte[] salt = Hashs.GenerateSalt();

            Console.WriteLine($"Password: { password }");
            Console.WriteLine($"Salt: { Convert.ToBase64String(salt) }");
            Console.WriteLine();

            // salt + password
            var hashedPassword1 = Hashs.HashPasswordWithSalt(
                Encoding.UTF8.GetBytes(password),
                salt
            );

            // show the password with salt
            Console.WriteLine($"Password with salt: { Convert.ToBase64String(hashedPassword1) }");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
