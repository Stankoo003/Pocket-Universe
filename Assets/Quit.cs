using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public static void quitGame() {
        FindObjectOfType<ChangeCoins>().SaveData();
        Application.Quit();
        


    }




}
