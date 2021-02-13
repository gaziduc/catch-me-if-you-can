using UnityEngine;
using UnityEngine.Tilemaps;

public class AnimatedTilemap : MonoBehaviour
{
    private Tilemap tilemap;
    private int framecount = 0;

    public TileBase lavaBasic;
    public TileBase[] lavaAnim;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (framecount % 10 == 0)
        {
            for (int x = tilemap.cellBounds.min.x; x < tilemap.cellBounds.max.x; x++)
            {
                for (int y = tilemap.cellBounds.min.y; y < tilemap.cellBounds.max.y; y++)
                {
                    for (int z = tilemap.cellBounds.min.z; z < tilemap.cellBounds.max.z; z++)
                    {
                    
                        Vector3Int pos = new Vector3Int(x, y, 0);
                        TileBase tile = tilemap.GetTile(pos);
                    
                        if (!tile)
                            continue;
                        
                        if (tile.Equals(lavaBasic))
                            tilemap.SetTile(pos, lavaAnim[0]);
                        else if (tile.Equals(lavaAnim[0]))
                            tilemap.SetTile(pos, lavaAnim[1]);
                        else if (tile.Equals(lavaAnim[1]))
                            tilemap.SetTile(pos, lavaAnim[2]);
                        else if (tile.Equals(lavaAnim[2]))
                            tilemap.SetTile(pos, lavaAnim[0]);
                    }
                }
            }
        }
        
        framecount++;
    }
}
