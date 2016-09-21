using UnityEngine;
using System.Collections;
using DG.Tweening;
using MarchingBytes;

public class PlayerController : MonoBehaviour
{
    #region Fields
    private float speed = 15;
    public float fireRate = 5f;
    public bool canShoot = true;
    private Vector2 target;
    private int delay = 2;
    float fireTimer;
    public string poolName;
    [SerializeField]
    private Transform tower = null;
    #endregion

    #region Methods
    public void Shoot()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                tower.transform.DOLookAt(hit.point, delay);
            }
            if (canShoot)
                StartCoroutine(Shooting());
        }
    }
    public void MoveToPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (hit.collider != null)
            {
                StartCoroutine(MoveFromTo(transform, transform.position, hit.point, speed));
            }
    }
    #endregion
    private IEnumerator Shooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        EasyObjectPool.instance.GetObjectFromPool(poolName, tower.transform.position, tower.transform.rotation);
        canShoot = true;
    }
    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        objectToMove.DOLookAt(b, 0.5f);
        while (t <= 1.0f)
        {
            t += step;
            objectToMove.position = Vector3.Lerp(a, b, t);
            yield return new WaitForFixedUpdate();
        }
    }
}


  

