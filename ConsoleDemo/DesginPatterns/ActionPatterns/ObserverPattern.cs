using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ActionPatterns
{
    /// <summary>
    /// 观察者模式定义了对象之间的一对多依赖关系，
    /// 这样一来，当一个对象改变状态时，它的所有依赖者都会收到通知并且自动更新。
    /// </summary>
    public sealed class ObserverPattern
    {
        public static void Test()
        {
            WeatherData wData = new WeatherData();
            CurrentWeatherDisplay display = new CurrentWeatherDisplay(wData);

            wData.SetWeatherData(10, 20, 50);
            wData.SetWeatherData(11, 25, 60);
            wData.SetWeatherData(30, 40, 70);
        }
    }

    public interface IObserver
    {
         void Update(float temp, float humidity, float pressure);
    }

    public interface IDisplay
    {
        void Display();
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void NotifyObserver();
    }

    public class WeatherData : ISubject
    {

        private List<IObserver> observerList;

        private float _temperature;

        private float _humidity;

        private float _pressure;

        public WeatherData()
        {
            observerList = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observerList.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observerList.Remove(observer);
        }

        public void NotifyObserver()
        {
            foreach (var obs in observerList)
            {
                obs.Update(_temperature, _humidity, _pressure);
            }
        }

        private void MeasurementChanged()
        {
            NotifyObserver();
        }

        public void SetWeatherData(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            MeasurementChanged();
        }
    }


    public class CurrentWeatherDisplay : IObserver, IDisplay
    {
        private float _temperature;

        private float _humidity;

        private float _pressure;

        private ISubject _weatherData;

        public CurrentWeatherDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }


        public void Update(float temp, float humidity, float pressure)
        {
            _temperature = temp;
            _humidity = humidity;
            _pressure = pressure;

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Temperature:{0},Humidity:{1},Pressure:{2}",_temperature,_humidity,_pressure);
        }
    }


}
