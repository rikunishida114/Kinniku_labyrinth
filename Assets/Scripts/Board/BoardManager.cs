using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int boardSize = 9;       // 9x9の盤面
    public GameObject tilePrefab;   // マスの見た目（Prefab）、Inspector上でPrefabやシーン内のGameObjectをドラッグ＆ドロップして割り当て
    public float tileSpacing = 1.1f; // マスの間隔

    private GameObject[,] tiles; // 全マスを保持

    void Start()
    {
        GenerateBoard();
    }

    // 盤面を生成
    void GenerateBoard()
    {
        tiles = new GameObject[boardSize, boardSize]; // GameObject型を入れられる2次元配列9*9

        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                Vector3 pos = new Vector3(x * tileSpacing, 0, y * tileSpacing);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                tile.name = $"Tile_{x}_{y}"; // デバック用
                tiles[x, y] = tile; 
            }
        }
    }

    // 指定座標が盤面内かどうか
    public bool IsInsideBoard(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < boardSize &&
               pos.y >= 0 && pos.y < boardSize;
    }
}
