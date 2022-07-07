using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Managers;
using SpaceShooter.Controllers;
using SpaceShooter.Configs;
using SpaceShooter.Core;

namespace SpaceShooter.Views {
    public class PlayerView : Entity, IDamageable {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [Header("Player properties")]
        [SerializeField] private float speed = 30f;
        [Range(1, 4)]
        [SerializeField] private int weaponPower = 1;

        [Header("Player Guns")]
        [SerializeField] private ParticleSystem leftGun;
        [SerializeField] private ParticleSystem centralGun;
        [SerializeField] private ParticleSystem rightGun;
        #endregion --------------------------------------------

        #region ----------- Non-SerializeField -----------------
        private int maxWeaponPower = 4;
        private PlayerController playerController;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Variables -----------------
        public float Speed { get => speed; }
        public int WeaponPower { get => weaponPower; set => weaponPower = value; }
        public int MaxWeaponPower { get => maxWeaponPower; }
        public PlayerController PlayerController { set => playerController = value; }
        #endregion --------------------------------------------

        #region ----------- Private Methods -----------------

        #region ----------- Monobehaviour -----------------
        protected override void OnTriggerEnter2D(Collider2D other) {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag(GameStrings.powerUpTag)) {
                playerController.DealPowerUpEquip();
                Destroy(other.gameObject);
            }
        }
        #endregion --------------------------------------------

        #region ----------- Non-Monobehaviour -----------------
        protected override void InstantiateProjectile(Vector2 pos, Vector3 rot) {
            base.InstantiateProjectile(pos, rot);
            AudioManager.Instance.PlayOnPlayerShoot();
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Methods -----------------
        public void MakeAShot() {
            switch (weaponPower) {
                case 1:
                    InstantiateProjectile(centralGun.transform.position, Vector3.zero);
                    centralGun.Play();
                    break;
                case 2:
                    InstantiateProjectile(rightGun.transform.position, Vector3.zero);
                    leftGun.Play();
                    InstantiateProjectile(leftGun.transform.position, Vector3.zero);
                    rightGun.Play();
                    break;
                case 3:
                    InstantiateProjectile(centralGun.transform.position, Vector3.zero);
                    InstantiateProjectile(rightGun.transform.position, new Vector3(0, 0, -5));
                    InstantiateProjectile(leftGun.transform.position, new Vector3(0, 0, 5));
                    leftGun.Play();
                    rightGun.Play();
                    break;
                case 4:
                    InstantiateProjectile(centralGun.transform.position, Vector3.zero);
                    InstantiateProjectile(rightGun.transform.position, new Vector3(0, 0, -5));
                    InstantiateProjectile(leftGun.transform.position, new Vector3(0, 0, 5));
                    InstantiateProjectile(leftGun.transform.position, new Vector3(0, 0, 15));
                    InstantiateProjectile(rightGun.transform.position, new Vector3(0, 0, -15));
                    leftGun.Play();
                    rightGun.Play();
                    break;
            }
        }

        public override void DealDamage(float damage) {
            base.DealDamage(damage);
            gameController.UpdateHealthBarUI(CurrentHealth);
        }

        public override void Hit() {
            base.Hit();
            AudioManager.Instance.PlayOnPlayerHit();
        }

        public void DeathBehaviour() {
            gameController.DealPlayerDeath();
            Destroy(gameObject);
        }
        #endregion --------------------------------------------
    }
}
















