using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ObserverPattern
{
    class MainLogic : MonoBehaviour
    {
        // for test
        [SerializeField]
        GameObject TestCharacter;

        private void Start()
        {
            Dictionary<TeamAB, List<GameObject>> dict = new Dictionary<TeamAB, List<GameObject>>();
            List<GameObject> list = new List<GameObject>
            {
                TestCharacter
            };
            dict.Add(TeamAB.A, list);

            GameData.Instance.InitData(dict);

            foreach(PlayableCharacter c in GameData.Instance.Charas.Values)
            {
                c.Chara.AddObserver(new CharacterStatusObserver());
            }
        }
    }
}
