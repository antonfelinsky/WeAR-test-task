using UnityEngine;
using System.Collections;
using MarchingBytes;

public class BulletDestroyer : MonoBehaviour

{
    #region Fields
    private int delay = 2;
    #endregion

    #region Unity Events
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    } 
    #endregion

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(delay);
        EasyObjectPool.instance.ReturnObjectToPool(gameObject);
    }
}
