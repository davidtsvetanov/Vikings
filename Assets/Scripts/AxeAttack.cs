using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    private Collider collider;
    public bool hit;
    [SerializeField]
    private ResourceManager resources;
 

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
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName("Default"))
        {
            if (other.tag != "Player")
            {

                if (other.tag == "Enemy")


                {
                    if (hit == false)
                    {
                        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                        EnemyAI enemyAI = other.gameObject.GetComponent<EnemyAI>();
                        if (enemyHealth.health > 1)
                        {
                            ParticleSystem healthParticle = Instantiate(enemyHealth.bloodEffect, collider.bounds.center, new Quaternion(-transform.rotation.x, 0, transform.rotation.z, 0));
                            healthParticle.Play();
                            Destroy(healthParticle.gameObject, healthParticle.main.duration);
                            enemyHealth.health--;
                            
                        }


                        else
                        {

                            foreach (Rigidbody enemyRag in enemyHealth.bodies)
                            {
                                Destroy(enemyAI.anim);
                                enemyRag.isKinematic = false;
                            }
                        }
                    }
                }
                    
                
                else
                {
                    if (other.tag != "Bones")
                    {
                        if (other.tag == "Wood")
                        {
                            TreeHealth treeHealth = other.GetComponent<TreeHealth>();
                            if (treeHealth.isTreeDead == false)
                            {
                                treeHealth.health--;

                                other.transform.eulerAngles += new Vector3(1, 0, 0);
                                resources.wood++;
                                if (treeHealth.health < 1)
                                {
                                    treeHealth.isTreeDead = true;
                                    other.GetComponent<Rigidbody>().isKinematic = false;
                                }
                            }
                        }
                        else
                        {

                            Destroy(other.gameObject);
                        }
                    }
                }
                hit = true;
            } 
        }

    }
}
