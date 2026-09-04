using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooting : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private Coroutine coroutine;
    private void Update()
    {
        float distance = 2f;
        Collider2D nearestItem = null;
        DroppedItem nearestDroppedItem = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f, LayerMask.GetMask("Lootable"));
        // 가장 가까운 아이템을 찾기 위해 계산
        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<DroppedItem>().SetTarget(false);
                collider.GetComponent<DroppedItem>().SetColor(false);
                float currentDistance = Vector2.Distance(transform.position, collider.transform.position);
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    nearestItem = collider;
                }
            }
        }
        // 가장 가까운 아이템을 타겟으로 설정
        if(nearestItem != null)
        {
            nearestDroppedItem = nearestItem.GetComponent<DroppedItem>();
            if (nearestDroppedItem != null)
            {
                nearestDroppedItem.SetTarget(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && nearestDroppedItem != null)
        {
            LootItem(nearestItem);
        }
        // 프레임 하나 기다리고 색바꾸기
        coroutine = StartCoroutine(Waitframe(nearestDroppedItem));
    }
    private IEnumerator Waitframe(DroppedItem item)
    {
        yield return null;
        coroutine = null;
        if (item != null)
        {
            item.SetColor(item.IsTarget());
        }
    }

    private void LootItem(Collider2D itemCollider)
    {
        DroppedItem droppedItem = itemCollider.GetComponent<DroppedItem>();
        if (droppedItem != null)
        {
            int itemId = droppedItem.GetId();
            int itemCount = droppedItem.GetCount();
            inventory.AddItem(itemId, itemCount); // 인벤토리에 아이템 추가
            Destroy(itemCollider.gameObject); // 아이템 오브젝트 제거
        }
    }
}
