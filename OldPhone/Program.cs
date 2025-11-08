namespace OldPhone;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Answer -> should be E and found -> " + OldPhoneKeypad.TranslateInput("33#"));
        Console.WriteLine("Answer -> should be B and found -> " + OldPhoneKeypad.TranslateInput("227*#"));
        Console.WriteLine("Answer -> should be HELLO and found -> " + OldPhoneKeypad.TranslateInput("4433555 555666#"));
        Console.WriteLine("Answer -> should be TURING and found -> " + OldPhoneKeypad.TranslateInput("8 88777444666*664#"));
    }
}