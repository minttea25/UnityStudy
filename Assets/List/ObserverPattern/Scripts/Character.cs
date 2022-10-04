using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class Character : MonoBehaviour, ISubject<Character>
    {
        [SerializeField] CharacterType type;
        int level;
        new string name;
        int hp;

        List<IObserver<Character>> observers = new List<IObserver<Character>>();

        public CharacterType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }

        public void Damage(int value)
        {
            hp -= value;
            NotifyObservers();
        }

        #region ISubject Methods
        public void AddObserver(IObserver<Character> o)
        {
            if (observers.IndexOf(o) < 0)
            {
                observers.Add(o);
            }
            else
            {
                Debug.LogError("The observer already exists in list: " + o);
            }
        }

        public void RemoveObserver(IObserver<Character> o)
        {
            int idx = observers.IndexOf(o);
            if (idx >= 0)
            {
                observers.RemoveAt(idx); // O(n)
            }
            else
            {
                Debug.LogError("Can not remove the observer; It does not exist in list: " + o);
            }
        }

        public void NotifyObservers()
        {
            foreach (IObserver<Character> o in observers)
            {
                Debug.Log("Character.hash: " + this.GetHashCode());
                o.OnNotify(this);
            }
        }
        #endregion

        private void Start()
        {
            CharacterBase b = CharacterLoader.GetCharacter(type);

            this.hp = b.hp;
            this.name = b.name;
        }
    }
}
