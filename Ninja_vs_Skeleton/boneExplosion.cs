using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneExplosion : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisParticleSystem.isStopped == true)
        {
            Destroy(gameObject);
        }
    }
}
