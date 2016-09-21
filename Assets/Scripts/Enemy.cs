using UnityEngine;
using MarchingBytes;

public class Enemy : MonoBehaviour {

    #region UnityEvents
    void OnTriggerEnter(Collider other)
    {
        EasyObjectPool.instance.ReturnObjectToPool(gameObject);
    } 
    #endregion
}
