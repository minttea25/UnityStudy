using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using TMPro;

namespace Timer
{
    public class Manager : MonoBehaviour
    {
        [SerializeField]
        TMP_Text text1;

        [SerializeField]
        TMP_Text text2;

        [SerializeField]
        Button btn1;

        [SerializeField]
        Button btn2;

        [SerializeField]
        TMP_Text btnText1;

        [SerializeField]
        TMP_Text btnText2;

        private bool toggle1 = false;
        private bool toggle2 = false;

        public void TimeOutCallback()
        {
            Debug.Log("Time's up!");
        }

        public void TimeOutCallback2()
        {
            Debug.Log("Time's up2!");
        }

        // Start is called before the first frame update
        void Start()
        {
            btn1.onClick.AddListener(Btn1Clicked);
            btn2.onClick.AddListener(Btn2Clicked);

            Timer.Instance.InitTimer(10f, text1, TimeOutCallback, true);
            Timer2.Instance.InitTimer(10f, text2, TimeOutCallback2, true);
        }

        public void Btn1Clicked()
        {
            if (!toggle1)
            {
                Timer.Instance.PauseTimer();
                btnText1.text = "Continue";
            }
            else
            {
                Timer.Instance.ContinueTimer();
                btnText1.text = "Pause";
            }

            toggle1 = !toggle1;
        }

        public void Btn2Clicked()
        {
            if (!toggle2)
            {
                Timer2.Instance.PauseTimer();
                btnText2.text = "Continue";
            }
            else
            {
                Timer2.Instance.ContinueTimer();
                btnText2.text = "Pause";
            }

            toggle2 = !toggle2;
        }
    }
}
