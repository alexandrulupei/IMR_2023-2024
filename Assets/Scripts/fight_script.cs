using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight_script : MonoBehaviour
{
    public float fightDistance = 2f; // Distance at which the objects should start fighting.
    public float fightDuration = 3f; // Duration of the fight in seconds.

    private Transform player1;
    private Transform player2;
    private bool isFighting = false;
    private Animator player1Animator;
    private Animator player2Animator;

    void Start()
    {
        player1 = GameObject.Find("Cactus@Idle").transform; 
        player2 = GameObject.Find("Cactus@Idle_1").transform;

        player1Animator = player1.GetComponent<Animator>();
        player2Animator = player2.GetComponent <Animator>();
    }

    void Update()
    {
        if (isFighting)
        {
            // Handle the fight logic here.
            Debug.Log("Fighting...");

            // Stop fighting after a duration.
            StartCoroutine(StopFight());
        }
        else
        {
            // Check if the objects are close enough to start a fight.
            if (Vector3.Distance(player1.position, player2.position) < fightDistance)
            {
                StartFight();
            }
        }
    }

    void StartFight()
    {
        isFighting = true;

        // Trigger the fighting animation for both players.
        player1Animator.SetBool("IsFighting", true);
        player2Animator.SetBool("IsFighting", true);

    }

    IEnumerator StopFight()
    {
        yield return new WaitForSeconds(fightDuration);
        isFighting = false;
    }
}
