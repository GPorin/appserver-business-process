using AppServer.Commands;
using AppServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace grammarparser
{
    public class ProcessSimpleCommandListener: ProcessBaseListener
    {
        override public void EnterSimplecommand(ProcessParser.SimplecommandContext context) 
        {
            ICommand cmd = Ioc.Resolve<ICommand>(context.GAMECOMMANDS().Symbol.Text);
            ICommand send = new SendCommand(cmd, Ioc.Resolve<ICommandConsumer>("GetQueue"));
            send.Execute();
        }
    }
}
