using UnityEngine;
using UnityEngine.AI;

namespace game
{
    public class Enemy : Spawnable
    {
        [SerializeField] private EnemyType enemyType;

        [SerializeField] private float minDamage = 5f;
        [SerializeField] private float maxDamage = 25f;

        private Animator animator;
        private NavMeshAgent agent;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            animator.SetInteger("walk_variation", Random.Range(0, 3));
        }

        private void Update()
        {
            agent.SetDestination(PlayerController.Instance.transform.position);
            animator.SetFloat("speed", agent.speed);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < 5f)
                Attack();
        }

        private void Attack()
        {
            animator.SetInteger("attack_variation", Random.Range(0, 2));
            animator.SetTrigger("attack");
            PlayerController.Instance.ToggleMovement(false);
            PlayerController.Instance.getAttacked(Random.Range(minDamage, maxDamage));
        }

        public void Death()
        {
            animator.SetInteger("death_variation", Random.Range(0, 5));
            animator.SetTrigger("death");
            this.GetComponent<Collider>().enabled = false;
            PlayerController.Instance.ToggleMovement(true);
            agent.isStopped = true;
            this.enabled = false;
        }
    }
}