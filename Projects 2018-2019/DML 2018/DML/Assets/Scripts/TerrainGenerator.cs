using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField]
    private float perlinFrequency = 0.01f;
    [SerializeField]
    private float perlinsAmplitude = 0.1f;
    [SerializeField]
    private int secondOctaveMultiplier = 5;
    [SerializeField]
    private float textureSwapHeight = 30;
    
    public float TopValue;
    public float Difference;

    private Terrain _myTerrain;
    private Terrain MyTerrain
    {
        get
        {
            if (_myTerrain == null)
            {
                _myTerrain = GetComponent<Terrain>();
            }
            return _myTerrain;
        }
    }

    [ContextMenu("Generate")]
    public void Generate()
    {
        TerrainData data = MyTerrain.terrainData;
        float[,] heights = data.GetHeights(0, 0, data.heightmapResolution, data.heightmapResolution);

        for (int i = 0; i < heights.GetLength(0); i++)
        {
            for (int j = 0; j < heights.GetLength(1); j++)
            {
                heights[i, j] =
                    Mathf.PerlinNoise(i * perlinFrequency, j * perlinFrequency) * perlinsAmplitude +
                    Mathf.PerlinNoise(i * perlinFrequency / secondOctaveMultiplier, j * perlinFrequency / secondOctaveMultiplier) * perlinsAmplitude * secondOctaveMultiplier;
            }
        }

        data.SetHeights(0, 0, heights);

        float alphamapToHeightmapResolutionRation = (float)data.alphamapResolution / (float)(data.heightmapResolution - 1f);


        float[,,] alphamaps = data.GetAlphamaps(0, 0, data.alphamapResolution, data.alphamapResolution);
        for (int i = 0; i < data.alphamapResolution; i++)
        {
            for (int j = 0; j < data.alphamapResolution; j++)
            {
                float heightAtPoint = heights[
                      Mathf.FloorToInt(i / alphamapToHeightmapResolutionRation),
                      Mathf.FloorToInt(j / alphamapToHeightmapResolutionRation)];
                
                // alphamaps[i, j, 0] = heightAtPoint * data.size.y < textureSwapHeight ? 1 : 0;
                // alphamaps[i, j, 1] = heightAtPoint * data.size.y > textureSwapHeight ? 1 : 0;
                // alphamaps[i, j, 2] = heightAtPoint * data.size.y == textureSwapHeight ? 1 : 0;


                if (i < 1 || i > heights.GetLength(0) - 1 || 
                j < 1 || j > heights.GetLength(1) - 1) 
                continue; 

                if (heights[i,j+1] - heights[i,j-1] < Difference || 
                heights[i+1,j] - heights[i-1, j] < Difference) 
                { 
                alphamaps[i,j,0] = 0; 
                alphamaps[i,j,1] = 1; 
                alphamaps[i,j,2] = 0; 
                } 
                else 
                { 
                    alphamaps[i,j,0] = 1; 
                    alphamaps[i,j,1] = 0; 
                    alphamaps[i,j,2] = 0; 
                } 
                if (heights[i,j] > TopValue) 
                { 
                    alphamaps[i,j,0] = 0; 
                    alphamaps[i,j,1] = 0; 
                    alphamaps[i,j,2] = 1; 
                } 
            }
            
        }

        data.SetAlphamaps(0, 0, alphamaps);
    }
}
