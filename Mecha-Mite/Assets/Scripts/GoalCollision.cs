using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : MonoBehaviour
{
    [SerializeField] Transform NextStart;
    [SerializeField] Transform Player;
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Player.transform.position = NextStart.transform.position;
        }
    }
}
