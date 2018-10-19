using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TimeToDestroy = 6;

    void Start()
    {

    }
    
    void Update()
    {
        if (TimeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
        TimeToDestroy -= Time.deltaTime;
    }
}
