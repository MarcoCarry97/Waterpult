using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [Range(1.0f, 20.0f)]
    [SerializeField]
    private float stayTime;

    private bool destroyCondition=false;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(destroyCondition)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("VaseGround"))
            destroyCondition = true;
        else StartCoroutine(WaitingForDestroy());
    }

    private IEnumerator WaitingForDestroy()
    {
        yield return new WaitForSecondsRealtime(stayTime);
        destroyCondition = true;
    }

    public void Shoot()
    {
        rigidbody.isKinematic = false;
    }


    public void Hold(Vector3 position)
    {
        rigidbody.isKinematic = true;
        this.rigidbody.position = position;
    }
}
