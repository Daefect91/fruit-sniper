using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button startButton;
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nameInput.text != null && nameInput.text != "")
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }
}
