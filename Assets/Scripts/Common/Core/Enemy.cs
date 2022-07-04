using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Models;
using SpaceShooter.Managers;

namespace SpaceShooter.Core {
    public class Enemy : MonoBehaviour, IDamageable {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private GameObject centralGun;
        [SerializeField] private ParticleSystem centralGunFX;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public  Variables -----------------
        public void MakeAShot(GameObject projectile) {
            if (transform.position.y > GameManager.Instance.Borders.maxY) { return; }

            Instantiate(projectile, centralGun.transform.position, Quaternion.identity);
        }

        public void DeathBehaviour() {
            GameManager.Instance.IncrementScore();
            Destroy(gameObject);
        }
        #endregion --------------------------------------------
    }
}
