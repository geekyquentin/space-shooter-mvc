using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Configs;
using SpaceShooter.Managers;

namespace SpaceShooter.Core {
    public class Projectile : MonoBehaviour {
        #region ----------- Private Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private int damage;
        [SerializeField] private bool isEnemyBullet = false;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Private Methods -----------------
        private void OnTriggerEnter2D(Collider2D collision) {
            if ((isEnemyBullet && collision.CompareTag(GameStrings.playerTag))
            || (!isEnemyBullet && collision.CompareTag(GameStrings.enemyTag))) {
                GameManager.Instance.DealDamage(collision, damage);
                Destroy(gameObject);
            }
        }
        #endregion --------------------------------------------
    }
}