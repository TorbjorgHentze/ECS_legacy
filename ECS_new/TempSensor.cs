using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Legacy
{
    public class TempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
