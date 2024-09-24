using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    [Range(2, 10)]
    private float speed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = speed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Time.timeScale = 2;
    }

    
}
