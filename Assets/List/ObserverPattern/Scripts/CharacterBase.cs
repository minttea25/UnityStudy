using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    [CreateAssetMenu(fileName ="CharacterBase", menuName ="ObserverPattern/CharacterBase")]
    class CharacterBase : ScriptableObject
    {
        public CharacterType type;
        public new string name;
        public int hp;
    }
}
