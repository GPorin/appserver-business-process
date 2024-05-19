using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Commands
{
    public class ConditionCommand: ICommand
    {
        private readonly ICommand _condition;
        private readonly ICommand _thenCommand;
        private readonly ICommand? _elseCommand;

        public ConditionCommand(ICommand condition, ICommand thenCommand, ICommand? elseCommand = null)
        {
            _condition = condition;
            _thenCommand = thenCommand;
            _elseCommand = elseCommand;
        }

        public void Execute()
        {
            try
            {
                _condition.Execute();
            }
            catch (Exception)
            {
                _elseCommand?.Execute();
                return;
            }
            _thenCommand.Execute();
        }
    }
}
