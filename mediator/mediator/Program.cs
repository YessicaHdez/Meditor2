using System;
using System.Collections.Generic;

namespace Mediator
{
    
    public interface IMediator
    {
       void Send(string message, ICollague colleague);
    }

    


    public abstract class ICollague
    {
        private IMediator mediator;

        public ICollague(IMediator mediator)
        {
            this.mediator = mediator;
        }
      
        public void SendM(string message) {
            this.mediator.Send(message, this);
        }

        public abstract void Receive(string message);
    }






   


    public class Mediator : IMediator
    {
        List<ICollague> colleagues;
        
        public Mediator()
        {
            colleagues = new List<ICollague>();
        }
        public void Add(ICollague colleague)
        {
            this.colleagues.Add(colleague);
        }
        public void Send(string message, ICollague colleague)
        {
            foreach (var c in this.colleagues)
            {
                if (colleague != c)
                {
                    c.Receive(message);
                }
            }
        }
    }


    class User : ICollague
    {
        public User(IMediator mediator): base(mediator)
        {

        }
        public override void Receive(string message)
        {
           Console.WriteLine(message);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
          
            Mediator mediator = new Mediator();
            ICollague juan = new User(mediator);
            ICollague Alberto = new User(mediator);
            mediator.Add(juan);
            mediator.Add(Alberto);
            juan.SendM("Hola");
            Alberto.SendM("K");
        }
    }
}
