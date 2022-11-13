using UnityEngine;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Player player;
        [SerializeField] Transform spawners;

        private void Awake()
        {
            Spawner[] spawners = this.spawners.GetComponentsInChildren<Spawner>();
            foreach (Spawner spawner in spawners)
                spawner.Setup(this.player);
        }
    }
}