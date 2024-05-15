using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public Leader leader;

    public int index;

    private Transform followTransform;
    public bool EnableFollow { get; set; }
    
    public BaseMoveStrategy baseMoveStrategy;
    
    private void Start()
    {
        leader = GameObject.FindGameObjectWithTag("Player").GetComponent<Leader>();
        index = transform.GetSiblingIndex();
    }

    void Update()
    {
        if (!EnableFollow) return;

        baseMoveStrategy?.Move();

        if (baseMoveStrategy != null)
        {
            AssignStrategy();
        }
    }
    
    private void AssignStrategy()
    {
        // num keys assign strategies based on all number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
             baseMoveStrategy = new BoxFormationStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            baseMoveStrategy = new ChainedSnakeLikeStrategy(leader, followTransform, transform,  index);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            baseMoveStrategy = new CrazyCircularStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            baseMoveStrategy = new GoldenRatioStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            baseMoveStrategy = new GoldenRatioRepelStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            baseMoveStrategy = new LeaderRepelStrategy(leader, followTransform, transform,  index);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            baseMoveStrategy = new RowColumnAdaptiveFormationStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            baseMoveStrategy = new CircularFormationStrategy( leader, followTransform, transform,  index);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            baseMoveStrategy = new TriangleFormationStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            baseMoveStrategy = new TriangleRepelStrategy(leader, followTransform, transform, index);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            baseMoveStrategy = new PetRepelPetStrategy(leader, followTransform, transform, index);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            baseMoveStrategy = new TestStrategy( leader, followTransform, transform,  index);
        }

    }
   
    public void SetFollowEnable(Transform followTransform)
    {
        this.followTransform = followTransform;
        EnableFollow = true;
    }
    
    public void InitiliazeStrategy()
    {
        baseMoveStrategy = new ChainedSnakeLikeStrategy(leader, followTransform, transform,  index);;
    }
    
   
}