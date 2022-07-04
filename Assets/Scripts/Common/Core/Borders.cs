using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    [System.Serializable]
    public class Borders {
        #region ----------- Public  Variables -----------------
        public float xOffset = 1.5f, yOffset = 1.5f;
        [HideInInspector] public float minX, minY, maxX, maxY;
        #endregion --------------------------------------------
    }
}
