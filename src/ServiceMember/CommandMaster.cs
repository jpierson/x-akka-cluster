using System;
using Akka.Actor;

namespace ServiceMember
{
    internal class CommandMaster : UntypedActor
    {
        private Guid _id = Guid.NewGuid();

        public CommandMaster()
        {
        }

        protected override void OnReceive(object message)
        {
            //Console.WriteLine($"Yay! {message.ToString()} recieved by CommandMaster actor {_id}");
        }
    }
}