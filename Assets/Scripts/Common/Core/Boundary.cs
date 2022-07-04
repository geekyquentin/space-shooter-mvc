using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Core {
    public class Boundary : MonoBehaviour {
        #region ----------- Private  Variables -----------------
        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.TryGetComponent<Translater>(out Translater translater)) {
                Destroy(translater.gameObject);
            }
        }
        #endregion --------------------------------------------
    }
}
