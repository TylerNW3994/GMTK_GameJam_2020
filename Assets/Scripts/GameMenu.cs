using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Text incorrectOrders;
    public Text money;
    public Text time;

    public GameObject PauseMenu;

    public int hour;
    public int minute;
    private float tenMinutes = 10.0f;

    private float timer;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown("Escape")){
            if(paused)
                UnpauseGame();
            else PauseGame();
        }
        


        if(!paused){
            timer += Time.deltaTime;
        }
        
        //If ten seconds pass, add ten minutes to the time
        if(timer >= tenMinutes){
            //If turning into new hour, add to hours and reset minute to 00
            if(minute == 50){
                minute = 0;
                hour++;
                if(hour == 13) hour = 1;
            }
            else minute += 10;

            //Update Time Text
            time.text = "" + hour + ":" + (minute == 0 ? "00" : minute.ToString());

        }

        if(Input.GetKeyDown("1")){
            //If there is an order in slot one
            GameObject order = GameManager.instance.currentOrders[0];

            setActiveOrder(order);
            
        } else if(Input.GetKeyDown("2")){
            //If there is an order in slot two
            GameObject order = GameManager.instance.currentOrders[1];

            setActiveOrder(order);
        } else if(Input.GetKeyDown("3")){
            //If there is an order in slot three
            GameObject order = GameManager.instance.currentOrders[2];

            setActiveOrder(order);
        } else if(Input.GetKeyDown("4")){
            //If there is an order in slot four
            GameObject order = GameManager.instance.currentOrders[3];

            setActiveOrder(order);
        }
    }

    private void setActiveOrder(GameObject order){
        if(order != null){
            //Set there to be an active order so we can't activate multiple orders
            if(!GameManager.instance.activeOrder == order.GetComponent<Order>())
            {
                GameManager.instance.activeOrder = order.GetComponent<Order>();

                //Open panel for orderType

            } else Debug.Log("Order Active!");
        }
    }

    public void PauseGame(){
        paused = true;
        PauseMenu.SetActive(true);
    }

    public void UnpauseGame(){
        paused = false;
        PauseMenu.SetActive(false);
    }
}
