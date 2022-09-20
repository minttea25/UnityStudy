using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public interface ISubject
    {
        void AddObserver(IObserverCharacter o);
        void RemoveObserver(IObserverCharacter o);
        void NotifyObservers();
    }
}
