using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;
    public ParticleSystem bloodEffect;
    public Rigidbody[] bodies;
    // Start is called before the first frame update
    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
