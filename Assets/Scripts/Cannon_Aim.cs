using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cannon_Aim : MonoBehaviour {

    public static bool itseditor = false;
    private Vector3 mouse_pos;
    public Transform target;
    private Vector3 object_pos;
    private float angle;
    void Aim()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -20;
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        if(angle >= 80.0f)
        {
            angle = 80.0f;
        }
        if(angle <= 0)
        {
            angle = 0;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Start()
    {
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
        itseditor = true;
#else
        Debug.Log("No Unity Editor");
        itseditor = false;
#endif
    }

    void Update()
    {

        if(itseditor == true)
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Aim();
            }
        }
        else
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Aim();
            }
        }

    }

}
