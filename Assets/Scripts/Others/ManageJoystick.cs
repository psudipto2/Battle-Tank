using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManageJoystick : MonoBehaviour, IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    private Image JoystickOuter;
    private Image JoystickInner;
    private Vector2 posInput;

    void Start()
    {
        JoystickOuter = GetComponent<Image>();
        JoystickInner = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickOuter.rectTransform,eventData.position,eventData.pressEventCamera,out posInput))
        {
            posInput.x = posInput.x / (JoystickOuter.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (JoystickOuter.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());
            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }
            JoystickInner.rectTransform.anchoredPosition = new Vector2(posInput.x* (JoystickOuter.rectTransform.sizeDelta.x)/3, posInput.y* (JoystickOuter.rectTransform.sizeDelta.y)/3);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        JoystickInner.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float InputHorizontal()
    {
        if (posInput.x != 0)
        {
            return posInput.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float InputVertical()
    {
        if (posInput.y != 0)
        {
            return posInput.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
