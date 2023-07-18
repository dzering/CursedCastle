using System.Collections;
using CursedCastle.CodeBase.Character.Interaction;
using CursedCastle.CodeBase.Character.Interaction.InteractablePart;
using UnityEngine;

namespace CursedCastle.CodeBase.Interactable
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private int angleRotation = 90;
        [SerializeField] private float rotationSmoothTime;
        [SerializeField] private InteractionTypeID interactionTypeID;

        public InteractionTypeID InteractionTypeID => interactionTypeID;

        private float _startRotation;
        private float _targetRotation;
        private Transform _transform;
        private float _currentRotation;
        private float _rotationVelocity;
        private bool _isUnlocked;
        private bool _isOpen;


        private void Start()
        {
            _startRotation = transform.eulerAngles.y;
            _targetRotation = _startRotation + angleRotation;
        }

        public void Interact(IInteracting interacting)
        {
            if (interacting!=null && interacting.InteractionTypeID == interactionTypeID)
            {
                OpenLock();
                Open(_isUnlocked);
            }
        }

        public void Interact()
        {
        }

        private void OpenLock()
        {
            if (!_isOpen)
                _isUnlocked = !_isUnlocked;
        }


        private void Open(bool isUnlocked)
        {
            if (isUnlocked)
            {
                if (_isOpen)
                    return;
                StartCoroutine(OpenDoor());
                _isOpen = true;
            }

            else
            {
                Debug.Log("Door is closed.");
            }
        }

        private IEnumerator OpenDoor()
        {
            while (_targetRotation > _currentRotation)
            {
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                yield return null;
            }
        }
        
        private IEnumerator CloseDoor()
        {
            while (_targetRotation > _currentRotation)
            {
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                yield return null;
            }
        }
    }
}