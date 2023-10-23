using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyObjectPooling
{
    // class demo cho đối tượng sử dụng pool
    // các đối tượng sử dụng pool thực thi như class này
    public class PoolObject : MonoBehaviour, IPoolable<PoolObject>
    {
        private Action<PoolObject> returnToPoolAction;
        private void OnDisable()
        {
            ReturnToPool();
        }
        public void Initialize(Action<PoolObject> returnAction)
        {
            this.returnToPoolAction = returnAction;
        }

        public void ReturnToPool()
        {
            returnToPoolAction?.Invoke(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Plane"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
