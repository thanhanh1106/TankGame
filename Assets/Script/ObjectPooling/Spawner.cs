using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyObjectPooling;

public class Spawner : MonoBehaviour
{
    public GameObject TankShellPrefab;
    public static ObjectPool<TankShell> TankShellPool;
    private void Awake()
    {
        TankShellPool = new ObjectPool<TankShell>(TankShellPrefab, 5);
    }
}
// Đối tượng sử dụng pool implement IPoolable và thực thi như template
// đối tượng này sẽ có 1 instance trên scenes
// khi muốn trả đối tượng về pool chỉ việc setActive = false đối tượng sẽ tự động quay về pool
