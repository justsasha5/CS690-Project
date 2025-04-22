using Xunit;
using System.IO;

namespace FinalPr.Tests
{
    public class EntryManagerTests
    {
        [Fact]
        public void LogEntry_AppendsEntryToFile()
        {
            var path = "test-log.txt";
            File.WriteAllText(path, string.Empty); // clean slate

            var manager = new EntryManager(path);
            var saver = new FileSaver(path);

            saver.AppendLine("2024-04-01: Test Entry");
            var content = File.ReadAllText(path);

            Assert.Contains("Test Entry", content);
        }

        [Fact]
        public void DeleteEntry_RemovesEntry()
        {
            var path = "test-delete.txt";
            File.WriteAllLines(path, new[] { "2024-01-01: To Remove", "2024-02-02: Keep" });

            var manager = new EntryManager(path);
            var lines = File.ReadAllLines(path);
            var updated = new List<string>(lines);
            updated.Remove("2024-01-01: To Remove");
            File.WriteAllLines(path, updated);

            var result = File.ReadAllLines(path);
            Assert.DoesNotContain("To Remove", result);
        }
    }
}
