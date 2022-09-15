using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EventUpdate
{
    public class Character : MonoBehaviour
    {
        private readonly object hp_lock = new object();

        int hp;
        new string name;

        public int Hp { 
            get
            {
                return hp;
            } 
            set
            {
                if (value >= 0)
                {
                    UpdateUI_hp(value);
                    hp = value;
                }
                else
                {
                    Debug.Log("Hp value can not be under 0");
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void SetData(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }

        public void UpdateUI_hp(int hp)
        {
            lock(hp_lock)
            {
                Debug.Log("UpdateUI-hp called: " + hp);
                StartCoroutine(nameof(IUpdateUI), hp);
            }
            
        }

        IEnumerator IUpdateUI(int hp)
        {
            // Update UI
            GameObject hptext_obj = GameObject.Find("HpText");

            if (hptext_obj)
            {
                hptext_obj.GetComponent<TMP_Text>().text = hp.ToString();
            }
            else
            {
                Debug.LogError("Can not find a Gameobject named: 'HpText'");
            }

            yield return null;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, now Hp: {1}", name, hp);
        }
    }
}
