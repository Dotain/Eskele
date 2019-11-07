using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerHotbarSelector : MonoBehaviour
{
    private PlayerMovement player;
    private RectTransform myTransform;

	void Start ()
    {
        player = FindObjectOfType<PlayerMovement>();
        myTransform = GetComponent<RectTransform>();
	}
	
	void Update ()
    {
		if(player != null)
        {
            Vector2 pos = new Vector2((player.getSelectedHotbarIndex() * 60) - 175, 0);
            myTransform.anchoredPosition = pos;
        }
	}
}