using UnityEngine;

public class PetMovement : MonoBehaviour
{
       public Transform followTransform;
   
       [SerializeField] private float maxSpeed = 3f;
       [SerializeField] private float maxDistance = 3f;
       [SerializeField] private float stopDistance = 1f;
       [SerializeField] private float acceleration = 0.5f;
       
       float speedCap = 0;
       
       private Vector3 velocity;

       private void Update()
       {
           HandlePetMovement();
       }

       private void HandlePetMovement()
       {
           if (followTransform != null)
           {
                Vector3 targetPos = followTransform.position;
                Vector3 position = transform.position;

               speedCap = (Mathf.Clamp(Vector3.Distance(transform.position, followTransform.position), stopDistance, maxDistance) - stopDistance) * maxSpeed;

               Vector3 force = (targetPos - position).normalized * acceleration;
               velocity = Vector3.ClampMagnitude(velocity + force, speedCap);
               position += velocity * Time.deltaTime;
               transform.position = position;
           }
       }

       public void SetFollowTarget(Transform target)
       {
           followTransform = target;
       }
       
       public bool IsFollowingTarget()
       {
           return followTransform != null;
       }
}
