using Microsoft.VisualStudio.TestTools.UnitTesting;
using OldPhone;


[TestClass]
public class OldPhoneKeypadTest
{
    [TestMethod]
    public void Pressing0ShouldWorkCorrectly()
    {
        Assert.AreEqual(" ", OldPhoneKeypad.TranslateInput("0#"));
        Assert.AreEqual("  ", OldPhoneKeypad.TranslateInput("00#"));
        Assert.AreEqual("   ", OldPhoneKeypad.TranslateInput("000#"));
        Assert.AreEqual("    ", OldPhoneKeypad.TranslateInput("0000#"));
    }

    [TestMethod]
    public void Pressing1ShouldWorkCorrectly()
    {
        Assert.AreEqual("&", OldPhoneKeypad.TranslateInput("1#"));
        Assert.AreEqual("'", OldPhoneKeypad.TranslateInput("11#"));
        Assert.AreEqual("(", OldPhoneKeypad.TranslateInput("111#"));
        Assert.AreEqual("&", OldPhoneKeypad.TranslateInput("1111#"));
        Assert.AreEqual("'", OldPhoneKeypad.TranslateInput("11111#"));
        Assert.AreEqual("(", OldPhoneKeypad.TranslateInput("111111#")); 
    }

    [TestMethod]
    public void Pressing2ShouldWorkCorrectly()
    {
        Assert.AreEqual("A", OldPhoneKeypad.TranslateInput("2#"));
        Assert.AreEqual("B", OldPhoneKeypad.TranslateInput("22#"));
        Assert.AreEqual("C", OldPhoneKeypad.TranslateInput("222#"));
        Assert.AreEqual("A", OldPhoneKeypad.TranslateInput("2222#"));
        Assert.AreEqual("B", OldPhoneKeypad.TranslateInput("22222#"));
        Assert.AreEqual("C", OldPhoneKeypad.TranslateInput("222222#"));
    }

    [TestMethod]
    public void Pressing3ShouldWorkCorrectly()
    {
        Assert.AreEqual("D", OldPhoneKeypad.TranslateInput("3#"));
        Assert.AreEqual("E", OldPhoneKeypad.TranslateInput("33#"));
        Assert.AreEqual("F", OldPhoneKeypad.TranslateInput("333#"));
        Assert.AreEqual("D", OldPhoneKeypad.TranslateInput("3333#"));
        Assert.AreEqual("E", OldPhoneKeypad.TranslateInput("33333#"));
        Assert.AreEqual("F", OldPhoneKeypad.TranslateInput("333333#"));
    }

    [TestMethod]
    public void Pressing4ShouldWorkCorrectly()
    {
        Assert.AreEqual("G", OldPhoneKeypad.TranslateInput("4#"));
        Assert.AreEqual("H", OldPhoneKeypad.TranslateInput("44#"));
        Assert.AreEqual("I", OldPhoneKeypad.TranslateInput("444#"));
    }

    [TestMethod]
    public void Pressing5ShouldWorkCorrectly()
    {
        Assert.AreEqual("J", OldPhoneKeypad.TranslateInput("5#"));
        Assert.AreEqual("K", OldPhoneKeypad.TranslateInput("55#"));
        Assert.AreEqual("L", OldPhoneKeypad.TranslateInput("555#"));
    }

    [TestMethod]
    public void Pressing6ShouldWorkCorrectly()
    {
        Assert.AreEqual("M", OldPhoneKeypad.TranslateInput("6#"));
        Assert.AreEqual("N", OldPhoneKeypad.TranslateInput("66#"));
        Assert.AreEqual("O", OldPhoneKeypad.TranslateInput("666#"));
    }

    [TestMethod]
    public void Pressing7ShouldWorkCorrectly()
    {
        Assert.AreEqual("P", OldPhoneKeypad.TranslateInput("7#"));
        Assert.AreEqual("Q", OldPhoneKeypad.TranslateInput("77#"));
        Assert.AreEqual("R", OldPhoneKeypad.TranslateInput("777#"));
        Assert.AreEqual("S", OldPhoneKeypad.TranslateInput("7777#"));
    }

    [TestMethod]
    public void Pressing8ShouldWorkCorrectly()
    {
        Assert.AreEqual("T", OldPhoneKeypad.TranslateInput("8#"));
        Assert.AreEqual("U", OldPhoneKeypad.TranslateInput("88#"));
        Assert.AreEqual("V", OldPhoneKeypad.TranslateInput("888#"));
    }

    [TestMethod]
    public void Pressing9ShouldWorkCorrectly()
    {
        Assert.AreEqual("W", OldPhoneKeypad.TranslateInput("9#"));
        Assert.AreEqual("X", OldPhoneKeypad.TranslateInput("99#"));
        Assert.AreEqual("Y", OldPhoneKeypad.TranslateInput("999#"));
        Assert.AreEqual("Z", OldPhoneKeypad.TranslateInput("9999#"));
    }

    [TestMethod]
    public void OldPhoneKeyPadWorksCorrectlyForSampleInputs()
    {
        Assert.AreEqual("E", OldPhoneKeypad.TranslateInput("33#"));
        Assert.AreEqual("B", OldPhoneKeypad.TranslateInput("227*#"));
        Assert.AreEqual("HELLO", OldPhoneKeypad.TranslateInput("4433555 555666#"));
        Assert.AreEqual("TURING", OldPhoneKeypad.TranslateInput("8 88777444666*664#"));
    }
    

    [TestMethod]
    public void OldPhoneKeyPadWorksCorrectlyForMultipleWords()
    {
        Assert.AreEqual("B TURING", OldPhoneKeypad.TranslateInput("2208 88777444666*664#"));
        Assert.AreEqual("HELLO TURING", OldPhoneKeypad.TranslateInput("4433555 55566608 88777444666*664#"));
    }

    [TestMethod]
    public void OldPhoneKeyPadHandlesConsecutiveBackspacesCorrectly()
    {
        Assert.AreEqual("HE TURING", OldPhoneKeypad.TranslateInput("4433555 555666***08 88777444666*664#"));
    }

    [TestMethod]
    public void OldPhoneKeyPadHandlesConsecutiveSpacesCorrectly()
    {
        Assert.AreEqual("HELLO   TURING", OldPhoneKeypad.TranslateInput("4433555 5556660008 88777444666*664#"));
    }

    [TestMethod]
    public void OldPhoneKeyPadHandlesLeadingSpacesCorrectly()
    {
        Assert.AreEqual("   HELLO   TURING", OldPhoneKeypad.TranslateInput("0004433555 5556660008 88777444666*664#"));
    }

    [TestMethod]
    public void OldPhoneKeyPadHandlesTrailingSpacesCorrectly()
    {
        Assert.AreEqual("   HELLO   TURING   ", OldPhoneKeypad.TranslateInput("0004433555 5556660008 88777444666*664000#"));
    }

    [TestMethod]
    public void OldPhoneKeyPadHandlesExcessiveBackspacesCorrectly()
    {
        Assert.AreEqual("", OldPhoneKeypad.TranslateInput("97****#"));
    }  
}