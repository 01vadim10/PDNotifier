using System;

namespace PDNotifier
{
    public class PolicemanNotifier : IHandle<MessageEvent>
    {
        public string Name;
        public PolicemanNotifier(string name = "CatsFightsForFoodPD")
        {
            Name = name;
        }
        public void Handle(object sender, MessageEvent args)
        {
            switch (args.Message)
            {
                case "Exception":
                    throw new InvalidOperationException("Something went wrong");
                default:
                    Console.WriteLine($"New message to {Name} from Dashboard: {args.Message}");
                    break;
            }
        }
    }
}
