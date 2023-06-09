using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarDebugger : MonoBehaviour
{
    private TileScript start, goal;
    [SerializeField]
    private Sprite blankTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickTile();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            AStar.GetPath(start.GridPosition);
        }
    }

    private void ClickTile()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hit.collider != null)
            {
                TileScript tmp = hit.collider.GetComponent<TileScript>();

                if(tmp != null)
                {
                    if(start == null)
                    {
                        start = tmp;
                        // start.SpriteRenderer.sprite = blankTile;
                        // start.SpriteRenderer.color = Color.green;
                        start.Debugging = true;
                    }
                    else if(goal == null)
                    {
                        goal = tmp;
                        // goal.SpriteRenderer.sprite = blankTile;
                        goal.Debugging = true;
                        // goal.SpriteRenderer.color = new Color32(255, 0, 0, 255);
                    }
                }

            }
        }
    }

    public void DebugPath(HashSet<Node> openList)
    {
        foreach(Node node in openList)
        {
            if(node.TileRef != start)
            {
                // node.TileRef.SpriteRenderer.color = Color.cyan;
                // node.TileRef.SpriteRenderer.sprite = blankTile;
            }
        }
    }

    private void ParentToParent(Node node, Vector2 position)
    {
        // GameObject
    }
}
