using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void AddObserver(Observer observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(System.Object entity)
        {
            foreach (var observer in _observers)
            {
                observer.OnNotify(entity);
            }
        }
    }
}
