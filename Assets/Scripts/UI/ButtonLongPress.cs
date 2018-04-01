using UnityEngine;
using UnityEngine.EventSystems;

public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isDown;
    private float downTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        this.isDown = true;
        this.downTime = Time.realtimeSinceStartup;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.isDown = false;
    }

    void Update()
    {
        if (!this.isDown) return;
        if (Time.realtimeSinceStartup - this.downTime > 2f)
        {
            print("Handle Long Tap");
            this.isDown = false;
        }
    }

}
