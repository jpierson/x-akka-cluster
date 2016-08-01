using System;
using Akka.Actor;
using Messages;

namespace ServiceMember
{
    public class CommandHandler : UntypedActor
    {
        private int counter = 0;
        public CommandHandler()
        {
        }

        protected override void OnReceive(dynamic message)
        {
            counter++;
            Console.WriteLine($"Group: {message.Group}, Sequence: {message.Sequence}  MessageCount: {counter}");
        }
    }
}