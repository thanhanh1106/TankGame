using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyObjectPooling
{
    // đánh dấu các đối tượng được pool quản lý
    public interface IPoolable<T>
    {
        void Initialize(Action<T> returnAction);
        void ReturnToPool();
    }
}