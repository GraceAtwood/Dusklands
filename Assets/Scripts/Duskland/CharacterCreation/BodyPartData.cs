using System.Collections.Generic;
using UnityEngine;

namespace Duskland.CharacterCreation
{
    public class BodyPartData
    {
        public List<GameObject> Meshes{ get; }

        private int selectedIndex;

        public BodyPartData(IEnumerable<GameObject> meshes)
        {
            Meshes = new List<GameObject>(meshes);
        }

        public void ApplyLeft()
        {
            Meshes[selectedIndex].SetActive(false);

            if (selectedIndex > 0)
                selectedIndex--;
            else
                selectedIndex = Meshes.Count - 1;

            Meshes[selectedIndex].SetActive(true);
        }

        public void ApplyRight()
        {
            Meshes[selectedIndex].SetActive(false);

            if (selectedIndex < Meshes.Count - 1)
                selectedIndex++;
            else
                selectedIndex = 0;

            Meshes[selectedIndex].SetActive(true);
        }

        public void Hide()
        {
            Meshes[selectedIndex].SetActive(false);
        }

        public void Show()
        {
            Meshes[selectedIndex].SetActive(true);
        }

        public void ApplyRandom()
        {
            Meshes[selectedIndex].SetActive(false);

            selectedIndex = Random.Range(0, Meshes.Count - 1);
            
            Meshes[selectedIndex].SetActive(true);
        }
    }
}
