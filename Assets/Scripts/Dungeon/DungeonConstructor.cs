using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonConstructor : MonoBehaviour
{
    public bool showDebug;

    [SerializeField] private GameObject DungeonSprite;

    public int[,] data
    {
        get; private set;
    }

    private DungeonDataGenerator dataGenerator;

    private void Awake()
    {
        dataGenerator = new DungeonDataGenerator();

        // default to walls surroudning a single emptys cell
        data = new int[,]
        {
            {1, 1, 1 },
            {1, 0, 1 },
            {1, 1, 1 }
        };
    }

    public void GenerateNewDungeon(int rows, int cols)
    {
        if(rows %2 == 0 && cols % 2 == 0)
        {
            Debug.LogError("Odd numbers work better for dungeon sizes.");
        }

        data = dataGenerator.FromDimensions(rows, cols);
        DrawDungeonGraphics();
    }

    public void DrawDungeonGraphics()
    {
        float sprWidth = DungeonSprite.GetComponent<BoxCollider2D>().size.x;
        float sprHeight = DungeonSprite.GetComponent<SpriteRenderer>().size.y;
        int rowMax = data.GetUpperBound(0);
        int colMax = data.GetUpperBound(1);

        for(int i = 0; i <= rowMax; i++)
        {
            for(int j = 0; j <= colMax; j++)
            {
                if (data[i,j] == 1)
                {
                    GameObject go = Instantiate(DungeonSprite, new Vector3(j * sprWidth, i * sprHeight, 0), Quaternion.identity);
                }
            }
        }
    }

    private void OnGUI()
    {
        if (!showDebug)
        {
            return;
        }

        int[,] dungeon = data;
        int rowMax = dungeon.GetUpperBound(0);
        int colMax = dungeon.GetUpperBound(1);

        string msg = "";

        for(int i = rowMax; i >= 0; i--)
        {
            for (int j = 0; j <= colMax; j++) {
                if(dungeon[i,j] == 0)
                {
                    msg += "....";
                }
                else
                {
                    msg += "==";
                }
            }

            msg += "\n";
        }

        GUI.Label(new Rect(20, 20, 1000, 1000), msg);
    }
}
