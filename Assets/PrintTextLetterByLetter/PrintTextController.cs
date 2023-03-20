using System.Collections;
using UnityEngine;
using TMPro;

using Test.Singleton;

namespace Test.PrintTextLetterByLetter
{
    public class PrintTextController : Singleton<PrintTextController>
    {
        private readonly char[] endSymbols = new char[] { '!', '.', '?' };

        public float EndInterval = 0.1f;
        public float CommaInterval = 0.1f;
        public float SpaceInterval = 0.1f;
        public float NormalInterval = 0.1f;

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
                yield return new WaitForSeconds(GetInterval(text[i]));
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
                yield return new WaitForSeconds(GetInterval(text[i]));
            }

            yield return null;
        }

        private float GetInterval(char c)
        {
            if (c == ',') return CommaInterval;
            if (c == ' ') return SpaceInterval;

            for (int i = 0; i < endSymbols.Length; i++)
            {
                if (c == endSymbols[i]) return EndInterval;
            }

            return NormalInterval;
        }
    }
}
