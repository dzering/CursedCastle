using UnityEngine;

namespace CursedCastle.InputSystem
{
    public class CursorBehavior : ICursor
    {
        public CursorBehavior()
        {
            OnUIFocus(false);
        }

        public void OnUIFocus(bool hasUI)
        {
            SetCursorState(!hasUI);
            SetCursorVisible(hasUI);
        }

        private static void SetCursorVisible(bool hasUI) => 
            Cursor.visible = hasUI;

        private void SetCursorState(bool newState) => 
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}