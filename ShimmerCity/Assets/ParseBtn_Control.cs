using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ParseBtn_Control : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    public Sprite[] sprites;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = sprites[0];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = sprites[1];
    }


}
