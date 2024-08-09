using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragAndDrop2D : MonoBehaviour
{
    private Transform draggedObject;

    [SerializeField]
    private UnityEvent releaseEvent;

    public bool Get(Vector2 position)
    {
        Camera camera= Camera.main;
        Ray ray=camera.ScreenPointToRay(position);
        Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit2D hit=Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            Collider2D collider = hit.collider;
            if (collider.CompareTag("Water") && collider.gameObject.layer == LayerMask.NameToLayer("Draggable"))
            {
                draggedObject = collider.transform;
                return Hold(position);
            }
            else return false;
        }
        else return false;
    }

    public bool Hold(Vector2 position)
    {
        position=Camera.main.ScreenToWorldPoint(position);
        if (draggedObject != null)
        {
            Rigidbody2D rigidbody=draggedObject.GetComponent<Rigidbody2D>();
            rigidbody.isKinematic = true;

            draggedObject.position = position;
            return true;
        }
        else return false;
    }

    public bool Release()
    {
        Rigidbody2D rigidbody=draggedObject.GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = false;
        draggedObject = null;
        return true;
    }
}
