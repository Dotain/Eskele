using UnityEngine;

public class TreeGenerator : MonoBehaviour
{


public Transform GrassTile;
public GameObject Tree;

	private Vector3 offset = new Vector3(0, 1, 0);
	// Start is called before the first frame update
	void Awake()
{
		offset = new Vector3(0, 0.15f, 0);
		if (Random.Range(0, 100) <= 15)
		{
			GameObject newTree = Instantiate(Tree, transform.position + offset, Quaternion.identity);
		newTree.transform.SetParent(this.transform);
		}
	}
}

