using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.InputSystem;
using UnityEngine;

namespace CursedCastle.Animations
{
    public class TestAnim : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private InputProvider inputProvider;
        private bool isActive;

        private void Start()
        {
            inputProvider = AllServices.Container.Single<IInputService>().InputProvider;
            inputProvider.OnUseAction += ButtonAction;
            isActive = false;
        }

        private void ButtonAction()
        {
            SwitchAnimation(isActive);
            isActive = !isActive;
        }

        private void SwitchAnimation(bool isActive)
        {
            _animator.SetBool("Color", isActive);
            _animator.SetBool("Vertical", !isActive);
        }
    }
}
