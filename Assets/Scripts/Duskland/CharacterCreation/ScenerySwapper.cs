using UnityEngine;

namespace Duskland.CharacterCreation
{
    public class ScenerySwapper : MonoBehaviour
    {
        private int noClick = 0;
        public GameObject[] objList;

        private void onStart()
        {
            noClick = 1;
        }

        public void btnClick()
        {
            objList[noClick].SetActive(false);

            noClick++;

            if ((noClick) >= objList.Length)
            {
                noClick = 0;
            }
            objList[noClick].SetActive(true);
        }
    }
}
