using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

namespace MyObjectPooling
{
    // viết như này hiểu là ObjectPool thực thi IPool và chỉ định kiểu T 
    // là 1 monobehavior thực thi IPoolable
    public class ObjectPool<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
    {
        private Action<T> pullObject;
        private Action<T> pushObject;
        private Queue<T> pooledObjects = new Queue<T>();
        private GameObject preflab;

        public int PooledCount => pooledObjects.Count;

        #region Contructor
        public ObjectPool(GameObject preflab,int sizePool = 0)
        {
            this.preflab = preflab;
            Spawn(sizePool);
        }

        public ObjectPool(GameObject preflab,Action<T> pullAction,Action<T> pushAction,int sizePool = 0)
        {
            this.pullObject = pullAction;
            this.pushObject = pushAction;
            this.preflab = preflab;
            Spawn(sizePool);
        }
        #endregion

        public T Pull()
        {
            T obj;
            if(PooledCount > 0) // nếu còn obj trong pool thì lấy ra 
                obj = pooledObjects.Dequeue();
            else // hết thì sinh ra thêm 
                obj = GameObject.Instantiate(preflab).GetComponent<T>();

            obj.gameObject.SetActive(true);
            obj.Initialize(Push);

            pullObject?.Invoke(obj);
            return obj;
        }

        #region Pull object method
        
        // dùng cho 2D
        public T Pull(Vector2 postion,Transform parent = null)
        {
            T obj = Pull();
            obj.transform.position = postion;
            obj.transform.parent = parent;
            return obj;
        }

        public T Pull(Vector2 position, Quaternion rotation,Transform parent = null)
        {
            T obj = Pull();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.parent = parent;
            return obj;
        }

        // dùng cho 3D
        public T Pull(Vector3 position,Transform parent = null)
        {
            T obj = Pull();
            obj.transform.position = position;
            obj.transform.parent = parent;
            return obj;
        }
        public T Pull(Vector3 position,Quaternion rotation,Transform parent = null)
        {
            T obj = Pull();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.parent = parent;
            return obj;
        }

        #endregion

        #region Pull gameobject method

        // dùng cho 2D
        public GameObject PullGameObject()
        {
            return Pull().gameObject;
        }

        public GameObject PullGameObject(Vector2 position,Transform parent = null)
        {
            GameObject obj = Pull().gameObject;
            obj.transform.position = position;
            obj.transform.parent = parent;
            return obj;
        }
        public GameObject PullGameObject(Vector2 position,Quaternion rotation,Transform parent = null)
        {
            GameObject obj = Pull().gameObject;
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.parent = parent;
            return obj;
        }

        // Dùng cho 3D
        public GameObject PullGameObject(Vector3 position,Transform parent = null)
        {
            GameObject obj = Pull().gameObject;
            obj.transform.position = position;
            obj .transform.parent = parent;
            return obj;
        }
        public GameObject PullGameObjec(Vector3 position, Quaternion rotation,Transform parent = null)
        {
            GameObject obj = Pull().gameObject;
            obj.transform.position = position;
            obj .transform.rotation = rotation;
            obj .transform.parent = parent;
            return obj;
        }

        #endregion

        public void Push(T obj)
        {
            obj.gameObject.SetActive(false);
            pooledObjects.Enqueue(obj);
            pushObject?.Invoke(obj);
        }

        private void Spawn(int number)
        {
            T obj;
            for(int index = 0; index < number; index++)
            {
                obj = GameObject.Instantiate(preflab).GetComponent<T>();
                pooledObjects.Enqueue(obj);
                obj.gameObject.SetActive(false);
            }
        }
    }
}
