using System;

namespace FacadePattern
{
    // زیرسیستم‌ها (RobotBody, RobotColor, RobotHands)
    namespace RobotParts
    {
        public class RobotBody
        {
            public void CreateHands() => Console.WriteLine("Hands manufactured");
            public void CreateRemainingParts() => Console.WriteLine("Remaining parts (other than hands) are created");
            public void DestroyHands() => Console.WriteLine("The robot's hands are destroyed");
            public void DestroyRemainingParts() => Console.WriteLine("The robot's remaining parts are destroyed");
        }

        public class RobotColor
        {
            public void SetDefaultColor() => Console.WriteLine("This is a steel color robot.");
            public void SetGreenColor() => Console.WriteLine("This is a green color robot.");
        }

        public class RobotHands
        {
            public void SetMilanoHands() => Console.WriteLine("The robot will have EH1 Milano hands");
            public void SetRobonautHands() => Console.WriteLine("The robot will have Robonaut hands");
            public void ResetMilanoHands() => Console.WriteLine("EH1 Milano hands are about to be destroyed");
            public void ResetRobonautHands() => Console.WriteLine("Robonaut hands are about to be destroyed");
        }
    }

    // کلاس Facade
    public class RobotFacade
    {
        private RobotParts.RobotColor rc;
        private RobotParts.RobotHands rh;
        private RobotParts.RobotBody rb;

        public RobotFacade()
        {
            rc = new RobotParts.RobotColor();
            rh = new RobotParts.RobotHands();
            rb = new RobotParts.RobotBody();
        }

        public void ConstructMilanoRobot()
        {
            Console.WriteLine("Creation of a Milano Robot Start");
            rc.SetDefaultColor();
            rh.SetMilanoHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("Milano Robot Creation End\n");
        }

        public void ConstructRobonautRobot()
        {
            Console.WriteLine("Initiating the creational process of a Robonaut Robot");
            rc.SetGreenColor();
            rh.SetRobonautHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("A Robonaut Robot is created\n");
        }

        public void DestroyMilanoRobot()
        {
            Console.WriteLine("Milano Robot's destruction process is started");
            rh.ResetMilanoHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("Milano Robot's destruction process is over\n");
        }

        public void DestroyRobonautRobot()
        {
            Console.WriteLine("Initiating a Robonaut Robot's destruction process.");
            rh.ResetRobonautHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("A Robonaut Robot is destroyed\n");
        }
    }

    // کلاس اصلی
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Facade Pattern Demo***\n");

            RobotFacade rf1 = new RobotFacade();
            rf1.ConstructMilanoRobot();

            RobotFacade rf2 = new RobotFacade();
            rf2.ConstructRobonautRobot();

            rf1.DestroyMilanoRobot();
            rf2.DestroyRobonautRobot();

            Console.ReadLine();
        }
    }
}
