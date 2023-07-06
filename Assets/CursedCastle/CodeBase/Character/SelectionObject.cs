using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CursedCastle.CodeBase.Character
{
    public class SelectionObject : MonoBehaviour
    {
        private Selectable _currentSelected;
        private readonly int _layerMask = 1 << 6;
        private Camera _camera;
        private Ray _ray;
        private RaycastHit _hit;

        private void Start()
        {
            _camera = Camera.main;
            _ray = new Ray(_camera.transform.position, _camera.transform.forward);
        }

        private void Update()
        {
            ThrowRay();
            if (_hit.collider.TryGetComponent(out Selectable selectable))
            {
                Select(selectable);
            }

        }

        private void ThrowRay()
        {
            if (Physics.Raycast(_ray, out _hit, 100f, _layerMask))
                Debug.Log(_hit.collider.name);
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 100, Color.green);
        }

        private void Select(Selectable selectable)
        {
            if (selectable != null && _currentSelected == selectable)
                return;

            _currentSelected = selectable;
        }
    }

    abstract class Interactable : MonoBehaviour
    {
    }

    abstract class Selectable : Interactable
    {
        
    }
}