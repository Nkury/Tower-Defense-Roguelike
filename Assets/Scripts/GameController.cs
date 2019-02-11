using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DungeonConstructor))]
public class GameController : MonoBehaviour
{
    private DungeonConstructor generator;
    
    [SerializeField] private int DungeonRows;
    [SerializeField] private int DungeonCols;

    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<DungeonConstructor>();
        generator.GenerateNewDungeon(DungeonRows, DungeonCols);
    }

}
