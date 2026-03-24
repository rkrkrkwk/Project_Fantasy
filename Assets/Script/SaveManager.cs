using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    public static SaveManager Instance = new SaveManager();
    int saveSlot = -1;

    public void SetSaveSlot(int slot)
    {
        saveSlot = slot;
    }

    public int GetSaveSlot()
    {
        return saveSlot;
    }
}
