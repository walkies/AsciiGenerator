using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;
    public ColourToPrefab[] colourMappings;
    void Start ()
    {
        GenerateLevel();
	}
	

	void Update ()
    {
		
	}

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }

    }
    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a ==0) //if the pixel is transparrent, ignore it
        {
            return;
        }
        foreach (ColourToPrefab colourMapping in colourMappings)
        {
            if (colourMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colourMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
/*
 * LevelGenerator
 * Attaches to empty object
 * For each pixel in the map, generate a tile
 * Generatle tile then takes cooridinates of the pixel colour
 * iterates through each of the colours in the mapping area
 * if they are the same colour, instantiates new objects to that poisition
 */

