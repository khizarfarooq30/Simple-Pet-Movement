using UnityEngine;

public class BoxFormationStrategy : BaseMoveStrategy
{
 
    public BoxFormationStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) : base(leader, followTransform, currentTransform, index)
    {
    }
 
    public override void Move()
    {
        int rowIndex = index / leader.columnSize;
        int columnIndex = index % leader.columnSize;
        
        float cornerOffsetX = (leader.columnSize - 1) * leader.formationDistance * 0.5f;
        float cornerOffsetZ = (leader.rowSize - 1) * leader.formationDistance * 0.5f;
        
        var leaderTransform = leader.transform;
        
        float targetX = leaderTransform.position.x + (columnIndex * leader.formationDistance - cornerOffsetX);
        float targetZ = leaderTransform.position.z + (rowIndex * leader.formationDistance - cornerOffsetZ);
        
        Vector3 targetPos = new Vector3(targetX, leaderTransform.position.y, targetZ);
        MoveTowardsTarget(targetPos);
    }


}