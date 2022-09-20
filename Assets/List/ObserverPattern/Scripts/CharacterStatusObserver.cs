using System.Collections;
using UnityEngine;

namespace ObserverPattern
{
    public class CharacterStatusObserver : IObserverCharacter
    {
        #region IObserver 

        public void OnNotify(int id)
        {
            Debug.Log($"CharacterStatusObserver.OnNotify({id})");

            if (!GameData.Instance.Charas.TryGetValue(id, out PlayableCharacter c))
            {
                Debug.LogError($"There is no character id = {id}");
                return;
            }
            UpdateData(c);
        }

        public void OnNotify(Character chara)
        {
            GameObject.Find("UIHandler").GetComponent<UIHandler>().CharacterUpdateUI(chara);
        }

        public void UpdateData<T>(T t)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}