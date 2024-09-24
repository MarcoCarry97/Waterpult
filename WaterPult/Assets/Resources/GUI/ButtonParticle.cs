using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonParticle : MonoBehaviour
{
    private ParticleSystem ps;
    private EventSystem es;

    // Start is called before the first frame update
    void Start()
    {
        ps=this.GetComponentInChildren<ParticleSystem>();
        es=EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(es.currentSelectedGameObject==this.gameObject)
            ps.Play();
        else ps.Stop();
    }
}
