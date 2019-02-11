using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDataGenerator 
{

    public float placementThreshold; // chance of empty space
    
    public DungeonDataGenerator()
    {
        placementThreshold = .2f;
    }

    public int[,] FromDimensions(int sizeRows, int sizeCols)
    {
        int[,] dungeon = new int[sizeRows, sizeCols];

        int rowMax = dungeon.GetUpperBound(0);
        int colMax = dungeon.GetUpperBound(1);

        for(int i = 0; i <= rowMax; i++)
        {
            for(int j = 0; j <= colMax; j++)
            {
                // fill the outer border with walls (1)
                if(i == 0 || j == 0 || i == rowMax || j == colMax)
                {
                    dungeon[i, j] = 1;
                }
                // checks EVERY OTHER CELL (%2) and then randomly chooses an adjacent cell to add a wall.
                else if(i % 2 == 0 && j % 2 == 0)
                {
                    if(Random.value > placementThreshold)
                    {
                        dungeon[i, j] = 1;

                        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                        dungeon[i + a, j + b] = 1;
                    }
                }
            }
        }

        return dungeon;
    }
}
