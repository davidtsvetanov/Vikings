using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
 

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
      


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
                        enemyHealth.bloodEffect.Play();
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
