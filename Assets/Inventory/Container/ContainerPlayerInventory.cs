using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerInventory : Container
{
    public ContainerPlayerInventory(Inventory containerInventory, Inventory playerInventory) : base (containerInventory, playerInventory)
    {
		for (int i = 0; i < 7; i++)
		{
			addSlotToContainer(playerInventory, i, -180 + (60 * i), -125, 50);
		}
		for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory, 7 + i, -180 + (60 * i), 125, 50);
        }

        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory, 14 + i, -180 + (60 * i), 65, 50);
        }

        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory, 21 + i, -180 + (60 * i), 0, 50);
        }

        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory, 28 + i, -180 + (60 * i), -65, 50);
        }
		
		
	}

    public override GameObject getContainerPrefab()
    {
        return InventoryManager.INSTANCE.getContainerPrefab("Player Inventory");
    }
}