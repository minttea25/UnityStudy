using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Test.PrintTextLetterByLetter
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField]
        string str = "All the world's a stage and all the man and woman are merely players!";

        [SerializeField]
        TextMeshProUGUI Text;

        [SerializeField]
        TextMeshProUGUI Text2;

        [SerializeField]
        PrintTMPText TextEx;

        [SerializeField]
        PrintTMPText TextExClickTest;

        [SerializeField]
        Button SkipButton;


        private void Start()
        {
            // When the button is clicked, showing text of TextExClickTest would be stopped and print the whole text.
            SkipButton.onClick.AddListener(() => { TextExClickTest.SkipText(); });

            // 1. Using PrintTextController
            PrintTextController.Instance.EndInterval = 1.5f;
            PrintTextController.Instance.NormalInterval = 0.05f;
            PrintTextController.Instance.PrintText(Text, str, 1f);

            // 2. Using PrintTextControllerSimple
            PrintTextControllerSimple.Instance.TimeInterval = 0.08f;
            PrintTextControllerSimple.Instance.PrintText(Text2, str);

            // 3. Using PrintTMPText (Monobehaviour; You need to add component at the GameObject to print text.)
            TextEx.text = str;
            TextEx.ShowText();

            // 3-1. Test SkipText() function
            TextExClickTest.text = str;
            TextExClickTest.TimeInterval = 0.2f;
            TextExClickTest.ShowText();
        }
    }
}


