using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    public class Translater : MonoBehaviour {
        #region ----------- Private  Variables -----------------

        #region ----------- SerializeField -----------------
        [SerializeField] private float speed;
        #endregion --------------------------------------------

        #endregion --------------------------------------------

        #region ------------ Private Methods -----------------

        #region ----------- Monobehaviour -----------------
        private void Update() {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        #endregion --------------------------------------------

        #endregion --------------------------------------------
    }
}