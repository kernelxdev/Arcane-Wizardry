using UnityEngine;

public class Enemy : NPC
{
     public Transform target;

     public float speed;
     public float damage;
     
     void Start()
     {
          if (target == null)
               target = player.transform;
     }

     void FixedUpdate()
     {
          if(target != null)
               FollowTarget();
     }

     void FollowTarget()
     {
          // TODO IF SEEN TARGET AND IF IN RANGE
          
          Vector2 moveDirection = (Vector2)target.position - rb.position;
          
          rb.linearVelocity = moveDirection.normalized * speed;
     }
}