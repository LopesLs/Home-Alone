// This script is used to create an effect of typing in the screeen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour
{
    public string sentence;
    public Text textBox;
    public GameObject firstOption;
    public GameObject secondOption;
    public GameObject thisScreen;
    public GameObject nextScreen;

    void Start()
    {
        // Starts the typing Coroutine
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        // Loop through each character in the sentence
        foreach (char character in sentence)
        {
            // Adding to the textbox one character
            textBox.text = textBox.text + character;
            
            // Wait for a set amount of time before adding the next character
            yield return new WaitForSeconds(0.04f);

            // The skip function
            if (Input.GetKeyDown(KeyCode.Space)) {
                textBox.text = sentence;
                break;
            }
        }

        if (firstOption == null) {

        }

        else {
            firstOption.SetActive(true);
        }

        if (secondOption == null) {

        }

        else {
            secondOption.SetActive(true);
        }
        

        if (thisScreen == null || nextScreen == null) {

        }

        else {
            yield return new WaitForSeconds(1);
            thisScreen.SetActive(false);
            nextScreen.SetActive(true);
        }
    }
}