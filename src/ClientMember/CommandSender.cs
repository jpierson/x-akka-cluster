using System;
using Akka.Actor;
using Messages;

namespace ClientMember
{
    internal class CommandSender : UntypedActor
    {
        private int _sequenceCounter;
        private Random _randomNumberGenerator;
        private IActorRef router;

        public CommandSender(IActorRef router)
        {
            _sequenceCounter = 0;
            _randomNumberGenerator = new Random();

            this.router = router;
            Context.System.Scheduler.ScheduleTellRepeatedly(
                TimeSpan.Zero, 
                TimeSpan.FromSeconds(1), 
                this.Self, 
                "Send something now!", 
                this.Self);
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine("sending to service");
            router.Tell(new TestCommand() { Sequence = _sequenceCounter++, Group = "Group " + _randomNumberGenerator.Next(1, 10).ToString() });
        }
    }
}