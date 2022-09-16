using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventUpdate
{
    public class MainLogic : MonoBehaviour
    {
        [SerializeField]
        Character chara1;

        private void Start()
        {
            chara1.SetData("Character1", 100);
        }
    }
}
