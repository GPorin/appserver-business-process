using Antlr4.Runtime;

namespace grammarparser.test
{
    public class GrammarTest
    {
        [Fact]
        public void ParserRecogniseString()
        {
            string pathToFile = "../../../../fileparsers.test/parsedString.txt";
            string inputString = File.ReadAllText(pathToFile);

            AntlrInputStream input = new AntlrInputStream(inputString);
            ProcessLexer lexer = new ProcessLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ProcessParser parser = new ProcessParser(tokens);
            Assert.Equal(0, parser.NumberOfSyntaxErrors);
        }
    }
}