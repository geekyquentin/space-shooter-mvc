using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Models;
using SpaceShooter.Configs;
using SpaceShooter.Managers;
using SpaceShooter.Controllers;

namespace SpaceShooter.Core {
    public class Entity : MonoBehaviour {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [Header("Entity properties")]
        [SerializeField] protected float fireRate = 3f;
        [SerializeField] protected Projectile projectile;
        [SerializeField] protected ParticleSystem destructionFX;
        [SerializeField] protected ParticleSystem hitFX;
        [SerializeField] protected float maxHealth = 100f;
        #endregion --------------------------------------------

        #region ----------- Non-SeriailzeField -----------------
        private float currentHealth;
        private float nextFire;
        private IDamageable damageable;
        protected GameController gameController;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ------------- Public variables -------------
        public float MaxHealth { get => maxHealth; }
        public float CurrentHealth { get => currentHealth; }
        public GameController GameController { set => gameController = value; }
        #endregion -----------------------------------------

        #region ----------- Private Methods -----------------

        #region ----------- MonoBehaviour -----------------
        private void Awake() {
            damageable = GetComponent<IDamageable>();
        }

        private void Start() {
            currentHealth = maxHealth;
        }

        private void Update() {
            if (GameManager.Instance.GetCurrentGameState() != GameState.PLAY) { return; }

            if (Time.time <= nextFire) { return; }

            damageable.MakeAShot();
            nextFire = Time.time + 1 / fireRate;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(GameStrings.projectileTag)) {
                gameController.DealProjectileHit(this, other.GetComponent<Projectile>());
            }
        }
        #endregion --------------------------------------------

        #region ----------- Non-MonoBehaviour -----------------
        private void InstantiateFX(ParticleSystem fx) {
            float duration = fx.main.duration;
            GameObject fxObj = Instantiate(fx.gameObject, transform.position, Quaternion.identity);
            Destroy(fxObj, duration);
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Methods -----------------
        protected virtual void InstantiateProjectile(Vector2 pos, Vector3 rot) {
            Instantiate(projectile, pos, Quaternion.Euler(rot));
        }

        public virtual void DealDamage(float damage) {
            currentHealth = Mathf.Max(currentHealth - damage, 0);
        }

        public bool IsDead() {
            return currentHealth <= 0;
        }

        public virtual void Hit() {
            InstantiateFX(hitFX);
        }

        public void Die() {
            InstantiateFX(destructionFX);
            damageable.DeathBehaviour();
        }
        #endregion --------------------------------------------
    }
}