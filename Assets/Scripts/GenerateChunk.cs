using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateChunk : MonoBehaviour
{

	public GameObject DirtTile;
	public GameObject GrassTile;
	public GameObject StoneTile;

	public int width;
	public int heightMultipilier;
	public int heightAddition;
	
	

	public float smoothnes;

	[HideInInspector]
	public float seed;

	public GameObject TileCoal;
	public GameObject TileIron;
	public GameObject TileGold;
	public GameObject TileCopper;

	public float IronChances;
	public float GoldChances;
	public float CoalChances;
	public float CopperChances;

	void Start()
	{
		Generate();
		
	}
	public void Generate()
	{
		for (int i = 0; i < width; i++)
		{
			int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smoothnes) * heightMultipilier) + heightAddition;
			for (int j = 0; j < h; j++)
			{
				GameObject selectedTile;
				if (j < h - 4)
				{
					selectedTile = StoneTile;
				}
				else if (j < h - 1)
				{
					selectedTile = DirtTile;
				}
				else
				{
					selectedTile = GrassTile;
				}
				GameObject newTile = Instantiate(selectedTile, new Vector3(i, j) / 3, Quaternion.identity);
				newTile.transform.parent = this.gameObject.transform;
				newTile.transform.localPosition = new Vector3(i, j) / 3;
			}
		}
		Populate();
	}

	public void Populate()
	{
		foreach(GameObject t in GameObject.FindGameObjectsWithTag("TileStone"))
		{
			if (t.transform.parent == this.gameObject.transform)
			{
				float r = Random.Range(0f, 100f);
				GameObject selectedTile = null;

				if(r < GoldChances)
				{
					selectedTile = TileGold;
				}
				 else if (r < IronChances)
				{
					selectedTile = TileIron;
				}
				else if (r < CopperChances)
				{
					selectedTile = TileCopper;
				}
				else if (r < CoalChances)
				{
					selectedTile = TileCoal;
				}
				if(selectedTile != null)
				{
					GameObject newResourceTile = Instantiate(selectedTile, t.transform.position, Quaternion.identity) as GameObject;
					Destroy(t);
				}
			}
		}
	}




}