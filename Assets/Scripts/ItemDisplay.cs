using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject items;
    [SerializeField] GameObject player;
    [SerializeField] int numItems = 3;
    private int activeItem;
    private TextMeshPro tmPro;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        tmPro = this.transform.Find("DisplayText").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setItem(bool toggle)
    {
        isActive = true;
        activeItem = Random.Range(0, numItems - 1);
        GameObject item = items.transform.GetChild(activeItem).gameObject;
        item.SetActive(toggle);
        text.SetActive(toggle);
        tmPro.text = item.name;
    }

    private void useItem()
    {
        if (isActive)
        {
            switch (activeItem)
            {
                case 0:
                case 1:
                case 2:
                    player.SendMessage("deployTar", activeItem);
                    break;
                default:
                    break;
            }
            isActive = false;
            items.transform.GetChild(activeItem).gameObject.SetActive(false);
            text.SetActive(false);
        }
    }
}
