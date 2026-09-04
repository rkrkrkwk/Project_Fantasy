using UnityEngine;
using System.Collections;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private PlayerStatusManager playerStatusManager;
    [SerializeField] private GameObject itemHolder;
    [SerializeField] private InventoryContentDisplay inventoryContentDisplay;
    private Coroutine waitForDestroyCoroutine;
    private void OnEnable()
    {
        Refresh();
    }
    public void Refresh()
    {
        DestroyInventoryHolders();
        waitForDestroyCoroutine = StartCoroutine(WaitForDestroy());
    }
    private void GenerateInventoryHolders()
    {
        // Create new inventory holders based on the player's inventory size
        for (int i = 0; i < playerStatusManager.Inv; i++)
        {
            GameObject holder = Instantiate(itemHolder, inventoryPanel.transform);
            holder.name = "InventoryHolder_" + i;
            InventoryHolder inventoryHolder = holder.GetComponent<InventoryHolder>();
            inventoryHolder.setIndex(i);
        }
    }

    private void DestroyInventoryHolders()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private IEnumerator WaitForDestroy()
    {
        if (waitForDestroyCoroutine != null)
        {
            StopCoroutine(waitForDestroyCoroutine);
        }
        yield return null; // Wait for the end of the frame
        GenerateInventoryHolders();
        inventoryContentDisplay.UpdateInventoryDisplay();
        waitForDestroyCoroutine = null;
    }
}
