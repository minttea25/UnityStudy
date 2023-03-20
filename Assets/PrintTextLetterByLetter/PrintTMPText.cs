using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Test.PrintTextLetterByLetter
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PrintTMPText : MonoBehaviour
    {
        public float TimeInterval = 0.05f;
        public string text = string.Empty;

        private TextMeshProUGUI textMesh;
        private Coroutine _coroutine = null;

        public void ShowText()
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                Debug.LogWarning($"The text string is null or empty!");
                return;
            }

            _coroutine = StartCoroutine(PrintText());
        }

        public void SkipText()
        {
            if (_coroutine == null)
            {
                Debug.LogWarning($"There is not any coroutine to do skipping text! Use 'ShowText()' first.");
                return;
            }

            StopCoroutine(_coroutine);
            textMesh.text = text;
        }

        private IEnumerator PrintText()
        {
            textMesh.text = string.Empty;
            for (int i = 0; i < text.Length; ++i)
            {
                textMesh.text += text[i];
                yield return new WaitForSeconds(TimeInterval);
            }

            yield return null;
        }

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

    }
}
