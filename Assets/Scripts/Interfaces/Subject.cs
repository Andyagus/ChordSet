using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(System.Object entity)
        {
            if (_observers == null) return;
            foreach (var observer in _observers)
            {
                observer.OnNotify(entity);
            }
        }
    }
}
