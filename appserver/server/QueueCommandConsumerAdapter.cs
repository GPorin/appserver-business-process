using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace AppServer.Commands
{
    public class QueueCommandConsumerAdapter: ICommandConsumer
    {
        private BlockingCollection<ICommand> _queue;
        public QueueCommandConsumerAdapter(BlockingCollection<ICommand> queue)
        {
            _queue = queue;
        }

        public void Receive(ICommand cmd)
        {
            _queue.TryAdd(cmd);
        }
    }
}
