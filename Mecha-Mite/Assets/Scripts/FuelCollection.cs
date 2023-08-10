using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Fuel")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
