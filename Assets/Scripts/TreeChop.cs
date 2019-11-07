using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChop : MonoBehaviour
{
	public float health = 130f;
	private bool isDone = false;
	public GameObject Tree;
	public Animator animator;
	public GameObject item;
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	private void OnMouseOver()
	{
		
		if (Input.GetMouseButton(0))
		{
			health -= 1;
			Debug.Log(health);

		}
		if(!isDone && health <= 0)
		{
			animator.SetBool("IsFalling", true);
			isDone = true;
			item = Instantiate(item, transform.position, Quaternion.identity);

		}
		
		
	}
	public void DestroyTree()
	{
		Destroy(gameObject);
	}
}
