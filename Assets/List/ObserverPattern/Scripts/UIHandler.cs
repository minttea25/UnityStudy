using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        CharacterUI characterUI = null;
        public CharacterUI CharaUI
        {
            get
            {
                if (!characterUI)
                {
                    FindCharacterUI();
                }
                return characterUI;
            }
        }

        public void CharacterUpdateUI(int id)
        {
            // update ui about the character (id == id)
            characterUI.UpdateCharacterStatus(id);

            Debug.LogFormat("Character (id = {0}) UI is updated", id);
        }

        public void CharacterUpdateUI(Character chara)
        {
            foreach (PlayableCharacter c in GameData.Instance.Charas.Values)
            {
                Debug.Log("GameData.Instacne.Chara.Hash = " + c.Chara.GetHashCode());
                if (c.Chara == chara)
                {
                    CharacterUpdateUI(c.Id);
                }
            }
        }

        private void FindCharacterUI()
        {
            GameObject g = GameObject.Find("CharacterUI");
            if (!g)
            {
                characterUI = g.GetComponent<CharacterUI>();

                if (characterUI)
                {
                    Debug.Log($"Can not find component: 'CharacterUI' in {g}");
                }
            }
            else
            {
                Debug.Log($"Can not find GameObject named 'CharacterUI'");
            }
        }


        private void Start()
        {
            FindCharacterUI();
        }

    }
}