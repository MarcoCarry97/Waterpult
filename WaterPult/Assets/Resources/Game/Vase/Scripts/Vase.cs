using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Vase : MonoBehaviour
{
    private enum State
    {
        Thirsty,
        Growing,
        Grown
    }

    private State state;

    [Range(1, 5)]
    [SerializeField]
    private int waterNeeds;

    private int waterGained;

    private GameObject plant;

    private GameObject flower;

    private WaterCount waterCount;

    private void Start()
    {
        waterGained = 0;
        state= State.Thirsty;
        waterCount=this.GetComponentInChildren<WaterCount>();
        plant = this.transform.GetChild(0).gameObject;
        flower = this.transform.Find("Flower").gameObject;
    }

    private void Update()
    {
        switch(state)
        {

            case State.Growing:
                GrowingState();
                break;
            case State.Grown:
                GrownState();
                break;
        }
    }

    private void LateUpdate()
    {
        waterCount.Count = waterNeeds - waterGained;
    }

    private void GrowingState()
    {
        Vector3 plantScale=plant.transform.localScale;
        plantScale.y += 2f;
        plant.transform.localScale=plantScale;
        Vector3 pos = plant.transform.position;
        pos += plant.transform.up * 1f*waterGained;
        plant.transform.position=pos;
        state = (waterGained == waterNeeds) ? State.Grown : State.Thirsty;
    }

    private void GrownState()
    {
        flower.SetActive(true);
        Vector3 pos=plant.transform.position;
        pos += plant.transform.up * plant.transform.localScale.y/2;
        pos.z=flower.transform.position.z;
        flower.transform.position=pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string colliderTag = collision.collider.tag;
        string otherTag=collision.otherCollider.tag;
        if(otherTag.Equals("VaseGround") && colliderTag.Equals("Water") && state==State.Thirsty)
        {
            waterGained++;
            state = State.Growing;
        }
    }

    public bool IsBloomed()
    {
        return state==State.Grown;
    }

    public int GetWaterNeeds()
    {
        return waterNeeds;
    }
}
