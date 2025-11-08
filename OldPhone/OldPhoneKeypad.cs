using System.Text;

namespace OldPhone;

public class OldPhoneKeypad
{
    private static readonly string[] KEY_MAP =
    {
        "",
        "&'(",
        "ABC",
        "DEF",
        "GHI",
        "JKL",
        "MNO",
        "PQRS",
        "TUV",
        "WXYZ"
    };

    private static char GetCharacterFromKey(int number, int pressed)
    {
        return KEY_MAP[number][(pressed - 1) % KEY_MAP[number].Length];
    }

    private static void ProcessSequence(StringBuilder result, int number, int pressed)
    {
        if (pressed > 0)
        {
            result.Append(number == 0 ? new string(' ', pressed) : GetCharacterFromKey(number, pressed));
        }
    }

    private static void RemoveLastCharacter(StringBuilder result)
    {
        if (result.Length > 0)
        {
            result.Length--;
        }
    }

    private static bool IsSpecialOrDifferent(char currentChar, char previousChar)
    {
        return currentChar == ' ' || currentChar == '*' || currentChar == '#' || currentChar != previousChar;
    }

    public static string TranslateInput(string input)
    {
        var result = new StringBuilder();
        int number = 0;
        int pressCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (i != 0 && IsSpecialOrDifferent(currentChar, input[i - 1]))
            {
                ProcessSequence(result, number, pressCount);
                pressCount = 0;

                if (currentChar == '*')
                {
                    RemoveLastCharacter(result);
                }
            }

            if (char.IsDigit(currentChar))
            {
                number = currentChar - '0';
                pressCount++;
            }
        }

        return result.ToString();
    }
}