using System;
using Akka.Actor;

namespace ServiceMember
{
    internal class CommandMaster : UntypedActor
    {
        public CommandMaster()
        {
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine("Yay!" + message.ToString());
        }
    }
}