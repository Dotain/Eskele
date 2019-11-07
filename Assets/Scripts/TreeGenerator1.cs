using UnityEngine;
using System.Collections;
 
public class test : MonoBehaviour
{
	public GameObject tree;
	public int number;
	public int xaxis;
	public int yaxis;
	public int zaxis;

	void Start()
	{

		PlaceTree();
	}
	void PlaceTree()
	{
		for (int i = 0; i < number; i++)
		{
			Instantiate(tree, GeneratedPosition(), Quaternion.identity);
		}
	}
	Vector3 GeneratedPosition()
	{
		int x, y, z;
		x = UnityEngine.Random.Range(-xaxis, xaxis);
		y = UnityEngine.Random.Range(-yaxis, yaxis);
		z = UnityEngine.Random.Range(-zaxis, zaxis);
		return new Vector3(x, y, z);

	}
}