using UnityEngine;

namespace Test.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        public void DebugTest()
        {
            Debug.Log("DebugTest");
        }

        private void Start()
        {
            Debug.Log("GameManager Start Unity Function");
            Debug.Log("Check the hierarchy");
        }
    }
}
