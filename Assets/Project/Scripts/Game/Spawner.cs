using UnityEngine;

namespace game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Spawnable m_spawnable;

        private void OnTriggerEnter(Collider other)
        {
            Transform spawnTransform = Instantiate(this.m_spawnable).transform;
            spawnTransform.SetParent(base.transform.parent);
            spawnTransform.position = base.transform.position;

            Destroy(base.gameObject);
        }
    }
}