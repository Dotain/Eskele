using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour{
	public GameObject chunk;
	int chunkwidth;
	public int numChunks;
	float seed;
    void Start()
    {
		chunkwidth = chunk.GetComponent<GenerateChunk>().width;
		seed = Random.Range(-100000, 100000);
		Generate();
    }
	public void Generate()
	{

		int lastx = -chunkwidth;
		for(int i = 0;i < numChunks; i++)
		{
			GameObject newChunk = Instantiate(chunk, new Vector3(lastx + chunkwidth, 0f) / 3, Quaternion.identity) as GameObject;
			newChunk.GetComponent<GenerateChunk>().seed = seed;
			lastx += chunkwidth;
	
		}
	}
  
}
