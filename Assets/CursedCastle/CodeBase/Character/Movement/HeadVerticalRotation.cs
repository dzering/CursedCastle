using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.Character.Movement
{
    public class HeadVerticalRotation : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float threshold;
        [SerializeField] private float scaleDeltaTimeMultiplier = 0.5f;

        private IInput _input;
        private PlayerInput _playerInput;
        private float _targetYmove;
        private Vector3 _startRotation;
        public bool LockCameraPosition { get; set; }

        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
            }
        }


        public void Construct(IInput input, PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _input = input;
        }

        private void Start()
        {
            IInputService inputService = AllServices.Container.Single<IInputService>();
            _playerInput = inputService.PlayerInput;
            _input = inputService.InputProvider;
            _startRotation = target.localRotation.eulerAngles;
            _targetYmove = _startRotation.x;
        }

        private void LateUpdate() => 
            TargetMovement();

        public void TargetMovement()
        {
            if (_input.Look.sqrMagnitude >= threshold && !LockCameraPosition)
            {
                //Don't multiply mouse input by Time.deltaTime;
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? scaleDeltaTimeMultiplier : Time.deltaTime;

                _targetYmove += _input.Look.y * deltaTimeMultiplier;
                //_targetYmove = ClampAngle(_targetYmove,float.MinValue, float.MinValue);
                //_cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
                target.localRotation = Quaternion.Euler(_startRotation.x + _targetYmove, 0, 0);
            }
        }
        
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}