using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject tile;

    [SerializeField]
    private GameObject portalPrefab;

    [SerializeField]
    private Transform map;

    private Point portalPos;

    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
        SpawnPortal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel() 
    {
        Tiles = new Dictionary<Point, TileScript>();

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < 8; y++) 
        {
            for (int x = 0 ; x < 15; x++) 
            {
                PlaceTile(x, y, worldStart);
            }
        }
    }

    private void PlaceTile(int x, int y, Vector3 worldStart) 
    {
        TileScript newTile = Instantiate(tile).GetComponent<TileScript>();
        newTile.Setup(new Point(x, y), new Vector3(worldStart.x + TileSize * x, worldStart.y - TileSize * y, 0), map);
    }

    private void SpawnPortal() 
    {
        portalPos = new Point(0, 0);
        Instantiate(portalPrefab, Tiles[portalPos].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
}

