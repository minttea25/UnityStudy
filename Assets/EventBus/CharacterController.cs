using UnityEngine;

namespace Test.EventBus
{
    public class CharacterController : MonoBehaviour
    {
        public void Attack()
        {
            SampleEventBus.Publish(SampleEventType.ATTACK);
        }

        public void Idle()
        {
            SampleEventBus.Publish(SampleEventType.IDLE);
        }

        public void PlayIdleAnimation()
        {
            Debug.Log($"Now playing IDLE animation... : {gameObject.name}");
            transform.localScale = new Vector3(1, 1, 1);
        }

        public void PlayAttackAnimation()
        {
            Debug.Log($"Now playing ATTACK animation... : {gameObject.name}");
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        private void OnEnable()
        {
            SampleEventBus.Subsribe(SampleEventType.IDLE, PlayIdleAnimation);
            SampleEventBus.Subsribe(SampleEventType.ATTACK, PlayAttackAnimation);
        }

        private void OnDisable()
        {
            SampleEventBus.Unsubscribe(SampleEventType.IDLE, PlayIdleAnimation);
            SampleEventBus.Unsubscribe(SampleEventType.ATTACK, PlayAttackAnimation);
        }

        private void Start()
        {
            SampleEventBus.Publish(SampleEventType.IDLE);
        }
    }
}
