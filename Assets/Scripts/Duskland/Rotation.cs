using UnityEngine;

namespace Duskland
{
    public class Rotation : MonoBehaviour
    {
        private float scrollSpeed = 0.1f;
        public Material skybox;

        private void FixedUpdate()
        {
            float offset = Time.deltaTime * scrollSpeed;

            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(scrollSpeed, 0));
        }
    }
}
