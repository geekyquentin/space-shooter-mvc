using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    public interface IDamageable {
        #region ----------- Public  Methods -----------------
        public void MakeAShot();
        public void DeathBehaviour();
        #endregion --------------------------------------------
    }
}
