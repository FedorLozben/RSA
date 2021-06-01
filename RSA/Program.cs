using System;
using RSA_Fedor_lib;

namespace RSA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //crypto_f cr = new crypto_f();
            RSA_Fedor_lib_object cr = new RSA_Fedor_lib_object();
            int max = 500;
            bool[] public_key = new bool[max];
            bool[] private_key = new bool[max];
            bool[] n = new bool[max];
            bool[] msg = new bool[max];

            cr.generate_keys_correct(public_key, private_key, n, 30, 10);
            Console.Write("          n:"); cr.draw(n); Console.WriteLine("");
            Console.Write(" public key:"); cr.draw(public_key); Console.WriteLine("");
            Console.Write("private key:"); cr.draw(private_key); Console.WriteLine("");

            char[] text = new char[100];
            char[] text1 = new char[100];
            text1[0] = '\0';
            text[0] = 'h';
            text[1] = 'e';
            text[2] = 'l';
            text[3] = 'l';
            text[4] = 'o';
            text[5] = 'Y';
            text[6] = 'O';
            text[7] = '\0';


            cr.text_to_binar(text, msg);
            Console.WriteLine("___");
            Console.Write("TEXT:");
            Console.WriteLine(text);

            Console.WriteLine("");
            Console.Write("Binary:");
            cr.draw(msg);
            Console.WriteLine("");
            Console.Write("Binary coded:");
            cr.code(msg, public_key, n);
            cr.draw(msg);
            Console.WriteLine("");
            Console.Write("Binary decoded:");
            cr.decode(msg, private_key, n);
            cr.draw(msg);

            Console.WriteLine("");
            Console.Write("Text:");
            cr.binar_to_text(msg, text);
            Console.WriteLine(text);

            text1[0] = '\0';
            text[0] = 'h';
            text[1] = 'e';
            text[2] = 'l';
            text[3] = 'l';
            text[4] = 'o';
            text[5] = 'Y';
            text[6] = 'O';
            text[7] = 'W';
            text[8] = 'h';
            text[9] = 'o';
            text[10] = 'a';
            text[11] = 't';
            text[12] = 'o';
            text[13] = 'l';
            text[14] = 'd';
            text[15] = 'R';
            text[16] = 'E';
            text[17] = 'N';
            text[18] = 'E';
            text[19] = 'E';
            text[20] = '\0';

            Console.WriteLine("");

            cr.maxblock = 3;
            while (text[0] != '\0')
            {
                cr.text_dir(text);
                cr.text_connect(text1);
                Console.Write("out:"); Console.WriteLine(text);
                Console.Write(" in:"); Console.WriteLine(text1);
                Console.WriteLine("");
            }

            while (true) { }

        }
    }
}