using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EventUpdate
{
    [RequireComponent(typeof(Button))]
    public class DamageBtn : MonoBehaviour
    {
        [SerializeField]
        Character character;

        [SerializeField]
        TMP_Text btnText;

        [SerializeField]
        int DMG_AMOUNT = 10;

        public int DmgAmount
        {
            get
            {
                DmgAmount = DMG_AMOUNT;
                return DMG_AMOUNT;
            }
            set
            {
                btnText.text = "Damage: " + value;
            }
        }

        Button btn;

        public void OnClick_Damage()
        {
            Debug.Log("Damage to Character: " + DMG_AMOUNT);
            character.Hp -= DMG_AMOUNT;
        }

        private void Start()
        {
            btn = GetComponent<Button>();

            if (btn)
            {
                btn.onClick.AddListener(OnClick_Damage);
            }
            else
            {
                Debug.LogError("Can not find Component: Button");
            }
        }
    }
}
