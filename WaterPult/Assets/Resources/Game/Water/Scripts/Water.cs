using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private int numberOfBounces;

    private bool destroyCondition=false;

    private Rigidbody2D rigidbody;

    private BounceCounter counter;

    public enum State
    {
        Rest,
        Charging,
        Shot
    }

    public State Status { get; private set; }



    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        Status = State.Rest;
        counter=this.GetComponentInChildren<BounceCounter>();
    }

    private void Update()
    {
        counter.Count = numberOfBounces;
        if(destroyCondition || numberOfBounces==0)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("VaseGround"))
        {
            Vase vase = collision.collider.transform.parent.GetComponent<Vase>();
            if (!vase.IsBloomed())
                destroyCondition = true;
        }
        else numberOfBounces--;
    }

    public void Shoot()
    {
        rigidbody.isKinematic = false;
        Status = State.Shot;
    }


    public void Hold(Vector3 position)
    {
        rigidbody.isKinematic = true;
        this.rigidbody.position = position;
        Status=State.Charging;
    }
}
