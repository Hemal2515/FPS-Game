using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    
    int MoveSpeed = 4;
    int MaxDist = 1;
    int MinDist = 1;
    public Animator animator;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
        
    }
    void Update()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) > MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
    }
}
