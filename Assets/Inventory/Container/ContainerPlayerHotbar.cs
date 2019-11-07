using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerHotbar : Container
{
    public ContainerPlayerHotbar(Inventory containerInventory, Inventory playerInventory) : base(containerInventory, playerInventory)
    {
        for(int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory, i, -175 + (60 * i), 0, 50);
        }
    }

    public override GameObject getContainerPrefab()
    {
        return InventoryManager.INSTANCE.getContainerPrefab("Player Hotbar");
    }
}