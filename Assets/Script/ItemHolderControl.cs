using System.Collections;

using System.Collections.Generic;

using System.ComponentModel.Design.Serialization;

using Microsoft.Unity.VisualStudio.Editor;

using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.U2D;



public class ItemHolderControl : MonoBehaviour, IPointerClickHandler

{

    public Item item;

    public GameObject player;

    public enum HolderType { Inventory, Head, Body, LeftHand, RightHand }

    public HolderType holderType;

    Coroutine clickCoroutine;

    Vector3[] corners = new Vector3[4];

    // Start is called before the first frame update

    void Awake()

    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Start()

    {

       

    }



    // Update is called once per frame

    void Update()

    {

        if (item != null)

            GetComponent<UnityEngine.UI.Image>().sprite = item.icon;

        else

            GetComponent<UnityEngine.UI.Image>().sprite = null;

    }

    public void OnPointerClick(PointerEventData eventData)

    {

        if (clickCoroutine != null)

        {

            StopCoroutine(clickCoroutine);

        }

        if (eventData.clickCount == 1)

        {

            clickCoroutine = StartCoroutine(ClickDelay(eventData));

        }

        else if (eventData.clickCount == 2)

        {

            if (eventData.button == PointerEventData.InputButton.Left)

            {

                DoubleLeftClick(gameObject.name);

            }

            else if (eventData.button == PointerEventData.InputButton.Right)

            {

                DoubleRightClick(gameObject.name);

            }

            if (clickCoroutine != null)

            {

                StopCoroutine(clickCoroutine);

                clickCoroutine = null;

            }

        }

    }

    private IEnumerator ClickDelay(PointerEventData eventData)

    {

        yield return new WaitForSeconds(0.2f);

        if (eventData.clickCount == 1)

        {

            if (eventData.button == PointerEventData.InputButton.Left)

            {

                LeftClick();

            }

            else if (eventData.button == PointerEventData.InputButton.Right)

            {

                RightClick();

            }

        }

    }



    public void LeftClick()

    {

        Debug.Log("Left Clicked on " + item.itemName);

    }

    public void RightClick()

    {

        Debug.Log("Right Clicked on " + item.itemName);

    }

    public void DoubleLeftClick(string name)

    {

        Debug.Log("Double Left Clicked on " + (item == null ? "null" : item.itemName));

        // holder has no name

        if (name == null) { Debug.Log("ERROR: name is null"); return; }

        // holder has no item

        if (name == "ItemHolder" && item == null && player.GetComponent<Equipment>().equippedPart.HasFlag(EquipmentType.LeftHand))

        {

            Debug.Log("Unequipping from left hand");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.LeftHand);

            return;

        }

        if (name == "RightHandHolder" || name == "HeadHolder" || name == "BodyHolder" && item == null)

        {

            Debug.Log("there is no item");

            return;

        }

        // holder has item

        if (name == "ItemHolder")

        {

            Debug.Log("Equipping to left hand from inventory");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.LeftHand);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().equip(EquipmentType.LeftHand, item);

            return;

        }

        if (name == "RightHandHolder" || name == "HeadHolder" || name == "BodyHolder")

        {
            EquipmentType temp;
            if (name == "RightHandHolder")
            {
                temp = EquipmentType.RightHand;
            }
            else if (name == "HeadHolder")
            {
                temp = EquipmentType.Head;
            }
            else
            {
                temp = EquipmentType.Body;
            }

            Debug.Log("Equipping to left hand from equipment");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.LeftHand);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().equip(EquipmentType.LeftHand, item);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(temp);

            return;

        }

        if (name == "LeftHandHolder")

        {

            Debug.Log("Unequipping from left hand");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.LeftHand);

            return;

        }

    }

    public void DoubleRightClick(string name)

    {

        Debug.Log("Double Right Clicked on " + (item == null ? "null" : item.itemName));

        if (name == null) { Debug.Log("ERROR: name is null"); return; }

        if (name == "ItemHolder" && item == null && player.GetComponent<Equipment>().equippedPart.HasFlag(EquipmentType.RightHand))

        {

            Debug.Log("Unequipping from right hand");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.RightHand);

            return;

        }

        if (name == "LeftHandHolder" || name == "HeadHolder" || name == "BodyHolder" && item == null)

        {

            Debug.Log("there is no item");

            return;

        }

        if (name == "ItemHolder")

        {

            Debug.Log("Equipping to right hand from inventory");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.RightHand);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().equip(EquipmentType.RightHand, item);

            return;

        }

        if (name == "LeftHandHolder" || name == "HeadHolder" || name == "BodyHolder")

        {
            EquipmentType temp;
            if(name == "LeftHandHolder")
            {
                temp = EquipmentType.LeftHand;
            }
            else if (name == "HeadHolder")
            {
                temp = EquipmentType.Head;
            }
            else
            {
                temp = EquipmentType.Body;
            }

            Debug.Log("Equipping to right hand from equipment");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.RightHand);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().equip(EquipmentType.RightHand, item);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(temp);

            return;

        }

        if (name == "RightHandHolder")

        {

            Debug.Log("Unequipping from right hand");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>().unequip(EquipmentType.RightHand);

            return;

        }

    }

}