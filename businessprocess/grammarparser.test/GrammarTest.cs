using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Microsoft.Win32;

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

        [Fact]

        public void ListenerGetsCommandQueue() 
        {
            string pathToFile = "../../../../fileparsers.test/parsedString.txt";
            string inputString = File.ReadAllText(pathToFile);

            AntlrInputStream input = new AntlrInputStream(inputString);
            ProcessLexer lexer = new ProcessLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ProcessParser parser = new ProcessParser(tokens);



            IParseTree tree = parser.process();
            ProcessSimpleCommandListener listener = new ProcessSimpleCommandListener();
            ParseTreeWalker.Default.Walk(listener, tree);
        }
    }
}