using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUIScript : MonoBehaviour
{
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public GameObject Slot5;

    public void Damage(int health)
    {
        switch(health)
        {
            case 1: Slot5.SetActive(false); break;
            case 2: Slot4.SetActive(false); break;
            case 3: Slot3.SetActive(false); break;
            case 4: Slot2.SetActive(false); break;
            case 5: Slot1.SetActive(false); break;
        }
    }
}
