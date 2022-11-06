using UnityEngine;

namespace game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Spawnable[] m_spawnables;

        private void OnTriggerEnter(Collider other)
        {
            Spawnable spawn = this.m_spawnables[Random.Range(0, this.m_spawnables.Length)];
            Transform spawnTransform = Instantiate(spawn).transform;
            spawnTransform.SetParent(base.transform.parent);
            spawnTransform.position = base.transform.position;

            Destroy(base.gameObject);
        }
    }
}