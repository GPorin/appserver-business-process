using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Microsoft.Win32;
using System.Collections.Concurrent;
using AppServer;
using AppServer.Scopes;
using Moq;
using AppServer.Commands;

namespace grammarparser.test
{
    public class GrammarTest
    {
        [Fact]
        public void ParserRecogniseString()
        {
            string pathToFile = "../../../../fileparsers.test/parsedString.txt";
            string inputString = File.ReadAllText(pathToFile);

            AntlrInputStream input = new(inputString);
            ProcessLexer lexer = new(input);
            CommonTokenStream tokens = new(lexer);
            ProcessParser parser = new(tokens);
            Assert.Equal(0, parser.NumberOfSyntaxErrors);
        }

        [Fact]

        public void ListenerGetsCommandQueue() 
        {
            string pathToFile = "../../../../fileparsers.test/parsedString.txt";
            string inputString = File.ReadAllText(pathToFile);

            AntlrInputStream input = new(inputString);
            ProcessLexer lexer = new(input);
            CommonTokenStream tokens = new(lexer);
            ProcessParser parser = new(tokens);

            IParseTree tree = parser.process();

            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<ICommand>("IoC.Scope.Current.Set", iocScope).Execute();

            Ioc.Resolve<ICommand>("IoC.Register", "GetClassNumber", (object[] args) => new Mock<ICommand>().Object).Execute();
            Ioc.Resolve<ICommand>("IoC.Register", "GetGroupNumber", (object[] args) => new Mock<ICommand>().Object).Execute();
            Ioc.Resolve<ICommand>("IoC.Register", "CheckAttendance", (object[] args) => new Mock<ICommand>().Object).Execute();
            Ioc.Resolve<ICommand>("IoC.Register", "GetLectureName", (object[] args) => new Mock<ICommand>().Object).Execute();
            Ioc.Resolve<ICommand>("IoC.Register", "TurnOnProjector", (object[] args) => new Mock<ICommand>().Object).Execute();
            Ioc.Resolve<ICommand>("IoC.Register", "OpenLecture", (object[] args) => new Mock<ICommand>().Object).Execute();
            Ioc.Resolve<ICommand>("IoC.Register", "WaitToFinish", (object[] args) => new Mock<ICommand>().Object).Execute();

            BlockingCollection<ICommand> queue = new();

            Ioc.Resolve<ICommand>("IoC.Register", "GetQueue", (object[] args) => new QueueCommandConsumerAdapter(queue)).Execute();

            ProcessSimpleCommandListener listener = new();
            ParseTreeWalker.Default.Walk(listener, tree);

            BlockingCollection<ICommand> controlQueue = new();
            for (int i = 0; i < 7; i++)
            {
                controlQueue.TryAdd(new Mock<ICommand>().Object);
            }

            Assert.Equal(controlQueue, queue);
        }
    }
}