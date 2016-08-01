using System;
using Akka.Actor;
using Messages;

namespace ServiceMember
{
    public class CommandHandler : UntypedActor
    {
        private Guid _id = Guid.NewGuid();

        public CommandHandler()
        {
        }

        protected override void OnReceive(dynamic message)
        {
            Console.WriteLine($"Group: {message.Group}, Sequence: {message.Sequence}");
        }
    }
}