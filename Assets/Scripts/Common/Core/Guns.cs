using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    [System.Serializable]
    public class Guns {
        #region ----------- Public  Variables -----------------
        [Header("Left Gun")]
        public GameObject leftGun;
        public ParticleSystem leftGunVFX;

        [Header("Central Gun")]
        public GameObject centralGun;
        public ParticleSystem centralGunVFX;

        [Header("Right Gun")]
        public GameObject rightGun;
        public ParticleSystem rightGunVFX;
        #endregion --------------------------------------------
    }
}
