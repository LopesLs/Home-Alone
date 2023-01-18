using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializing : MonoBehaviour
{
    public string sentence;
    public Text textBox;
    public GameObject firstButton;

    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char character in sentence)
        {
            textBox.text = textBox.text + character;
            yield return new WaitForSeconds(0.1f);
        }

        if (firstButton != null) {
            firstButton.SetActive(true);
        }
        else {
            Debug.Log("The button is missing!!!");
        }
    }
}