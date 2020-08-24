using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_1 : MonoBehaviour {

    public int energy_upgrade; //dodatkowa liczba skoków

    private void Start()
    {
        Upgrade_1();
    }

    public void Upgrade_1()  //Zwiekszenie liczby skokow
    {
        int energy_number_upgrade;

        energy_number_upgrade = Stats.up_1;
        energy_upgrade = energy_number_upgrade;

    }
}
