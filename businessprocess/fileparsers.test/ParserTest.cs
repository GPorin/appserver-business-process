using fileparsers;
using System.IO;
using System.Text.Json;

namespace fileparsers.test
{
    public class ParserTest
    {
        [Fact]
        public void ConvertToStringReturnsCorrectString()
        {
            string pathToJson = "../../../LectureProcess.json";
            string pathToTxt = "../../../parsedString.txt";

            JsonDocument document = JsonDocument.Parse(File.ReadAllText(pathToJson));

            IParserFileToString parser = new JSONParser(document);
            string parserResult = parser.ConvertToString();

            string expectedResult = File.ReadAllText(pathToTxt);
            Assert.Equal(expectedResult, parserResult);
        }
    }
}