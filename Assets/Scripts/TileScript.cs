using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }

    public bool IsEmpty { get; private set; }

    private Color32 fullColor = new Color32(255, 118, 118, 255);
    
    private Color32 emptyColor = new Color32(96, 255, 90, 255);

    private SpriteRenderer spriteRenderer;

    public bool WalkAble { get; set; }

    public bool Debugging { get; set; }

    public Vector2 WorldPosition
    {
        get
        {
           return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2),
                              transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPos, Vector3 wordlPos, Transform parent)
    {
        WalkAble = true;
        IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = wordlPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        if(!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null)
        {
            if(IsEmpty && !Debugging) 
            {
                ColorTile(emptyColor);
            }
            if(!IsEmpty && !Debugging)
            {
                ColorTile(fullColor);
            }
            else if(Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }

    }

    private void OnMouseExit()
    {
        if(!Debugging)
        {
            ColorTile(Color.white);
        }
    }

    private void PlaceTower()
    {
        GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickedBtn.TowerPrefab, transform.position, Quaternion.identity);
        tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

        tower.transform.SetParent(transform);

        IsEmpty = false;

        ColorTile(Color.white);

        GameManager.Instance.BuyTower();

        WalkAble = false;
    }

    private void ColorTile(Color32 newColor)
    {
        spriteRenderer.color = newColor;
    }
}
