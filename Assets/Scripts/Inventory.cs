using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>(); //리스트에 담아 관리
    private int maxSlot = 5;                            //슬롯은 5개
    public GameObject slotPrefab;

    void Start()
    {
        GameObject slotPanel = GameObject.Find("StarSlotPanel");

        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }
}
