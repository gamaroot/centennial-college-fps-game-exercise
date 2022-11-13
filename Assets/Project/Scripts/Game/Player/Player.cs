using UnityEngine;

namespace game
{
    [RequireComponent(typeof(PlayerController))]
    public class Player : MonoBehaviour, IPlayer
    {
        [Header("Components")]
        [SerializeField] private PlayerController m_controller;

        private float m_health = 100f;

        private void OnValidate()
        {
            if (m_controller == null)
                this.m_controller = base.GetComponent<PlayerController>();
        }

        public void OnGetAttacked(float damage)
        {
            this.m_health -= damage;

            if (this.m_health <= 0f)
                this.Die();
        }

        public void OnPathBlocked()
        {
            this.m_controller.ToggleMovement(false);
        }

        public void OnPathUnblocked()
        {
            this.m_controller.ToggleMovement(true);
        }

        public Vector3 GetPosition()
        {
            return base.transform.position;
        }

        private void Die()
        {
            Debug.Log("Player has Died!");
        }
    }
}