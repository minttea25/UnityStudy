using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    [RequireComponent(typeof(Slider))]
    public class HpBar : MonoBehaviour
    {
        [SerializeField]
        public Slider bar;

        private float maxhp = 100;

        public float CurrentHp;

        private void Update()
        {
            bar.value = CurrentHp / maxhp;
        }
    }
}
