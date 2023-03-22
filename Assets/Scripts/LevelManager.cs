using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;

    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        createLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createLevel() 
    {
        Tiles = new Dictionary<Point, TileScript>();

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < 5; y++) 
        {
            for (int x = 0 ; x < 5; x++) 
            {
                placeTile(x, y, worldStart);
            }
        }
    }

    private void placeTile(int x, int y, Vector3 worldStart) 
    {
        TileScript newTile = Instantiate(tile).GetComponent<TileScript>();
        newTile.Setup(new Point(x, y), new Vector3(worldStart.x + TileSize * x, worldStart.y - TileSize * y, 0));
        Tiles.Add(newTile.GridPosition, newTile);
    }
}

