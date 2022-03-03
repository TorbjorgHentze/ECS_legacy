using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ECS_v2;
using NSubstitute;


namespace ECS_Test
{
    public class Tests
    {
        private ECS uut;
        //private FakeHeater heater;
        //private FakeSensor sensor;
        private ISensor sensor;
        private IRegulate heater;

        [SetUp]
        public void Setup()
        {
            //sensor = new FakeSensor();
            //heater = new FakeHeater();
            heater = Substitute.For<IRegulate>();
            sensor = Substitute.For<ISensor>();
            uut = new ECS(20, sensor, heater);
        }

        
        [TestCase(45)]
        [TestCase(21)]
        [TestCase(20)]
        public void TestECSOverThreshold(int temp)
        {
            sensor.GetTemp().Returns(temp);
            
            uut.Regulate();

            //Assert.That(heater._check , Is.EqualTo(false));

            heater.Received(1).TurnOff();

        }
        [TestCase(19)]
        [TestCase(0)]
        [TestCase(-3)]
        public void TestECSUnderThreshold(int temp)
        {
            //sensor.gen = temp;

            //uut.Regulate();


            //Assert.That(heater._check, Is.EqualTo(true));

            sensor.GetTemp().Returns(temp);

            uut.Regulate();


            //Assert.That(heater._check , Is.EqualTo(false));

            heater.Received(1).TurnOn();

        }

        [TestCase(21)]
        [TestCase(0)]
        [TestCase(-2)]
        public void TestSetThreshold(int thr)
        {
            uut.SetThreshold(thr);

            Assert.That(uut.GetThreshold(), Is.EqualTo(thr));

        }

        [TestCase(21)]
        [TestCase(0)]
        [TestCase(-2)]
        public void TestGetCurTemp(int temp)
        {
            uut.GetCurTemp().Returns(temp);

            Assert.That(sensor.GetTemp(), Is.EqualTo(temp));

        }



        public class FakeSensor : ISensor
        {
            public int gen { get; set; }

            public int GetTemp()
            {
                return gen;
            }

        }

        public class FakeHeater : IRegulate
        {
            public bool _check;

            public void TurnOn()
            {
                _check = true;
                
            }

            public void TurnOff()
            {
                _check = false;
            }

        }
    }
}