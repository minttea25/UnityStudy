using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    [RequireComponent(typeof(Button))]
    public class DamageBtn : MonoBehaviour
    {
        [SerializeField]
        Character chara;

        const int dmgAmount = 10;

        public void OnBtnClicked()
        {
            chara.Damage(dmgAmount);
        }

        private void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(OnBtnClicked);
        }
    }
}