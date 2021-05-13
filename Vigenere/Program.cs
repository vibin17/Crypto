using System;
using System.Text;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = 'А'; //русская
            int width = 32;
            Console.WriteLine("Введите шифруемую строку");
            var str = String.Concat(Console.ReadLine().Split(new char[] { ' ' }));
            Console.WriteLine("Введите ключ");
            var key = Console.ReadLine();

            var encrypted = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
               encrypted.Append(Encrypt(str.Substring(i, 1), key[i % key.Length] - firstLetter, width, firstLetter));
            }
           
            Console.WriteLine(encrypted);

            var decrypted = new StringBuilder();
            for (int i = 0; i < encrypted.Length; i++)
            {
                decrypted.Append(Encrypt(encrypted.ToString().Substring(i, 1), width - (key[i % key.Length] - firstLetter), width, firstLetter));
            }
            Console.WriteLine(decrypted);
           
        }
        static string Encrypt(string str, int key, int width, int upStart)
        {
            var res = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                res.Append(Char.ToUpper((char)((str[i] + key) % upStart % width + upStart)));

            }
            return res.ToString();
        }
    }
}
