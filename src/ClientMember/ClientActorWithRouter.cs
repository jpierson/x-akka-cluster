using System;
using Akka.Actor;

namespace ClientMember
{
    internal class ClientActorWithRouter : UntypedActor
    {
        private Guid _id = Guid.NewGuid();

        public ClientActorWithRouter()
        {
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine($"Yay! {message.ToString()} recieved by ClientRouter actor {_id}");
        }
    }
}