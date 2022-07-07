using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Managers;
using SpaceShooter.Controllers;
using SpaceShooter.Core;

namespace SpaceShooter.Views {
    public class EnemyView : Entity, IDamageable {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private ParticleSystem centralGun;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public  Variables -----------------
        public void MakeAShot() {
            if (transform.position.y > GameManager.Instance.BorderMaxPoint.y) { return; }

            InstantiateProjectile(centralGun.transform.position, new Vector3(0, 0, -180));
        }

        public void DeathBehaviour() {
            gameController.DealEnemyDeath();
            Destroy(gameObject);
        }
        #endregion --------------------------------------------
    }
}
