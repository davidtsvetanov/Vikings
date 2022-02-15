using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Animator anim;
    public float hittingRange;
    public float detectRange;
    public GameObject player;
    private CharacterController characterController;
    public float gravity = -5.81f;
    Vector3 velocity;
    EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.health > 1)
        {
            float currentDistance = Vector3.Distance(player.transform.position, transform.position);
            Debug.Log(currentDistance);
            if (currentDistance < detectRange && currentDistance > hittingRange)
            {
                anim.SetBool("Walking", true);
                var lookPos = player.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            }
            else
            {
                anim.SetBool("Walking", false);

            }
            if (currentDistance < hittingRange)
            {
                anim.SetTrigger("Hit");
                var lookPos = player.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            }
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        

    }
}
