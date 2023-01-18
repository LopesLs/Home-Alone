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
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char character in sentence)
        {
            textBox.text = textBox.text + character;
            yield return new WaitForSeconds(0.04f);

            if (Input.GetKeyDown(KeyCode.Space)) {
                textBox.text = sentence;
                break;
            }
        }

        if (firstOption != null && secondOption != null) {
            firstOption.SetActive(true);
            secondOption.SetActive(true);
        }

        else {
            if (thisScreen == null || nextScreen == null) {
                Debug.Log("Screens are missing!!!");
            }

            else {
                yield return new WaitForSeconds(1);
                thisScreen.SetActive(false);
                nextScreen.SetActive(true);
            }
        }
    }
}