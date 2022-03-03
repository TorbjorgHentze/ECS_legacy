using System;

namespace ECS_v2
{
    public class Window:IRegulate
    {
        public void TurnOn()
        {
            Console.WriteLine("Window is open");
        }

        public void TurnOff()
        {
            Console.WriteLine("Window is closed");
        }
    }
}