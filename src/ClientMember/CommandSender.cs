using System;
using Akka.Actor;
using Messages;

namespace ClientMember
{
    internal class CommandSender : UntypedActor
    {
        private IActorRef router;

        public CommandSender(IActorRef router)
        {
            this.router = router;
            Context.System.Scheduler.ScheduleTellRepeatedly(
                TimeSpan.Zero, 
                TimeSpan.FromSeconds(1), 
                this.Self, 
                new TestCommand(), 
                this.Self);
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine("sending to service");
            router.Tell(message);
        }
    }
}