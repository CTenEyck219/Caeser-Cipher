using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        // Statoc characters to be used by the offset to encrypt and decrypt the user
        // entered string
        static char[] chars =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z', '0', '1', '2', '3', '4', '5',
                '6', '7', '8', '9', 'A', 'B', 'C', 'D',
                'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', '!', '@',
                '#', '$', '%', '^', '&', '(', ')', '+',
                '-', '*', '/', '[', ']', '{', '}', '=',
                '<', '>', '?', '_', '"', '.', ',', ' '
            };

        static void Main(string[] args)
        {
            // Create empty string
            string text;

            // Initialize offset for Cipher
            int offset = 5;

            // Recieve user input to be encrypted
            Console.WriteLine("Please enter a string to be encrypted: ");
            text = Console.ReadLine();

            // Runs user input through the encryption and returns its value
            string encrypt = Encryption(text, offset);
            Console.WriteLine("Encrypted Text: " + encrypt);

            // Recieve user input for decryption
            Console.WriteLine("Please enter the string you would like to have decrypted: ");
            text = Console.ReadLine();

            // Runs user input through decryption and returns its value
            string decrypt = Decryption(text, offset);
            Console.WriteLine("Decrypted Text: " + decrypt);

            Console.ReadLine();

        }//end of main

        // Method that does the Encryption using Caesar Cipher
        static string Encryption(string text, int offset)
        {
            // Changes string text to an array for manipulation
            char[] normal = text.ToCharArray();


            for (int i = 0; i < normal.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if (j <= chars.Length - offset)
                    {
                        if (normal[i] == chars[j])
                        {
                            normal[i] = chars[j + offset];
                            break;
                        }
                    }//end of if
                    else if (normal[i] == chars[j])
                    {
                        normal[i] = chars[j - (chars.Length - offset + 1)];
                    }//end of else if
                }//end of for loop j
            }//end of for loop i

            return new string(normal);

        }//end of method Encryption

        static string Decryption(string text, int offset)
        {
            char[] cipher = text.ToCharArray();

            for(int i = 0; i < cipher.Length; i++)
            {
                for(int j = 0; i < chars.Length; j++)
                {
                    if(j >= offset && cipher[i] == chars[j])
                    {
                        cipher[i] = chars[j - offset];
                        break;
                    }//emd if
                    if(cipher[i] == chars[j] && j < offset)
                    {
                        cipher[i] = chars[(chars.Length - offset + 1) +j];
                        break;
                    }//end if
                }//end for loop j
            }//end for loop i

            return new string(cipher);

        }// end of method Decryption
    }//end of class program
}//end of Caesar Cipher