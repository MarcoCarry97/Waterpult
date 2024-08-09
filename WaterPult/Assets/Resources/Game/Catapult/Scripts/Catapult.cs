using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Catapult : MonoBehaviour
{

    [SerializeField]
    private Water bullet;

    [SerializeField]
    private List<Rope2D> anchors;

    private Water instance;

    private void Start()
    {
        instance = null;
    }

    public bool Load()
    {
        if (instance == null)
        {
            instance = Instantiate(bullet).GetComponent<Water>();
            Rigidbody2D rigidbody=instance.GetComponent<Rigidbody2D>();
            rigidbody.isKinematic = true;
            instance.transform.position = (anchors[0].transform.position + anchors[1].transform.position) / 2;
            foreach (Rope2D rope in anchors)
                rope.Attach(instance.transform);
            return true;
        }
        else return false;
    }

    public bool Shoot()
    {
        foreach (Rope2D anchor in anchors)
            anchor.Detach();
        Vector3 middle = (anchors[0].transform.position + anchors[1].transform.position) / 2;

        instance.Shoot();
        Vector2 vector=middle - instance.transform.position;
        Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(vector*10000);
        instance = null;
        return true;
    }

}
