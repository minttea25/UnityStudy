using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using TMPro;

namespace Timer
{
    /// <summary>
    /// This timer uses "Coroutine"
    /// </summary>
    public class Timer2 : MonoBehaviour
    {
        public static Timer2 Instance;

        /// <summary>
        /// This value must be less then 1.0f
        /// </summary>
        private const float timeCheckInterval = 0.5f;

        private TMP_Text timeText;
        private float time = -1;
        private float timeLimit = -1;
        private UnityAction callback = null;
        public bool TimerRunning { private set; get; } = false;

        /// <summary>
        /// Initialize Timer with startTime, text for showing(optional), timeOutCallback(optional) and autoStart(optional)
        /// </summary>
        /// <param name="timeLimit">the time to start at</param>
        /// <param name="text">the text object to show time(seconds) for now</param>
        /// <param name="callback">a function called when the timer is timeout</param>
        /// <param name="autoStart">whether the timer starts after InitTimer()</param>
        public void InitTimer(float timeLimit, TMP_Text text = null, UnityAction callback = null, bool autoStart = false)
        {
            this.timeLimit = timeLimit;
            timeText = text;
            this.callback = callback;

            if (autoStart)
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            if (timeLimit == -1)
            {
                return;
            }

            time = 0;
            TimerRunning = true;
            StartCoroutine(Timer());
        }

        public void StopTimer()
        {
            TimerRunning = false;
            time = 0;
        }

        public void PauseTimer()
        {
            TimerRunning = false;
        }

        public void ContinueTimer()
        {
            TimerRunning = true;
            StartCoroutine(Timer());
        }
        IEnumerator Timer()
        {
            while (true)
            {
                if (TimerRunning == false)
                {
                    break;
                }

                float t = Mathf.Ceil(timeLimit - time);

                if (t >= timeCheckInterval)
                {
                    if (timeText != null)
                    {
                        timeText.text = t.ToString();
                    }

                    time += timeCheckInterval;
                    yield return new WaitForSeconds(timeCheckInterval);
                }
                else
                {
                    if (timeText != null)
                    {
                        timeText.text = "0";
                    }
                    callback?.Invoke();
                    break;
                }
            }
        }

        private void Start()
        {
            Instance = this;
        }
    }
}
