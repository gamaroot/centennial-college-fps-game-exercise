using UnityEngine;

namespace game
{
    public class GameManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Player player;
        [SerializeField] Transform spawners;
        [SerializeField] ScoreDisplay scoreDisplay;

        public void OnDeath()
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            Spawner[] spawners = this.spawners.GetComponentsInChildren<Spawner>();
            foreach (Spawner spawner in spawners)
                spawner.Setup(this.player, this.scoreDisplay.OnKill);
        }
    }
}