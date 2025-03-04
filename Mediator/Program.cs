
namespace MediatorPattern
{
    interface IMediator
    {
        void Register(Friend friend);
        void Send(Friend friend, string msg);
    }

    // ConcreteMediator
    class ConcreteMediator : IMediator
    {
        private List<Friend> participants = [];

        public void Register(Friend friend)
        {
            participants.Add(friend);
        }

        public void DisplayDetails()
        {
            Console.WriteLine("At present, registered Participants are:");
            foreach (Friend friend in participants)
            {
                Console.WriteLine("{0}", friend.Name);
            }
        }

        public void Send(Friend friend, string msg)
        {
            if (participants.Contains(friend))
            {
                Console.WriteLine(String.Format("[{0}] posts: {1} Last message posted {2}", friend.Name, msg, DateTime.Now));
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("An outsider named {0} trying to send some messages", friend.Name);
            }
        }
    }

    // Friend
    abstract class Friend
    {
        protected IMediator mediator;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Friend(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }

    // Friend1-first participant
    class Friend1 : Friend
    {
        public Friend1(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }
    }

    // Friend2-second participant
    class Friend2 : Friend
    {
        public Friend2(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }
    }

    // Boss-Third participant (special)
    class Boss : Friend
    {
        public Boss(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }
    }

    // Unknown: 4th participant who tries to communicate without being registered
    class Unknown : Friend
    {
        public Unknown(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Mediator Pattern Demo***\n");

            ConcreteMediator mediator = new ();
            Friend1 Amit = new (mediator, "Amit");
            Friend2 Sohel = new (mediator, "Sohel");
            Boss Raghu = new (mediator, "Raghu");

            // Register participants
            mediator.Register(Amit);
            mediator.Register(Sohel);
            mediator.Register(Raghu);

            // Displaying participants list
            mediator.DisplayDetails();
            Console.WriteLine("Communication starts among participants...");

            Amit.Send("Hi Sohel, can we discuss the mediator pattern?");
            Sohel.Send("Hi Amit, Yup, we can discuss now.");
            Raghu.Send("Please get back to work quickly.");

            // An outsider/unknown person tries to participate
            Unknown unknown = new Unknown(mediator, "Jack");
            unknown.Send("Hello Guys..");

            // Wait for user
            Console.Read();
        }
    }
}
