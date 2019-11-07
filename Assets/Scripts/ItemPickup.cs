using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
	public float speed = 1;
	public float radius = 1f;
	public Transform item;
	public Transform player;
	private float Distance;
	
	



	public void Start()
	{

		player = GameObject.FindGameObjectWithTag("ME").transform;

	}

	void Update()
	{
		Distance = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, player.position, Distance);
		Debug.Log(player);

	}

	
}
	

