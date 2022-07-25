using System;
using System.Collections.Generic;
namespace ORION.DBTest
{

    public interface ItrackChangesNotificationSubject
    {
        void registerObserver(Observer o);
        void removeObserver(Observer o);
        void notifyObserver();

    }

    public interface Observer
    {
        void update(float temperature, float humidity, float pressure);
    }

    public interface DisplayElement
    {
        void display();
    }

    public class WeatherData : ItrackChangesNotificationSubject
    {
        private List<Observer> observers;
        private float temperature;
        private float humudity;
        private float pressure;
        public WeatherData()
        {
            observers = new List<Observer>();
        }
        public void notifyObserver()
        {
            //FIXME Use an array instead of a list
            // for (var i = 0; i < observers.Count; i++)
            // {
            //     observer.update(temperature, humudity, pressure);
            // }
            
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(o);
            }
            else
            {
                throw new ArgumentNullException("Argument cannot be less than 0.");
            }
        }

        public void measurementsChanged()
        {
            notifyObserver();
        }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humudity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }
    public class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        private ItrackChangesNotificationSubject weatherData;

        public CurrentConditionsDisplay(ItrackChangesNotificationSubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        public void display()
        {
            System.Console.WriteLine("Current conditions: " + temperature + "F degrees and  " + humidity + "% humudity");
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
    }
}