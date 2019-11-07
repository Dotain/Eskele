using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Item[] itemsToAdd;

	private Inventory myInventory = new Inventory(35);
	private int selectedHotbarIndex = 0;
	private KeyCode[] hotbarControls = new KeyCode[]
		 {
		KeyCode.Alpha1, //Key 1
        KeyCode.Alpha2, //Key 2
        KeyCode.Alpha3, //Key 3
        KeyCode.Alpha4, //Key 4
        KeyCode.Alpha5, //Key 5
        KeyCode.Alpha6,
		KeyCode.Alpha7,
    };
	public float speed = 10;
	public float jumppower = 100;
	Rigidbody2D rb;
	Vector3 jumpower;
	private bool isGrounded;
	public LayerMask groundLayer;
	public Transform GroundCheck1; // Put the prefab of the ground here
	public Animator animator;
	public List<Vector2> mylist;
	private bool isOpen;
	
	
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		jumpower = new Vector3(0,jumppower, 0);
		animator = GetComponent<Animator>();

		

		InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
		InventoryManager.INSTANCE.resetInventoryStatus();
}
	void Awake()
	{
		transform.position = new Vector3(100, 15, 0); // Where to spawn.
	}
	void Update()

	{
		//Here are all inputs for jumping and moveing
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.13f, groundLayer); // checks if you are within 0.15 position in the Y of the ground
		if (Input.GetKeyDown("w") && isGrounded)
		{
			rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
		}
		if (Input.GetKeyUp("w") && isGrounded)
		{
		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (!isOpen)
			{
				InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
			}
			else
			{
				InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
				isOpen = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isOpen)
			{
				InventoryManager.INSTANCE.closeContainer();
				isOpen = false;
			}
		}
	
		updateSelectedHotbarIndex(Input.GetAxis("Mouse ScrollWheel"));

		for (int i = 0; i < hotbarControls.Length; i++)
		{
			if (Input.GetKeyDown(hotbarControls[i]))
			{
				selectedHotbarIndex = i;
			}
		}
	}
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y); //This is used for moveing left or right using the input.GetAxisRaw("Horizontal") and use the velocity to move it
	}
	private void updateSelectedHotbarIndex(float direction)
	{
		if (direction > 0)
			direction = 1;

		if (direction < 0)
			direction = -1;

		for (selectedHotbarIndex -= (int)direction;
			selectedHotbarIndex < 0; selectedHotbarIndex += 7) ;

		while (selectedHotbarIndex >= 7)
			selectedHotbarIndex -= 7;
	}

	public int getSelectedHotbarIndex()
	{
		return selectedHotbarIndex;
	}

	public Inventory getInventory()
	{
		return myInventory;
	}
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Item")  || collision.gameObject.CompareTag("TileStone"))
		{
			foreach (Item item in itemsToAdd)
			{
				myInventory.addItem(new ItemStack(item, 1));
			}
		}
	}

}
	
	



