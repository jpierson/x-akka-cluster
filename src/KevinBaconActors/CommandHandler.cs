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

        protected override void OnReceive(object message)
        {
            Console.WriteLine($"Yay! {message.ToString()} recieved by CommandHandler actor {_id}");
        }
    }
}