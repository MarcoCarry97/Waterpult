using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope2D : MonoBehaviour
{
    private Transform anchor;

    private Transform parent;

    [SerializeField]
    private Transform attached;

    private Transform body;

    [SerializeField]
    [Range(1, 100)]
    private float ropeLength;

    public float Length {  get { return ropeLength; } }

    public void Attach(Transform obj)
    {
        attached = obj;
    }

    public void Detach()
    {
        attached = null;
    }

    private void Start()
    {
        anchor = this.transform;
        body=this.transform.GetChild(0);
        parent = this.transform.parent;
    }

    private void Update()
    {
        if (attached != null)
        {
            DistanceConstraint();
            UpdateBodyPosition();
            UpdateBodyRotation();
            UpdateBodyScale();
            
        }
    }

    private void UpdateBodyScale()
    {
        Vector3 scale = body.localScale;
        //scale/= vector.magnitude;
        scale.y = Vector3.Distance(attached.position,body.position);
        body.localScale = scale;
    }

    private void UpdateBodyRotation()
    {
        Vector3 vector = anchor.position - body.position;
        body.rotation = Quaternion.FromToRotation(Vector3.up, vector.normalized);
    }

    private void UpdateBodyPosition()
    {
        body.position = (anchor.position + attached.position) / 2;
    }

    private void DistanceConstraint()
    {
        if(parent != null)
            this.transform.position = parent.transform.position;
        Vector3 vector = attached.position - anchor.position;
        float length=vector.magnitude;
        if (length > ropeLength)
            length = ropeLength;
        length -= length * Time.deltaTime;
        attached.position = anchor.position + vector.normalized * length;
    }
}
