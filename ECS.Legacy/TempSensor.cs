using System;

namespace ECS_v2
{
     public class TempSensor : ISensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }
        
    }
}