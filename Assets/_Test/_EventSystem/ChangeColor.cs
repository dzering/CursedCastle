using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _Test._EventSystem
{
    public class ChangeColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Material _material;
        private Color _color;
        private void Start()
        {
            _material = GetComponent<Image>().material;
            _color = _material.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _material.color = Random.ColorHSV();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _material.color = _color;
        }
    }
}
