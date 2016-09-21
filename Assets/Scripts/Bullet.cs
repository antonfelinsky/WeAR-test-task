using UnityEngine;
using MarchingBytes;


public class Bullet : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float speed = 0.5f;
    #endregion

    #region UnityEvents
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.Translate(0, 0, speed);
        }
    }     
    void OnTriggerEnter(Collider other)
    {
        EasyObjectPool.instance.ReturnObjectToPool(gameObject);
    }
    #endregion
}
