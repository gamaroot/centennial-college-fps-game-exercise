using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    [RequireComponent(typeof(DOTweenPath))]
    public class PlayerController : PlayerShooter
    {
        public static PlayerController Instance { get; private set; }

        private float health = 100f;

        [Header("Components")]
        [SerializeField] private DOTweenPath tweenPath;
        [SerializeField] private Transform path;

        private void OnValidate()
        {
            if (this.tweenPath == null)
                this.tweenPath = base.GetComponent<DOTweenPath>();

            var pathWayPoints = new List<Vector3>();
            int totalWayPoints = this.path.childCount;

            for (int index = 0; index < totalWayPoints; index++)
            {
                Transform pathSegment = this.path.GetChild(index);
                pathWayPoints.Add(pathSegment.position);
            }
            this.tweenPath.wps = pathWayPoints;
        }

        private void Awake()
        {
            base.Awake();
            Instance = this;
            Destroy(this.path.gameObject);
        }

        public void ToggleMovement(bool status)
        {
            if (status)
                this.DOPlay();
            else
                this.DOPause();
        }

        public void getAttacked(float damage)
        {
            health -= damage;

            if (health <= 0f)
                Die();
        }
        public void Die()
        {
            Debug.Log("Died!");
        }
    }
}