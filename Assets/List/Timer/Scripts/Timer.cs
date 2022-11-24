using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Timer
{
    /// <summary>
    /// This timer uses "Update" per frame.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        public static Timer Instance;

        public bool IsRunning { private set; get; } = false;

        private TMP_Text timeText;
        private float StartTime = -1f;
        private UnityAction timeOutCallback = null;
        private float timeRemaining = -1f;


        /// <summary>
        /// Initialize Timer with startTime, text for showing(optional), timeOutCallback(optional) and autoStart(optional)
        /// </summary>
        /// <param name="startTime">the time to start at</param>
        /// <param name="textObject">the text object to show time(seconds) for now</param>
        /// <param name="timeOutCallback">a function called when the timer is timeout</param>
        /// <param name="autoStart">whether the timer starts after InitTimer()</param>
        public void InitTimer(float startTime, TMP_Text textObject=null, UnityAction timeOutCallback=null, bool autoStart = false)
        {
            this.StartTime = startTime;
            timeText = textObject;
            this.timeOutCallback = timeOutCallback;

            if (autoStart)
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            timeRemaining = StartTime;
            IsRunning = true;
        }

        public void StopTimer()
        {
            IsRunning = false;
            timeRemaining = StartTime;
        }

        public void PauseTimer()
        {
            IsRunning = false;
        }

        public void ContinueTimer()
        {
            IsRunning = true;
        }

        private void Start()
        {
            Instance = this;
        }

        private void Update()
        {
            if (IsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    if (timeText != null)
                    {
                        timeText.text = Mathf.Ceil(timeRemaining).ToString();
                    }
                }
                else
                {
                    timeRemaining = 0;
                    IsRunning = false;
                    timeOutCallback?.Invoke();
                }
            }
        }
    }

}


