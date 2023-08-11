using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab;

	[SerializeField] private GameObject grid;

    public static Dictionary<Vector2, Tile> tiles;

    public static Tile mainRoot; 

	void generateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        Vector2 offset = new Vector2((-width* tilePrefab.transform.localScale.x / 2) + tilePrefab.transform.localScale.x/2, -2.5f);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x*tilePrefab.transform.localScale.x + offset.x, -y*tilePrefab.transform.localScale.y + offset.y), Quaternion.identity);
                spawnedTile.name = $"Tile [ {x}; {y} ]";
                spawnedTile.transform.parent = grid.transform;
                spawnedTile.Init(x, y);
                tiles[new Vector2(x, y)] = spawnedTile;

                if (y == 0 && x == width/2)
                {
                    spawnedTile.growRoot();
                    spawnedTile.setRootConnection(2);

                    mainRoot = spawnedTile;
                }
            }
        }
    }

    public Tile getTile(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out Tile tile)) return tile;
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        generateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
