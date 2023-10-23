using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtility
{
    public static void DelayCall(this MonoBehaviour mono,float time,Action callBack)
    {
        mono.StartCoroutine(IEDelay(time,callBack));
    }
    
    private static IEnumerator IEDelay(float time,Action callBack)
    {
        yield return new WaitForSeconds(time);
        callBack?.Invoke();
    }
}
