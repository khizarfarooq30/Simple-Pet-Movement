using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [Header("Leader Settings")] [SerializeField]
    public float moveSpeed = 5f;
    public float anglularSpeed = 5f;

    [SerializeField] private bool useUpwardMovement;

    [Header("Pet Settings")] public float maxDistance = 3f;
    public float stopDistance = 1f;
    public Vector3 followOffset = new Vector3(1f, 0f, 1f);

    public float repelAmount = 1f;

    public float goldenRatioRadius = 1f;
    public float goldenRatioAngle = 137.5f;

    public float formationDistance = 0.5f;

    public int rowSize = 3;
    public int columnSize = 3;

    public List<Transform> petTransforms = new List<Transform>();
    
    private float horizontal;
    private float vertical;
    private float up;
    public int triangleBase = 3;

    public Vector3 MoveVector { get; set; }


    private void Start()
    {
        petTransforms.Add(transform);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (useUpwardMovement)
        {
            up = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
        }

        MoveVector = new Vector3(horizontal, up, vertical).normalized;
        transform.position += MoveVector * (moveSpeed * Time.deltaTime);

        if (MoveVector.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveVector),
                Time.deltaTime * 10f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PetMovement petMovement) && !petMovement.EnableFollow)
        {
            var row = petTransforms.Count / rowSize;
            var column = petTransforms.Count % columnSize;
            var centerOffset = new Vector3((columnSize - 1) * formationDistance * 0.5f, 0f,
                (rowSize - 1) * formationDistance * 0.5f);
            followOffset = new Vector3(column * formationDistance, 0f, row * formationDistance) - centerOffset;
            
            petMovement.SetFollowEnable(petTransforms[^1]);
            petMovement.InitiliazeStrategy();
            petTransforms.Add(other.transform);
        }
    }

}