using UnityEngine;

public class BoxFormationPatternStrategy : BaseMovementStrategies
{
    private int rowSize;
    private int columnSize;
    private float formationDistance;

    public BoxFormationPatternStrategy(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index, int rowSize, int columnSize, float formationDistance) 
        : base(leader, leaderTransform, followTransform, currentTransform, followOffset, index)
    {
        this.rowSize = rowSize;
        this.columnSize = columnSize;
        this.formationDistance = formationDistance;
    }

    public override void Move()
    {
        int rowIndex, columnIndex;

        if (index == 0)
        {
            rowIndex = 0;
            columnIndex = 0;
        }
        else if (index == columnSize - 1)
        {
            rowIndex = 0;
            columnIndex = columnSize - 1;
        }
        else if (index == (rowSize - 1) * columnSize)
        {
            rowIndex = rowSize - 1;
            columnIndex = 0;
        }
        else if (index == (rowSize - 1) * columnSize + columnSize - 1)
        {
            rowIndex = rowSize - 1;
            columnIndex = columnSize - 1;
        }
        else
        {
            // Pets are not on the corners, don't move
            return;
        }

        float cornerOffsetX = (columnSize - 1) * formationDistance * 0.5f;
        float cornerOffsetZ = (rowSize - 1) * formationDistance * 0.5f;

        float targetX = leaderTransform.position.x + (columnIndex * formationDistance - cornerOffsetX);
        float targetZ = leaderTransform.position.z + (rowIndex * formationDistance - cornerOffsetZ);

        Vector3 targetPos = new Vector3(targetX, leaderTransform.position.y, targetZ);
        MoveTowardsTarget(targetPos);
    }
}