using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Test.Singleton;

namespace Test.PrintTextLetterByLetter

{
    public class PrintTextControllerSimple : Singleton<PrintTextControllerSimple>
    {
        public float TimeInterval = 0.05f;

        public void PrintText(TextMeshProUGUI textMesh, string text)
        {
            StartCoroutine(PrintTextCo(textMesh, text));
        }

        public void PrintText(TextMeshProUGUI textMesh, string text, float preInterval = 0.0f)
        {
            StartCoroutine(PrintTextCo(textMesh, text, preInterval = 0.0f));
        }

        public IEnumerator PrintTextCo(TextMeshProUGUI textMesh, string text)
        {
            textMesh.text = string.Empty;
            for (int i = 0; i < text.Length; ++i)
            {
                textMesh.text += text[i];
                yield return new WaitForSeconds(TimeInterval);
            }

            yield return null;
        }

        public IEnumerator PrintTextCo(TextMeshProUGUI textMesh, string text, float preInterval = 0.0f)
        {
            yield return new WaitForSeconds(preInterval);

            textMesh.text = string.Empty;
            for (int i = 0; i < text.Length; ++i)
            {
                textMesh.text += text[i];
                yield return new WaitForSeconds(TimeInterval);
            }

            yield return null;
        }
    }
}
