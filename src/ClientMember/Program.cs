using Akka.Actor;
using Akka.Cluster.Routing;
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

            //var router = ClusterSystem.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "proxy");
            //var props = Props.Create<ServiceMember.CommandHandler>().WithRouter(new RoundRobinPool(5));
            ////var props = Props.Create<ClientActorWithRouter>().WithRouter(new RoundRobinPool(5));
            //var router = ClusterSystem.ActorOf(props, "proxy");

            var router = ClusterSystem.ActorOf(Props.Create<ServiceMember.CommandHandler>().WithRouter(
                     new ClusterRouterPool(
                         new RoundRobinPool(1),
                         new ClusterRouterPoolSettings(
                             4, 
                             false,
                             "service",
                             2))));


            CommandSender = ClusterSystem.ActorOf(Props.Create(() => new CommandSender(router)), "commands");

            ClusterSystem.WhenTerminated.Wait();
        }
    }
}
