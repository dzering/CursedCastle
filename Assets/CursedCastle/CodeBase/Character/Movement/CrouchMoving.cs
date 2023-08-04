using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.InputSystem;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Movement
{
    public class CrouchMoving : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private IInput _inputProvider;
        private bool _isCrouch;
        private static readonly int Crouch = Animator.StringToHash("Crouch");

        private void Start()
        {
            _animator ??= GetComponentInChildren<Animator>();
            _inputProvider =  AllServices.Container.Single<IInputService>().InputProvider;
            _inputProvider.OnCrouchToggle += Crouching;
        }

        private void Crouching()
        {
            _isCrouch = !_isCrouch;
            _animator.SetBool(Crouch, _isCrouch);
        }
    }
}
