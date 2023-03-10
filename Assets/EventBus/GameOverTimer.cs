using System.Collections;
using UnityEngine;

namespace Test.EventBus
{
    public class GameOverTimer : MonoBehaviour
    {
        [SerializeField]
        CharacterController character;

        [SerializeField]
        float duration = 5.0f;

        private float _currentTime;

        public void GameOver()
        {
            Debug.Log("GameOver!!!");
            Destroy(character.gameObject);
        }

        public void StartTimer()
        {
            Debug.Log("StartTimer");
            StartCoroutine(CountDown());
        }

        IEnumerator CountDown()
        {
            _currentTime = duration;

            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }

            SampleEventBus.Publish(SampleEventType.GAMEOVER);
        }

        private void OnEnable()
        {
            SampleEventBus.Subsribe(SampleEventType.GAMESTART, StartTimer);
            SampleEventBus.Subsribe(SampleEventType.GAMEOVER, GameOver);
        }

        private void OnDisable()
        {
            SampleEventBus.Unsubscribe(SampleEventType.GAMESTART, StartTimer);
            SampleEventBus.Unsubscribe(SampleEventType.GAMEOVER, GameOver);
        }

        private void OnGUI()
        {
            GUIStyle style = new();
            style.fontSize = 50;
            GUI.Label(new Rect(500, 300, 200, 70), _currentTime.ToString(), style);
        }
    }
}
