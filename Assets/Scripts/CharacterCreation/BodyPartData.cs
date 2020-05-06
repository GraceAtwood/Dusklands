using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Duskland.CharacterCreation
{
    public class BodyPartData
    {
        public List<GameObject> Meshes{ get; }

        private int _selectedIndex = 0;

        public BodyPartData(IEnumerable<GameObject> meshes)
        {
            Meshes = new List<GameObject>(meshes);
        }

        public void ApplyLeft()
        {
            Meshes[_selectedIndex].SetActive(false);

            if (_selectedIndex > 0)
                _selectedIndex--;
            else
                _selectedIndex = Meshes.Count - 1;

            Meshes[_selectedIndex].SetActive(true);
        }

        public void ApplyRight()
        {
            Meshes[_selectedIndex].SetActive(false);

            if (_selectedIndex < Meshes.Count - 1)
                _selectedIndex++;
            else
                _selectedIndex = 0;

            Meshes[_selectedIndex].SetActive(true);
        }

        public void Hide()
        {
            Meshes[_selectedIndex].SetActive(false);
        }

        public void Show()
        {
            Meshes[_selectedIndex].SetActive(true);
        }

        public void ApplyRandom()
        {
            Meshes[_selectedIndex].SetActive(false);

            _selectedIndex = Random.Range(0, Meshes.Count - 1);
            
            Meshes[_selectedIndex].SetActive(true);
        }
    }
}
