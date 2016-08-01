using Akka.Actor;
using Akka.Cluster.Routing;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSender
{
    class Program
    {
        public static ActorSystem ClusterSystem { get; set; }

        static void Main(string[] args)
        {
            ClusterSystem = ActorSystem.Create("testcluster");

            //var router = ClusterSystem.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "proxy");
            //var props = Props.Create<ServiceMember.CommandHandler>().WithRouter(new RoundRobinPool(5));
            ////var props = Props.Create<ClientActorWithRouter>().WithRouter(new RoundRobinPool(5));
            //var router = ClusterSystem.ActorOf(props, "proxy");

            //var router = ClusterSystem.ActorOf(Props.Create<ServiceMember.CommandHandler>().WithRouter(
            var router = ClusterSystem.ActorOf(Props.Create(() => new ClientMember.CommandSender()).WithRouter(
                     new ClusterRouterGroup(
                         new BroadcastGroup("/user/commands"),
                         new ClusterRouterGroupSettings(1, new[] { "/user/commands" }, false, "client"))));


            //CommandSender = ClusterSystem.ActorOf(Props.Create(() => new ClientMember.CommandSender(router)), "commands");

            char a;
            while (true)
            {
                a = Console.ReadKey().KeyChar;
                int r;
                if (int.TryParse(a.ToString(), out r))
                {
                    router.Tell(r);
                }
            }

            ClusterSystem.WhenTerminated.Wait();
        }
    }
}
