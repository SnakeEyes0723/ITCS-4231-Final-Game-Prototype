using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] float TimeToLive = 2f;
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}
