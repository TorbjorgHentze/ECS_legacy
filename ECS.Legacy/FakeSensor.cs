using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_v2
{
    class FakeSensor : ISensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 10);
        }
    }
}
