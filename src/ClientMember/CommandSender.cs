using System;
using Akka.Actor;
using Akka.Cluster.Routing;
using Akka.Routing;
using Messages;

namespace ClientMember
{
    public class CommandSender : UntypedActor
    {
        private int _sequenceCounter;
        private Random _randomNumberGenerator;
        private IActorRef router;

        public CommandSender()
        {
            _sequenceCounter = 0;
            _randomNumberGenerator = new Random();



            router = Context.System.ActorOf(Props.Create(() => new ServiceMember.CommandHandler()).WithRouter(
                new ClusterRouterPool(
                    new RoundRobinPool(1),
                    new ClusterRouterPoolSettings(
                        4,
                        1,
                        false,
                        "service"))));

            //Context.System.Scheduler.ScheduleTellRepeatedly(
            //    TimeSpan.Zero,
            //    TimeSpan.FromSeconds(1),
            //    this.Self,
            //    "Send something now!",
            //    this.Self);
        }

        protected override void OnReceive(object message)
        {
            var t = (int)message;
            //Console.WriteLine($"sending to service: {t.Group} {t.Sequence}");
            Console.WriteLine($"sending to service");
            for (int x = 0; x < 1000000; x++)
                router.Tell(new TestCommand { Sequence = _sequenceCounter++, Group = "Group " + _randomNumberGenerator.Next(1, 10) });
            Console.WriteLine($"Done sending to service");

        }
    }
}