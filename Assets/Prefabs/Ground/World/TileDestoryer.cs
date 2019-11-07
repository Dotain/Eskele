using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestoryer : MonoBehaviour
{
	public float health = 50f;
	public GameObject item;
	private bool destroyed = false;

	private void OnMouseOver()
	{
		if (Input.GetMouseButton(0))
		{
			health -= 1;
		}

		if (!destroyed && health <= 0)
		{
			destroyed = true;
			item = Instantiate(item,transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
 
}