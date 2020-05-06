using UnityEngine;

namespace FIMSpace.Basics
{
    /// <summary>
    /// FM: Just destroys gameObject after given time
    /// </summary>
    public class FBasic_DestroyAfter : MonoBehaviour
    {
        public float SecondsToDestroy = 5f;

        private void Start()
        {
            GameObject.Destroy(gameObject, SecondsToDestroy);
            Destroy(this);
        }
    }
}