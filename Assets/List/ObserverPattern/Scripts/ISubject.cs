using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public interface ISubject
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public interface ISubject<T>
    {
        void AddObserver(IObserver<T> o);
        void RemoveObserver(IObserver<T> o);
        void NotifyObservers();
    }
}
