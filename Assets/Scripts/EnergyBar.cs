using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

    public float energyMax;
    public float energy;
    public float barSize;

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {


        EnergyChange();



    }

    void EnergyChange()
    {
        energyMax = Stats.energyMax;
        energy = Stats.energy;
        barSize = (energy / energyMax) * 1.0f;

        GetComponentInChildren<Image>().fillAmount = barSize;

    }
}
