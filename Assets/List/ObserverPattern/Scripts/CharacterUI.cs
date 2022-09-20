using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class CharacterUI : MonoBehaviour
    {
        new Camera camera;

        [SerializeField]
        HpBar hpBar;

        [SerializeField]
        Transform chara;

        public void UpdateCharacterStatus(int id)
        {
            hpBar.CurrentHp = GameData.Instance.Charas[id].Chara.Hp;
        }

        private void Start()
        {
            camera = Camera.main;

            hpBar.transform.position = chara.position;
        }

        private void Update()
        {
            hpBar.transform.position = camera.WorldToScreenPoint(chara.position + new Vector3(0, 1f, 0));
        }
    }
}