using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class PlayableCharacter
    {
        private readonly int id;
        private readonly TeamAB team;
        private readonly GameObject charaObject;
        private readonly Character baseCharacter;

        public Character Chara
        {
            get
            {
                return baseCharacter;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        
        public PlayableCharacter(GameObject chara, int id, TeamAB team)
        {
            charaObject = chara;
            this.id = id;
            this.team = team;
            baseCharacter = chara.GetComponent<Character>();

            if (!baseCharacter)
            {
                Debug.LogError("Can not find the component : Character in Gameobject : " + charaObject);
            }
        }

        public override string ToString()
        {
            if (!baseCharacter)
            {
                return "Can not find the component : Character in Gameobject: " + charaObject;
            }
            return string.Format("[id: {0}, team: {1}, type: {2}]", id, team, baseCharacter.Type);
        }
    }
}