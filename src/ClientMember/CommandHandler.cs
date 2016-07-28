using System;
using Akka.Actor;
using Messages;

namespace ClientMember
{
    internal class CommandHandler : UntypedActor
    {
        private IActorRef router;

        public CommandHandler(IActorRef router)
        {
            this.router = router;
        }

        protected override void OnReceive(object message)
        {
            var command = (TestCommand)message;
        }
    }
}