using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum State
{
    gold, earned_gold, current_distance, max_distance, upgrade
}

public enum Upgrades
{
    up_1, up_2, up_3, up_4, up_5
}
    public class Score : MonoBehaviour {

    public Sprite[] numberSprite;
    private char[] numberCharArray;
    private int number;

    private string sGold;
    public State current;
    public Upgrades currUpgrade;


    void Start () {
        number = Stats.gold;
    }
	

	void Update () {
        if (current == State.gold)
        {
            number = Stats.gold + Stats.earned_gold;
        }
        else if(current == State.earned_gold)
        {
            number = Stats.earned_gold;
        }
        else if(current == State.current_distance)
        {
            number = Stats.current_distance_x;
        }
        else if(current == State.max_distance)
        {
            number = Stats.max_distance;
        }
        else if (current == State.upgrade)
        {
            if(currUpgrade == Upgrades.up_1)
            {
                number = Stats.up_1_cost;
            }
            else if(currUpgrade == Upgrades.up_2)
            {
                number = Stats.up_2_cost;
            }
            else if (currUpgrade == Upgrades.up_3)
            {
                number = Stats.up_3_cost;
            }
            else if (currUpgrade == Upgrades.up_4)
            {
                number = Stats.up_4_cost;
            }
            else if (currUpgrade == Upgrades.up_5)
            {
                number = Stats.up_5_cost;
            }
        }
        ScoreDisp();
        /*if(number != Stats.gold)
        {
            Score();
        }*/
    }

    void ScoreDisp()
    {
        //number = Stats.gold;
        numberCharArray = new char[6];
        sGold = number.ToString();
        if (sGold.Length < 6)
        {
            char[] tmpArray;
            tmpArray = sGold.ToCharArray();
            int leng = 6 - sGold.Length;

            for (int i = 0; i < leng; i++)
            {
                numberCharArray[i] = '0';

            }
            for (int i = 0; i < sGold.Length; i++)
            {
                numberCharArray[leng + i] = tmpArray[i];
            }

        }
        else
        {
            numberCharArray = sGold.ToCharArray();
        }

        int x = 0;
        foreach (char item in numberCharArray)
        {

            int i = (int)System.Char.GetNumericValue(numberCharArray[x]);
            if(x <= 5)
            {
                this.gameObject.transform.GetChild(5 - x).GetComponent<Image>().sprite = numberSprite[i];
                x++;
            }
            
        }

    }
}
