using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Configs;
using SpaceShooter.Controllers;
using SpaceShooter.Managers;

namespace SpaceShooter.Core {
    public class Projectile : MonoBehaviour {
        #region ----------- Private Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private int damage;
        [SerializeField] private bool isEnemyBullet = false;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ----------- Public Variables -----------------
        public bool IsEnemyBullet { get => isEnemyBullet; }
        public int Damage { get => damage; }
        #endregion --------------------------------------------
    }
}