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

    [SerializeField]
    private float force;

    [SerializeField]
    private ForceMode2D forceMode;

    private CatapultSound sound;

    private Water instance;

    public Vector3 Velocity { get;private set; }

    public enum State
    {
        Charging,
        Shot
    }

    public State Status { get; private set; }

    private void Start()
    {
        instance = null;
        Status= State.Shot;
        sound=this.GetComponent<CatapultSound>();
    }

    private void Update()
    {
        if(instance!=null)
        {
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            Vector3 middle = (anchors[1].transform.position + anchors[0].transform.position) * 0.5f;
            Vector3 bulletPos = instance.transform.position;
            Velocity = (middle - bulletPos) * force;
        }
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
            Status=State.Charging;
            return true;
        }

        else return false;
    }

    public bool Shoot()
    {
        foreach (Rope2D anchor in anchors)
            anchor.Detach();
        instance.Shoot();
        Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Velocity*100,forceMode);
        instance = null;
        sound.DoSoundShot();
        return true;
    }

    public bool HasBulletLoaded()
    {
        return instance != null;
    }


    public Water GetBullet()
    {
        return instance;
    }

    public void SetBulletPosition(Vector3 position)
    {
        if(instance!=null)
        {
            Vector3 middle = (anchors[1].transform.position + anchors[0].transform.position) * 0.5f;
            float middleDistance = (anchors[1].Length + anchors[0].Length) / 2;
            Vector3 positionToMiddle=middle - position;
            if (positionToMiddle.magnitude > middleDistance)
                position = middle - positionToMiddle.normalized * middleDistance;
            instance.transform.position = position;
            sound.DoSoundStretch();
        }
    }
}
