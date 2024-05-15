using UnityEngine;

public class RowColumnAdaptiveFormationStrategy : BaseMoveStrategy
{
    public RowColumnAdaptiveFormationStrategy(Leader leader, 
        Transform followTransform, Transform currentTransform,  int index)
        : base(leader,  followTransform, currentTransform,  index)
    {
    
    }

    public override void Move()
    {
        int rowIndex, columnIndex;
        
        int rowSize = leader.rowSize;
        int columnSize = leader.columnSize;
        float formationDistance = leader.formationDistance;

        if (index < columnSize - 1)
        {
            rowIndex = 0;
            columnIndex = index;
        }
        else if (index < columnSize + rowSize - 2)
        {
            rowIndex = index - (columnSize - 1);
            columnIndex = columnSize - 1;
        }
        else if (index < columnSize * 2 + rowSize - 3)
        {
            rowIndex = rowSize - 1;
            columnIndex = columnSize - 2 - (index - (columnSize + rowSize - 2));
        }
        else
        {
            rowIndex = rowSize - 2 - (index - (columnSize * 2 + rowSize - 3));
            columnIndex = 0;
        }
        
        var leaderTransform = leader.transform;

        float cornerOffsetX = (columnSize - 1) * formationDistance * 0.5f;
        float cornerOffsetZ = (rowSize - 1) * formationDistance * 0.5f;

        float targetX = leaderTransform.position.x + (columnIndex * formationDistance - cornerOffsetX);
        float targetZ = leaderTransform.position.z + (rowIndex * formationDistance - cornerOffsetZ);

        Vector3 targetPos = new Vector3(targetX, leaderTransform.position.y, targetZ);
        MoveTowardsTarget(targetPos);
    }
}
