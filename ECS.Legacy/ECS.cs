using System;

namespace ECS_v2
{
    public class ECS
    {
        private int _threshold;
        private readonly ISensor _Sensor;
        private readonly IRegulate _heater;

        

        public ECS(int thr, ISensor Sensor,IRegulate heater)
        {
            SetThreshold(thr);
            this._Sensor = Sensor;
            this._heater = heater;
        }

        public void Regulate()
        {
            var t = _Sensor.GetTemp();
            Console.WriteLine($"Temperature measured was {t}");
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _Sensor.GetTemp();
        }

        
    }
}
