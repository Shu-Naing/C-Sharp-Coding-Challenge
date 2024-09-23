using System;
using System.Collections.Generic;

public class OldPhonePad
{
    private static readonly Dictionary<char, string> keypad = new Dictionary<char, string>
    {
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" }
    };

    public static string OldPhonePadInput(string input)
    {
        string result = "";  
        char lastKey = '\0'; 
        int pressCount = 0;  

        foreach (char c in input)
        {
            if (c == '#')
            {
                break;
            }
            else if (c == '*')
            {
                if (result.Length > 0)
                {
                    result = result.Remove(result.Length - 1);
                }
            }
            else if (c == ' ')
            {
                lastKey = '\0';
                pressCount = 0;
            }
            else if (char.IsDigit(c) && c != '0' && c != '1')
            {
                if (c == lastKey)
                {
                    pressCount++;
                }
                else
                {
                    if (lastKey != '\0' && keypad.ContainsKey(lastKey))
                    {
                        string letters = keypad[lastKey];
                        int index = (pressCount - 1) % letters.Length; 
                        result += letters[index];  
                    }

                    lastKey = c;
                    pressCount = 1;
                }
            }
        }

        if (lastKey != '\0' && keypad.ContainsKey(lastKey))
        {
            string letters = keypad[lastKey];
            int index = (pressCount - 1) % letters.Length;
            result += letters[index];
        }

       
        return result;
    }
}

// Test cases
public class Program
{
    public static void Main()
    {
        Console.WriteLine(OldPhonePad.OldPhonePadInput("33#"));        
        Console.WriteLine(OldPhonePad.OldPhonePadInput("227*#"));       
        Console.WriteLine(OldPhonePad.OldPhonePadInput("4433555 555666#")); 
        Console.WriteLine(OldPhonePad.OldPhonePadInput("8 88777444666*664#")); 
    }
}
