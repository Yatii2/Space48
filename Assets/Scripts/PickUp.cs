using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private TMP_Text messageField;


    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    IEnumerator ShowMessage(string message)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
    }
    private void Update()
    {
        CycleItems();
        UseItem();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }
    void PickUpItem(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);
        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
    void UseItem()
    {

        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {

            if (items[activeItemIndex] == Color.blue)
            {
                StartCoroutine(ShowMessage(" +  Move Speed"));
                moveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                StartCoroutine(ShowMessage(" + Fire Rate"));
                cooldownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                StartCoroutine(ShowMessage(" + Rotation Speed"));
                rotationSpeed += 10;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }

        }
    }
}
