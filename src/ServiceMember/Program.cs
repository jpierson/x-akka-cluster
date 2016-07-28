using Akka.Actor;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMember
{
    class Program
    {
        public static ActorSystem ClusterSystem { get; set; }
        public static IActorRef CommandSender { get; private set; }

        static void Main(string[] args)
        {
            ClusterSystem = ActorSystem.Create("testcluster");
            var router = ClusterSystem.ActorOf(Props.Create(() => new CommandMaster()), "service");
            CommandSender = ClusterSystem.ActorOf(Props.Create(() => new CommandHandler(router)), "commandsender");

            ClusterSystem.WhenTerminated.Wait();
        }
    }
}
