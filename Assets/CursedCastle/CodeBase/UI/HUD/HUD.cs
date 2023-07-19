using UnityEngine;

namespace CursedCastle.CodeBase.UI.HUD
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Crosshair crosshair;

        private void Start()
        {
            crosshair.gameObject.SetActive(true);
        }
    }
}