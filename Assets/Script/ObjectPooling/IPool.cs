using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyObjectPooling
{
    // đánh dấu các pool
    public interface IPool<T>
    {
        T Pull();
        void Push(T item);
    }
}
