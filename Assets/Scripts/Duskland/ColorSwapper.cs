using UnityEngine;

namespace Duskland
{
    public class ColorSwapper : MonoBehaviour
    {
        public ColorPicker picker;
        private Color haircolor;
        public string bodypart;

        // Update is called once per frame
        private void Update()
        {
            gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor(bodypart, picker.CurrentColor);
        }
    }
}
