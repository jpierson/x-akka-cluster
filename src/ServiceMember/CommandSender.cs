using System;
using Akka.Actor;
using Messages;

namespace ServiceMember
{
    internal class CommandSender : UntypedActor
    {
        private IActorRef router;

        public CommandSender(IActorRef router)
        {
            this.router = router;
            Context.System.Scheduler.ScheduleTellRepeatedly(
                TimeSpan.Zero, 
                TimeSpan.FromSeconds(2), 
                router, 
                new TestCommand(), 
                this.Self);
        }

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}