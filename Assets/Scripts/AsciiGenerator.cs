using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsciiGenerator : MonoBehaviour
{
    AsciiLevels asciiLevels;
    public TextAsset map;
    public AsciiToPrefab[] asciiToPrefab;


    void Start()
    {
        GenerateLevel();
    }


    void Update()
    {

    }

    void GenerateLevel()
    {
        asciiLevels = JsonUtility.FromJson<AsciiLevels>(map.text);

        for (int x = 0; x < asciiLevels.width; x++)
        {
            for (int y = 0; y < asciiLevels.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y)
    {
        KeyCode[] keyCode = asciiLevels.levelSetup;

        if (keyCode == null) //if the keycode is empty, ignore it
        {
            return;
        }

        foreach (AsciiToPrefab asciiMapping in asciiToPrefab)
        {
            if (asciiMapping.Keycode.Equals(keyCode))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(asciiMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
/*
 * 
 * 
 * 
 * 
 * 
 * 
 */
