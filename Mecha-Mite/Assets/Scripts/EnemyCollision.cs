using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy Body")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
