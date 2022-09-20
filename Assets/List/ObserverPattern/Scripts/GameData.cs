using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class GameData : MonoBehaviour
    {
        #region Singleton

        static GameObject _gameData;
        static GameObject gameData { get { return _gameData; } }

        static GameData _instance = null;

        public static GameData Instance
        {
            get
            {
                if (!_instance)
                {
                    _gameData = new GameObject()
                    {
                        name = "GameData"
                    };
                    _instance = gameData.AddComponent(typeof(GameData)) as GameData;
                    DontDestroyOnLoad(_gameData);
                }

                return _instance;
            }
        }
        #endregion

        private readonly Dictionary<int, PlayableCharacter> charas = new Dictionary<int, PlayableCharacter>();

        public Dictionary<int, PlayableCharacter> Charas
        {
            get
            {
                return charas;
            }
        }

        public void InitData(Dictionary<TeamAB, List<GameObject>> characters)
        {
            foreach (TeamAB t in characters.Keys)
            {
                foreach (GameObject g in characters[t])
                {
                    int id = IdHandler.GetNewId();
                    PlayableCharacter p = new PlayableCharacter(g, id, t);
                    charas.Add(id, p);

                    Debug.Log("A playable character is created on GameData: " + p);
                }
            }
        }
    }
}