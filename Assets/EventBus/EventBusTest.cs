using UnityEngine;

// Pros
// Decoupling: Two objects don't need to know each other and refer eachother.
// Simple Codes

// Cons
// Performance: Low-mechaism managing messages between object in all internal event systems may cause a few cost for performance
// NOTE: It is relied on platforms.
// static (global) member: difficult for debugging

// EventBus handles subscribers.
// Subcribers subsribes the specify event types and the EventBus added the callback functions to delegate(UnityEvent) at the type.
// The delegate of each event types is managed with Dictionary type in this sample.
namespace Test.EventBus
{
    public class EventBusTest : MonoBehaviour
    {
        [SerializeField]
        CharacterController controller;

        private void Start()
        {
            SampleEventBus.Publish(SampleEventType.GAMESTART);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("ATTACK"))
            {
                controller.Attack();
            }

            if (GUILayout.Button("IDLE"))
            {
                controller.Idle();
            }
        }
    }
}
