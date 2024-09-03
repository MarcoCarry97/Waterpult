using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private Catapult catapult;
    private LineRenderer line;

    [SerializeField]
    private float launchForce;

    [SerializeField]
    private float timeStep;

    [SerializeField]
    private int stepCount;


    private Vector3 startPos;
    private Vector3 currentPos;

    private void Draw()
    {
        Water bullet=catapult.GetBullet();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        List<Vector3> positions= new List<Vector3>();
        currentPos = startPos = bullet.transform.position;
        positions.Add(startPos);
        for (int i=0;i<stepCount; i++)
        {
            float t = i*timeStep;
            currentPos = (Vector2)startPos + (Vector2) catapult.Velocity/2 * t + rb.mass*rb.gravityScale*Physics2D.gravity * t * t;
            positions.Add(currentPos);
        }
        line.positionCount=positions.Count;
        line.SetPositions(positions.ToArray());
    }

    private void Clear()
    {
        line.SetPositions(new Vector3[1]);
        line.positionCount = 0;
    }

    private void Start()
    {
        catapult=this.transform.parent.GetComponent<Catapult>();
        line=this.transform.GetComponent<LineRenderer>();
        startPos=currentPos = this.transform.position;
    }

    private void Update()
    {
        if(catapult.GetBullet()!=null) Draw();
        else Clear();
    }

}
