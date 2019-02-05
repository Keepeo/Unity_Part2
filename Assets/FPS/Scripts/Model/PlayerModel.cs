using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerModel : MonoBehaviour
    {
        public BaseWeapon[] Weapons;
        public LightModel LightModel;

        private IEnumerator Start()
        {
            yield return new WaitWhile(() => !Main.Instance);
            Main.Instance.SetPlayer(this);
        }
    }
}
