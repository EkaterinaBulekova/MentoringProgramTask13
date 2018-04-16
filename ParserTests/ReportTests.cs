using System.IO;
using LogParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserTests
{
    [TestClass]
    public class ReportTests
    {
        private const string LogsPath = @"..\..\..\MvcMusicStore\logs";
            
        [TestMethod]
        public void TestGetReport()
        {
            var path = Path.GetFullPath(LogsPath);
            var parser = new Parser(path);
            parser.GetReport();
        }
    }
}
