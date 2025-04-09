namespace FinalPr.Tests;

using FinalPr;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);

    }

    [Fact]
    public void Test_FileSaver_Append()
    {
        File.WriteAllText(testFileName, string.Empty); 
        fileSaver.AppendLine("Hello, World!");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, World!"+ Environment.NewLine,contentFromFile);
    }


}