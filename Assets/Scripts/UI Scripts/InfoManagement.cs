// This script is used to manage the texts os sensorScreen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManagement : MonoBehaviour
{   
    public string comodo;
    public GameObject iconAlert;
    public Text movimentInfoBox;
    public Text roomInfoBox;

    public void WriteText() {
        if (iconAlert.activeInHierarchy == true) {
            movimentInfoBox.text = "Movimento detectado!";
       }
       else {
            movimentInfoBox.text = "Sem movimento";
       }

       roomInfoBox.text = "Comôdo selecionado - " + comodo;
    }
}
