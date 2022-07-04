using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    public class Health : MonoBehaviour {
        #region --------------------------------------- Private variables ---------------------------------------

        #region --------------------------------------- SerializeField ---------------------------------------
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;
        #endregion --------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------

        #region --------------------------------------- Public variables ---------------------------------------
        public float MaxHealth { get => maxHealth; }
        public float CurrentHealth { get => currentHealth; }
        #endregion --------------------------------------------------------------------------------

        #region --------------------------------------- Private methods ---------------------------------------

        #region ---------------------------- Monobehaviour ----------------------------
        private void Start() {
            currentHealth = maxHealth;
        }
        #endregion --------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------

        #region --------------------------------------- Public methods ---------------------------------------
        public void DealDamage(float damage) {
            currentHealth = Mathf.Max(currentHealth - damage, 0);
        }

        public bool IsDead() {
            return currentHealth <= 0;
        }
        #endregion --------------------------------------------------------------------------------
    }
}
