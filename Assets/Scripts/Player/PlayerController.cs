using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2Int boardPosition;
    public float moveSpeed = 5f;
    public BoardManager boardManager;
    public TurnManager turnManager;

    private Vector3 targetWorldPos;

    void Start()
    {
        boardPosition = new Vector2Int(0, 0);
        targetWorldPos = transform.position;
    }

    void Update()
    {
        HandleInput();
        MoveToTarget();
    }

    void HandleInput()
    {
        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector2Int.right;

        if (dir != Vector2Int.zero)
        {
            if (turnManager != null && !turnManager.CanMove())
                return;

            Vector2Int newPos = boardPosition + dir;
            if (boardManager.IsInsideBoard(newPos))
            {
                boardPosition = newPos;
                targetWorldPos = new Vector3(
                    boardPosition.x * boardManager.tileSpacing,
                    0,
                    boardPosition.y * boardManager.tileSpacing
                );

                if (turnManager != null)
                    turnManager.RegisterMove(1);
            }
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, moveSpeed * Time.deltaTime);
    }

    public void MoveByCard(int distance, Vector2Int direction)
    {
        Vector2Int newPos = boardPosition + direction * distance;
        if (boardManager.IsInsideBoard(newPos))
        {
            boardPosition = newPos;
            targetWorldPos = new Vector3(
                boardPosition.x * boardManager.tileSpacing,
                0,
                boardPosition.y * boardManager.tileSpacing
            );
        }
    }
}
