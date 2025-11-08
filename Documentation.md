# OldPhoneKeypad Documentation

## Overview

The `OldPhoneKeypad` class provides functionality to translate input from an old phone keypad format into readable text. It simulates the behavior of traditional mobile phone keypads where users press number keys multiple times to cycle through the letters associated with each key.

## Class Structure

```csharp
namespace OldPhone
{
    public class OldPhoneKeypad
    {
        // Implementation details
    }
}
```

## Key Features

- Translates numeric input sequences into corresponding characters
- Supports backspace functionality using the asterisk (*) character
- Handles spaces using the 0 key
- Automatically manages character cycling when a key is pressed multiple times
- Processes input strings that always end with a send character (#)

## Constants

```csharp
private static readonly string[] KEY_MAP =
{
    "",          // 0 
    "&'(",       // 1
    "ABC",       // 2
    "DEF",       // 3
    "GHI",       // 4
    "JKL",       // 5
    "MNO",       // 6
    "PQRS",      // 7
    "TUV",       // 8
    "WXYZ"       // 9
};
```

The `KEY_MAP` array maps each number key (0-9) to its corresponding characters.

## Methods

### GetCharacterFromKey

```csharp
private static char GetCharacterFromKey(int number, int pressed)
```

**Purpose**: Determines which character to return based on the number key and how many times it was pressed.

**Parameters**:
- `number`: The number key (0-9)
- `pressed`: The number of consecutive times the key was pressed

**Returns**: The character corresponding to the key press sequence.

**Behavior**: Uses modulo arithmetic to cycle through available characters when a key is pressed multiple times.

### ProcessSequence

```csharp
private static void ProcessSequence(StringBuilder result, int number, int pressed)
```

**Purpose**: Processes a sequence of identical key presses and adds the resulting character to the output.

**Parameters**:
- `result`: The StringBuilder containing the output text
- `number`: The number key being processed
- `pressed`: The number of consecutive times the key was pressed

**Special Cases**:
- If the key is 0, it appends multiple spaces equal to the press count
- For other keys, it appends the character determined by GetCharacterFromKey

### RemoveLastCharacter

```csharp
private static void RemoveLastCharacter(StringBuilder result)
```

**Purpose**: Implements the backspace functionality by removing the last character from the result.

**Parameters**:
- `result`: The StringBuilder containing the output text

**Behavior**: Only removes a character if the result is not empty.

### IsSpecialOrDifferent

```csharp
private static bool IsSpecialOrDifferent(char currentChar, char previousChar)
```

**Purpose**: Determines if the current character requires special processing or differs from the previous character.

**Parameters**:
- `currentChar`: The character being evaluated
- `previousChar`: The previous character in the input sequence

**Returns**: True if the current character is a space, asterisk, hash, or different from the previous character.

### TranslateInput

```csharp
public static string TranslateInput(string input)
```

**Purpose**: The main method that translates old phone keypad input into readable text.

**Parameters**:
- `input`: The input string representing key presses

**Returns**: The translated text.

**Algorithm**:
1. Initializes a StringBuilder to store the result
2. Processes each character in the input string
3. When encountering a different character or special character, finishes processing the previous sequence
4. For digit characters, tracks the number and press count
5. Handles backspace functionality when an asterisk is encountered
6. Returns the final translated string

## Usage Example

```csharp
// Input "222 2 22#" translates to "CAB"
string input = "222 2 22#";
string output = OldPhoneKeypad.TranslateInput(input);
Console.WriteLine(output); // Outputs: CAB
```

## Special Cases

- **Key Cycling**: If a key has 3 letters and is pressed 4 times, it cycles back to the first letter
- **Zero Key**: Pressing 0 multiple times adds multiple spaces (doesn't cycle)
- **Backspace**: The asterisk (*) character removes the last character from the result
- **Send**: The hash (#) character indicates the end of input and doesn't affect the result

## Performance Considerations

- Uses StringBuilder for efficient string manipulation
- O(n) time complexity where n is the length of the input string
- Minimal memory usage with constant space complexity

## AI Prompt Link

- https://www.perplexity.ai/search/how-to-check-a-character-is-a-9kQGjoJoR72bR9BzgbeHVQ#3