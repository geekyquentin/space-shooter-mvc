using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Models;
using SpaceShooter.Managers;

namespace SpaceShooter.Core {
    public class Entity : MonoBehaviour {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private float fireRate = 3f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private ParticleSystem destructionFX;
        [SerializeField] private ParticleSystem hitFX;
        #endregion --------------------------------------------

        #region ----------- Non-SeriailzeField -----------------
        private float currentHealth;
        private float nextFire;
        private IDamageable damageable;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Private Methods -----------------

        #region ----------- MonoBehaviour -----------------
        private void Awake() {
            damageable = GetComponent<IDamageable>();
        }

        private void Update() {
            if (GameManager.Instance.GetCurrentGameState() != GameState.PLAY) { return; }

            if (Time.time <= nextFire) { return; }

            damageable.MakeAShot(projectile);
            nextFire = Time.time + 1 / fireRate;
        }
        #endregion --------------------------------------------

        #region ----------- Non-MonoBehaviour -----------------
        private void InstantiateFX(ParticleSystem fx) {
            float duration = fx.main.duration;
            GameObject fxObj = Instantiate(fx.gameObject, transform.position, Quaternion.identity);
            Destroy(fxObj, duration);
        }
        #endregion --------------------------------------------

        #endregion

        #region ----------- Public Methods -----------------
        public void Hit() {
            InstantiateFX(hitFX);
        }

        public void Die() {
            InstantiateFX(destructionFX);
            damageable.DeathBehaviour();
        }
        #endregion --------------------------------------------
    }
}
