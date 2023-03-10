using UnityEngine;

namespace Test.Singleton
{
    public class TestScript : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.DebugTest();
        }

    }
}
