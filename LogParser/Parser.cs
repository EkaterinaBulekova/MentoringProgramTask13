using System;

namespace LogParser
{
    public class Parser
    {
        private readonly string _sourcePath;
        private const string Separator = ",";

        public Parser(string source)
        {
            _sourcePath = source;
        }

        public void GetReport()
        {
            var logQuery = new MSUtil.LogQueryClass();

            var input = new MSUtil.COMTSVInputContextClass
            {
                iSeparator = Separator
            };

            var resultDataSet = logQuery.Execute($@"SELECT Level, COUNT(*) AS Total FROM {_sourcePath}\*.log GROUP BY Level", input);
            while (!resultDataSet.atEnd())
            {
                var record = resultDataSet.getRecord();
                Console.WriteLine($"{record.getValue("Level")}:{record.getValue("Total")}");
                resultDataSet.moveNext();
            }

            resultDataSet = logQuery.Execute($@"SELECT * FROM {_sourcePath}\*.log WHERE Level='ERROR'", input);
            while (!resultDataSet.atEnd())
            {
                var record = resultDataSet.getRecord();
                Console.WriteLine($"{record.getValue("Level")} : {record.getValue("Date")} : {record.getValue("Message")}");
                resultDataSet.moveNext();
            }
        }
    }
}
