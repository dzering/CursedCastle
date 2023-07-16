using CursedCastle.CodeBase.Infrastructure;
using TMPro;
using UnityEngine;

namespace CursedCastle.CodeBase.UI.HUD
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Construct(InputService inputService)
        {
            // todo write to text a name of pressed key;
        }

    }
}