using System;
using System.Collections.Generic;
using System;

namespace MediatorPatternQAs
{
    interface IMediator
    {
        // Our intention is to pass a message from 'fromFriend' to 'toFriend'.
        void Send(Friend fromFriend, Friend toFriend, string msg);
    }

    // ConcreteMediator
    class ConcreteMediator : IMediator
    {
        private Friend friend1, friend2, boss;

        public Friend Friend1
        {
            set { this.friend1 = value; }
        }

        public Friend Friend2
        {
            set { this.friend2 = value; }
        }

        public Friend Boss
        {
            set { this.boss = value; }
        }

        // Mediator is maintaining the control logic. Message will go from fromFriend to toFriend if toFriend is Online only.
        public void Send(Friend fromFriend, Friend toFriend, string msg)
        {
            if (toFriend.Status == "On")
            {
                Console.WriteLine(String.Format("[{0}->{1}] : {2} Last message posted {3}", fromFriend.Name, toFriend.Name, msg, DateTime.Now));
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine(String.Format("[{0}->{1}] : {2}, you cannot post messages now. {3} is offline.", fromFriend.Name, toFriend.Name, fromFriend.Name, toFriend.Name));
            }
        }
    }

    // Friend
    abstract class Friend
    {
        protected IMediator mediator;
        private string name;
        private string status;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        // Constructor
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
            this.Status = "On";
        }

        // Message will go to the intended friend
        public void Send(Friend intendedFriend, string msg)
        {
            mediator.Send(this, intendedFriend, msg);
        }
    }

    // Friend2-second participant
    class Friend2 : Friend
    {
        public Friend2(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
            this.Status = "On";
        }

        // Message will go to the intended friend
        public void Send(Friend intendedFriend, string msg)
        {
            mediator.Send(this, intendedFriend, msg);
        }
    }

    // Boss-Third participant
    class Boss : Friend
    {
        public Boss(IMediator mediator, string name) : base(mediator)
        {
            this.Name = name;
            this.Status = "On";
        }

        // Message will go to the intended friend
        public void Send(Friend intendedFriend, string msg)
        {
            mediator.Send(this, intendedFriend, msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Modified Mediator Pattern Demo ***\n");

            ConcreteMediator mediator = new ConcreteMediator();

            Friend1 Amit = new (mediator, "Amit");
            Friend2 Sohel = new (mediator, "Sohel");
            Boss Raghu = new (mediator, "Raghu");

            mediator.Friend1 = Amit;
            mediator.Friend2 = Sohel;
            mediator.Boss = Raghu;

            Amit.Send(Sohel, "Hi Sohel, can we discuss the mediator pattern?");
            Sohel.Send(Amit, "Hi Amit, Yup, we can discuss now.");
            Raghu.Send(Amit, "Please get back to work quickly.");
            Raghu.Send(Sohel, "Please get back to work quickly.");

            // Changing the status of Sohel
            Sohel.Status = "Off";
            Amit.Send(Sohel, "I am testing to send a message when Sohel is in Off state");

            // Sohel is coming online again
            Sohel.Status = "On";
            Amit.Send(Sohel, "I am testing to send a message when Sohel is in On state again");

            // Amit is going offline
            Amit.Status = "Off";
            Raghu.Send(Amit, "Can you please come here?");
            Raghu.Send(Sohel, "Can you please come here?");

            // Wait for user
            Console.Read();
        }
    }
}


//namespace MediatorPattern
//{
//    interface IMediator
//    {
//        void Register(Friend friend);
//        void Send(Friend friend, string msg);
//    }

//    // ConcreteMediator
//    class ConcreteMediator : IMediator
//    {
//        List<Friend> participants = new List<Friend>();

//        public void Register(Friend friend)
//        {
//            participants.Add(friend);
//        }

//        public void DisplayDetails()
//        {
//            Console.WriteLine("At present, registered Participants are:");
//            foreach (Friend friend in participants)
//            {
//                Console.WriteLine("{0}", friend.Name);
//            }
//        }

//        public void Send(Friend friend, string msg)
//        {
//            if (participants.Contains(friend))
//            {
//                Console.WriteLine(String.Format("[{0}] posts: {1} Last message posted {2}", friend.Name, msg, DateTime.Now));
//                System.Threading.Thread.Sleep(1000);
//            }
//            else
//            {
//                Console.WriteLine("An outsider named {0} trying to send some messages", friend.Name);
//            }
//        }
//    }

//    // Friend
//    abstract class Friend
//    {
//        protected IMediator mediator;
//        private string name;

//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }

//        public Friend(IMediator mediator)
//        {
//            this.mediator = mediator;
//        }
//    }

//    // Friend1-first participant
//    class Friend1 : Friend
//    {
//        public Friend1(IMediator mediator, string name) : base(mediator)
//        {
//            this.Name = name;
//        }

//        public void Send(string msg)
//        {
//            mediator.Send(this, msg);
//        }
//    }

//    // Friend2-second participant
//    class Friend2 : Friend
//    {
//        public Friend2(IMediator mediator, string name) : base(mediator)
//        {
//            this.Name = name;
//        }

//        public void Send(string msg)
//        {
//            mediator.Send(this, msg);
//        }
//    }

//    // Boss-Third participant (special)
//    class Boss : Friend
//    {
//        public Boss(IMediator mediator, string name) : base(mediator)
//        {
//            this.Name = name;
//        }

//        public void Send(string msg)
//        {
//            mediator.Send(this, msg);
//        }
//    }

//    // Unknown: 4th participant who tries to communicate without being registered
//    class Unknown : Friend
//    {
//        public Unknown(IMediator mediator, string name) : base(mediator)
//        {
//            this.Name = name;
//        }

//        public void Send(string msg)
//        {
//            mediator.Send(this, msg);
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("***Mediator Pattern Demo***\n");

//            ConcreteMediator mediator = new ConcreteMediator();
//            Friend1 Amit = new Friend1(mediator, "Amit");
//            Friend2 Sohel = new Friend2(mediator, "Sohel");
//            Boss Raghu = new Boss(mediator, "Raghu");

//            // Register participants
//            mediator.Register(Amit);
//            mediator.Register(Sohel);
//            mediator.Register(Raghu);

//            // Displaying participants list
//            mediator.DisplayDetails();
//            Console.WriteLine("Communication starts among participants...");

//            Amit.Send("Hi Sohel, can we discuss the mediator pattern?");
//            Sohel.Send("Hi Amit, Yup, we can discuss now.");
//            Raghu.Send("Please get back to work quickly.");

//            // An outsider/unknown person tries to participate
//            Unknown unknown = new Unknown(mediator, "Jack");
//            unknown.Send("Hello Guys..");

//            // Wait for user
//            Console.Read();
//        }
//    }
//}
