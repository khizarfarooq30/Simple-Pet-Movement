using UnityEngine;

public class BoxFormationPatternMovementStrategy : BaseMovementStrategies
{
    private int rowSize;
    private int columnSize;
    private float formationDistance;

    public BoxFormationPatternMovementStrategy(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index, int rowSize, int columnSize, float formationDistance) 
        : base(leader, leaderTransform, followTransform, currentTransform, followOffset, index)
    {
        this.rowSize = rowSize;
        this.columnSize = columnSize;
        this.formationDistance = formationDistance;
    }

    public override void Move()
    {
        int rowIndex = index / columnSize;
        int columnIndex = index % columnSize;
        
        float cornerOffsetX = (columnSize - 1) * formationDistance * 0.5f;
        float cornerOffsetZ = (rowSize - 1) * formationDistance * 0.5f;
        
        float targetX = leaderTransform.position.x + (columnIndex * formationDistance - cornerOffsetX);
        float targetZ = leaderTransform.position.z + (rowIndex * formationDistance - cornerOffsetZ);
        
        Vector3 targetPos = new Vector3(targetX, leaderTransform.position.y, targetZ);
        MoveTowardsTarget(targetPos);
    }
}