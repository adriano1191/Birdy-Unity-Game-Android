using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Button_Shoot : MonoBehaviour {

    public bool isRacePressed = false;
    public  bool clicked = false;
    private bool shooted = false;

    void Start()
    {
         

    }


    void Update()
    {
        Shoot shoot = gameObject.GetComponent<Shoot>();

        if (isRacePressed)
        {

                shoot.LoadingShoot();
            if (!shooted)
            {
                
                clicked = true;
                shooted = true;
                
            }
        }

        else if (!isRacePressed)
        {
            if (clicked)
            {
                shoot.Fire();
                clicked = false;
                gameObject.SetActive(false);
            }
            
        }
    }
    public void onPointerDownRaceButton()
    {
        isRacePressed = true;
    }
    public void onPointerUpRaceButton()
    {
        isRacePressed = false;
        
    }
}