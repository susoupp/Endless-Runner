using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCollisionHelper : MonoBehaviour

{
    [SerializeField]
    UnityEvent _ObstacleCollision;
   
   private void OnCollisionEnter( Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
           _ObstacleCollision.Invoke();
        }
    }
    
}




