using UnityEngine;

public class RowColumnAdaptiveFormation : BaseMovementStrategies
{
    private int rowSize;
    private int columnSize;
    private float formationDistance;

    public RowColumnAdaptiveFormation(Leader leader, Transform leaderTransform,
        Transform followTransform, Transform currentTransform, Vector3 followOffset, int index, int rowSize,
        int columnSize, float formationDistance)
        : base(leader, leaderTransform, followTransform, currentTransform, followOffset, index)
    {
        this.rowSize = rowSize;
        this.columnSize = columnSize;
        this.formationDistance = formationDistance;
    }

    public override void Move()
    {
        int rowIndex, columnIndex;

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

        float cornerOffsetX = (columnSize - 1) * formationDistance * 0.5f;
        float cornerOffsetZ = (rowSize - 1) * formationDistance * 0.5f;

        float targetX = leaderTransform.position.x + (columnIndex * formationDistance - cornerOffsetX);
        float targetZ = leaderTransform.position.z + (rowIndex * formationDistance - cornerOffsetZ);

        Vector3 targetPos = new Vector3(targetX, leaderTransform.position.y, targetZ);
        MoveTowardsTarget(targetPos);
    }
}