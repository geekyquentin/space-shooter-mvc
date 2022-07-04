using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    public interface IDamageable {
        #region ----------- Public  Methods -----------------
        public void MakeAShot(GameObject projectile);
        public void DeathBehaviour();
        #endregion --------------------------------------------
    }
}
