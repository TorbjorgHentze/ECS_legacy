using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_v2
{
    class FakeHeater : IRegulate
    {
        public void TurnOn()
        {
            System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
