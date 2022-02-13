using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    private Collider collider;
 

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        collider = GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("AxeHit"))
        {
            if (other.tag != "Player")
            {
                
                if (other.tag == "Enemy")
                {
                  EnemyHealth enemyHealth =  other.gameObject.GetComponent<EnemyHealth>();
                    if (enemyHealth.health > 1)
                    {
                        ParticleSystem healthParticle = Instantiate(enemyHealth.bloodEffect, collider.bounds.center, new Quaternion(-transform.rotation.x,0,transform.rotation.z,0));
                        healthParticle.Play();
                        Destroy(healthParticle.gameObject, healthParticle.main.duration);
                        enemyHealth.health--;
                        
                    }
                    else
                    {

                        Destroy(other.gameObject);
                    }
                    
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }

        }

    }
}
