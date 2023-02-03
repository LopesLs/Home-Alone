// This script is used to Enable the videoFile GameObject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableVideo : MonoBehaviour
{   
    public GameObject videoFile;

    // Start is called before the first frame update
    void Start()
    {   
        videoFile.SetActive(true);
    }
}
