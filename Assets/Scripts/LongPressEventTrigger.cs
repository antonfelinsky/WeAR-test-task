using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class LongPressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    #region Fields
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    public float durationThreshold = 2.0f;
    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;

    public UnityEvent onLongPress = new UnityEvent();
    public UnityEvent onShortPress = new UnityEvent();
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (isPointerDown && !longPressTriggered)
        {
            if (Time.time - timePressStarted > durationThreshold)
            {
                longPressTriggered = true;
                onLongPress.Invoke();
            }

        }
        if (Time.time - timePressStarted < durationThreshold)
        {
            onShortPress.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        timePressStarted = Time.time;
        isPointerDown = true;
        longPressTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerDown = false;
    } 
    #endregion
}

