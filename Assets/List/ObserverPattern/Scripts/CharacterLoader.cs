using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    class CharacterLoader
    {
        public static CharacterBase GetCharacter(CharacterType type)
        {
            return type switch
            {
                CharacterType.TestCharacter => Resources.Load<CharacterBase>("ObserverPattern/Characters/TestCharacter"),
                _ => null,
            };
        }
    }
}
