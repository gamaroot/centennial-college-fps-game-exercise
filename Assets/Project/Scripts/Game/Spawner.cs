using UnityEngine;

namespace game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Spawnable[] m_spawnables;

        private void OnTriggerEnter(Collider other)
        {
            Spawnable spawn = this.m_spawnables[Random.Range(0, this.m_spawnables.Length)];
            Transform spawnTransform = Instantiate(spawn, transform.position, Quaternion.identity).transform;
            spawnTransform.position = this.transform.position + new Vector3(0,1,0);

            Destroy(gameObject);
        }
    }
}