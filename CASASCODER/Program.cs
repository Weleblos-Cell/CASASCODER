

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string c1 = "T";
        string c2 = "-+";
        string c3 = "┴";
        string c4 = "╪";

        //string c1 = "†";
        //string c2 = "⸸";
        //string c3 = "┴";
        //string c4 = "╪";

        Dictionary<string, char> casasmap = new Dictionary<string, char>
        {
            { c1 + c1 + c1, 'A' }, // TTT 
            { c2 + c1 + c1, 'B' }, // -+TT
            { c1 + c2 + c1, 'C' }, // T-+T  
            { c1 + c1 + c2, 'D' }, // TT-+ 
            { c1 + c2 + c2, 'E' }, // T-+-+  
            { c2 + c1 + c2, 'F' }, // -+T-+  
            { c2 + c2 + c1, 'G' }, // -+-+T 
            { c3 + c1 + c1, 'H' }, // ┴TT 
            { c1 + c3 + c1, 'I' }, // T┴T 
            { c1 + c1 + c3, 'J' }, // TT┴  
            { c3 + c1 + c3, 'K' }, // ┴T┴  
            { c4 + c1 + c1, 'L' }, // ╪TT
            { c1 + c4 + c1, 'M' }, // T╪T 
            { c1 + c1 + c4, 'N' }, // TT╪  
            { c1 + c4 + c4, 'O' }, // T╪╪  
            { c4 + c1 + c4, 'P' }, // ╪T╪  
            { c2 + c4 + c1, 'Q' }, // ╪T
            { c1 + c2 + c4, 'R' }, // T-+╪  
            { c2 + c1 + c3, 'S' }, // -+T┴  
            { c4 + c2 + c1, 'T' }, // ╪-+T 
            { c1 + c4 + c2, 'U' }, // T╪-+ 
            { c2 + c1 + c4, 'V' }, // -+T╪  
            { c2 + c2 + c2, 'W' }, // -+-+-+  
            { c3 + c2 + c2, 'X' }, // ┴-+-+ 
            { c2 + c3 + c2, 'Y' }, // -+┴-+  
            { c2 + c2 + c3, 'Z' }, // -+-+┴  
  
            // Знаки препинания  
            { c2 + c3 + c3, ' ' }, // -+┴┴  
            { c4 + c4 + c4, '-' }, // ╪╪╪  
            { c3 + c4 + c4, ',' }, // ┴╪╪  
            { c3 + c3 + c3, '.' }, // ┴┴┴  
            { c3 + c3 + c4, '!' }, // ┴┴╪  
  
            // Цифры (БЕЗ НУЛЯ ХИХИХХАХАХЫЭЫЭЫХАХАХ) 
            { c1 + c4 + c3, '1' }, // T╪┴  
            { c3 + c4 + c3, '2' }, // ┴╪┴  
            { c3 + c4 + c1, '3' }, // ┴╪T
            { c3 + c3 + c1, '4' }, // ┴┴T  
            { c3 + c3 + c2, '5' }, // ┴┴-+  
            { c4 + c3 + c3, '6' }, // ╪┴┴  
            { c3 + c4 + c2, '7' }, // ┴╪-+  
            { c2 + c3 + c4, '8' }, // -+┴╪  
            { c3 + c2 + c4, '9' },  // ┴-+╪
 
 
        };

        Dictionary<char, string> reverseCasasmap = new Dictionary<char, string>();
        foreach (var pair in casasmap)
        {
            reverseCasasmap[pair.Value] = pair.Key;
        }

        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("0 — Зашифровать");
        Console.WriteLine("1 — Дешифровать");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 0)
        {
            Console.WriteLine("Введите строку для шифрования:");
            string input = Console.ReadLine();
            string encrypted = "";

            foreach (char ch in input)
            {
                if (casasmap.ContainsValue(ch))
                {
                    encrypted += reverseCasasmap[ch];
                }
                else
                {
                    encrypted += ch;
                }
            }

            Console.WriteLine("Зашифрованная строка: " + encrypted);
        }
        else if (choice == 1)
        {
            Console.WriteLine("Введите строку для дешифрования:");
            string input = Console.ReadLine();
            string decrypted = "";
            string temp = "";

            foreach (char ch in input)
            {
                temp += ch;

                if (casasmap.ContainsKey(temp))
                {
                    decrypted += casasmap[temp];
                    temp = "";
                }
                else if (ch == ' ')
                {
                    decrypted += " ";
                    temp = "";
                }
                else if (temp.Length > 5)
                {
                    decrypted += "?";
                    temp = "";
                }
            }

            Console.WriteLine("Дешифрованная строка: " + decrypted);
        }
        else
        {
            Console.WriteLine("Неверный выбор.");
        }
    }
}