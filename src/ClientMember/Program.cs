using Akka.Actor;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMember
{
    class Program
    {
        public static ActorSystem ClusterSystem { get; set; }
        public static IActorRef CommandSender { get; private set; }

        static void Main(string[] args)
        {
            ClusterSystem = ActorSystem.Create("testcluster");
            var router = ClusterSystem.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "proxy");
            CommandSender = ClusterSystem.ActorOf(Props.Create(() => new CommandSender(router)), "commands");

            ClusterSystem.WhenTerminated.Wait();
        }
    }
}
