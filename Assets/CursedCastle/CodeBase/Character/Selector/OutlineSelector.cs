using System.Collections.Generic;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Selector
{
    public class OutlineSelector : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] renderers;
        [SerializeField] private Material outlineMaterial;

        private bool _isSelectedCash;

        public void SetSelected(bool isSelected)
        {
            if (isSelected == _isSelectedCash)
                return;

            for (int i = 0; i < renderers.Length; i++)
            {
                MeshRenderer render = renderers[i];
                AddOutlineMaterial(isSelected, render);
            }

            _isSelectedCash = isSelected;
        }

        private void AddOutlineMaterial(bool isSelected, MeshRenderer render)
        {
            List<Material> materials = new List<Material>();
            foreach (Material material in render.materials)
            {
                materials.Add(material);
            }

            if (isSelected)
                materials.Add(outlineMaterial);
            else
                materials.RemoveAt(materials.Count - 1);

            render.materials = materials.ToArray();
        }
    }
}
