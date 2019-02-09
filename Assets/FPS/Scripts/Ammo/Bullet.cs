using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class Bullet : BaseAmmo 
	{
        private float speed;
        private bool isHitted;
        
        [SerializeField]
        private string poolID = "Bullet01";
        public override string PoolID => poolID;

        [SerializeField]
        private int objectsCount = 10;
        public override int ObjectsCount => objectsCount;

		public override void Initialize(float force, Transform firepoint)
		{
            CancelInvoke();
            isHitted=false;
			Transform.position = firepoint.position;
			Transform.rotation = firepoint.rotation;
            speed = force;

            gameObject.SetActive(true);
                        
		}
        private void FixedUpdate()
        {
            if (isHitted) return;

            var finalPos = transform.position + transform.forward * speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit))
            {
                isHitted = true;
                transform.position = hit.point;

                var damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null) damageable.ApplyDamage(damage, transform.forward);

                //Destroy(gameObject, 0.3f);
                Invoke("Disable", 0.3f);

            }
            else
            {
                transform.position = finalPos;
            }
        }
	}
}