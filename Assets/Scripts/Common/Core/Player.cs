using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Managers;
using SpaceShooter.Models;

namespace SpaceShooter.Core {
    public class Player : MonoBehaviour, IDamageable {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private float speed = 30f;
        [SerializeField] private Guns guns;
        [Range(1, 4)]
        [SerializeField] private int weaponPower = 1;
        #endregion --------------------------------------------

        #region ----------- Non-SerializeField -----------------
        private int maxWeaponPower = 4;
        private float currentHealth;
        private float nextFire;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Variables -----------------
        public float Speed { get => speed; }
        public int WeaponPower { get => weaponPower; set => weaponPower = value; }
        public int MaxWeaponPower { get => maxWeaponPower; }
        #endregion --------------------------------------------

        #region ----------- Private Methods -----------------
        private void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot) {
            Instantiate(lazer, pos, Quaternion.Euler(rot));
        }
        #endregion --------------------------------------------

        #region ----------- Public Methods -----------------
        public void MakeAShot(GameObject projectile) {
            switch (weaponPower) {
                case 1:
                    CreateLazerShot(projectile, guns.centralGun.transform.position, Vector3.zero);
                    guns.centralGunVFX.Play();
                    break;
                case 2:
                    CreateLazerShot(projectile, guns.rightGun.transform.position, Vector3.zero);
                    guns.leftGunVFX.Play();
                    CreateLazerShot(projectile, guns.leftGun.transform.position, Vector3.zero);
                    guns.rightGunVFX.Play();
                    break;
                case 3:
                    CreateLazerShot(projectile, guns.centralGun.transform.position, Vector3.zero);
                    CreateLazerShot(projectile, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                    CreateLazerShot(projectile, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                    guns.leftGunVFX.Play();
                    guns.rightGunVFX.Play();
                    break;
                case 4:
                    CreateLazerShot(projectile, guns.centralGun.transform.position, Vector3.zero);
                    CreateLazerShot(projectile, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                    CreateLazerShot(projectile, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                    CreateLazerShot(projectile, guns.leftGun.transform.position, new Vector3(0, 0, 15));
                    CreateLazerShot(projectile, guns.rightGun.transform.position, new Vector3(0, 0, -15));
                    guns.leftGunVFX.Play();
                    guns.rightGunVFX.Play();
                    break;
            }
        }

        public void DeathBehaviour() {
            GameManager.Instance.UpdateGameState(GameState.GAMEOVER);
            GameManager.Instance.ReplayWholeGameAfterPlayerDeath();
            Destroy(gameObject);
        }
        #endregion --------------------------------------------
    }
}
















