using System;
using System.Text;

namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = 'А'; //русская
            int width = 32;
            Console.WriteLine("Введите ключ");
            int k = Convert.ToInt32(Console.ReadLine()) % width;
            Console.WriteLine("Введите шифруемую строку");
            var str = Console.ReadLine();

            var encrypted = Encrypt(str, k, width, firstLetter);
            
            Console.WriteLine(encrypted);

            var decrypted = Encrypt(encrypted, width - k, width, firstLetter);
            Console.WriteLine(decrypted);

        }
        static string Encrypt(string str, int key, int width, int upStart)
        {
            var res = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    res.Append(' ');

                else
                    res.Append(Char.ToUpper((char)((str[i] + key) % upStart % width + upStart)));
            }
            return res.ToString();
        }
    }
}
