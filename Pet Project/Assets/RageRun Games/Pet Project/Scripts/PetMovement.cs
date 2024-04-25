using System;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
       public Transform followTransform;
   
       [SerializeField] private float maxSpeed = 3f;
       [SerializeField] private float maxDistance = 3f;
       [SerializeField] private float stopDistance = 1f;
     
       [SerializeField] private bool maintainInitialYPosition = true;
       
       private Vector3 velocity;
       
       private float acceleration;
       private float previousAcceleration;
       
       private float speedCap = 0;
       private float initialYPosition;
       
       public bool EnableFollow { get; set; }

       private void Start()
       {
           initialYPosition = transform.position.y;
           acceleration = maxSpeed / (maxDistance * 2f);
           previousAcceleration = acceleration;
           Debug.Log(acceleration);
       }

       private void Update()
       {
           HandlePetMovement();
       }

       private void HandlePetMovement()
       {
           if (followTransform == null) return;
           
           Vector3 targetPos = followTransform.position;
           Vector3 position = transform.position;

           speedCap = (Mathf.Clamp(Vector3.Distance(transform.position, followTransform.position), stopDistance, maxDistance) - stopDistance) * maxSpeed;

           Vector3 force = (targetPos + (maintainInitialYPosition ? Vector3.up * (initialYPosition - transform.position.y) : Vector3.zero) - position).normalized * acceleration;
           velocity = Vector3.ClampMagnitude(velocity + force, speedCap);
           position += velocity * Time.deltaTime;
           transform.position = position;
           
           transform.LookAt(followTransform);

           if (Math.Abs(previousAcceleration - acceleration) > 0.025f)
           {
               acceleration = maxSpeed / (maxDistance * 2f);
               previousAcceleration = acceleration;
           }
         
       }

       public void SetFollowTarget(Transform target)
       {
           followTransform = target;
           EnableFollow = true;
       }
       
       public bool IsFollowingTarget()
       {
           return followTransform != null;
       }
}
