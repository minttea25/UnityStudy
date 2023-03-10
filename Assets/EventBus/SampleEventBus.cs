using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Test.EventBus
{
    public enum SampleEventType
    {
        IDLE, ATTACK, DEFENSE, GAMESTART, GAMEOVER
    }
    public class SampleEventBus : MonoBehaviour
    {
        private static readonly Dictionary<SampleEventType, UnityEvent> events = new();

        public static void Subsribe(SampleEventType eventType, UnityAction listener)
        {
            if (events.TryGetValue(eventType, out UnityEvent ev))
            {
                ev.AddListener(listener);
            }
            else
            {
                ev = new UnityEvent();
                ev.AddListener(listener);
                events.Add(eventType, ev);
            }
        }

        public static void Unsubscribe(SampleEventType eventType, UnityAction listener)
        {
            if (events.TryGetValue(eventType, out UnityEvent ev))
            {
                ev.RemoveListener(listener);
            }
        }

        public static void Publish(SampleEventType eventType)
        {
            if (events.TryGetValue(eventType, out UnityEvent ev))
            {
                ev.Invoke();
            }
        }
    }
}
