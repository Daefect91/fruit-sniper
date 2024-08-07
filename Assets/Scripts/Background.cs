using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Crosshair").GetComponent<PlayerController>();
    }

    private void OnMouseOver()
    {
        if (playerController.crossHair != null)
        {
            playerController.crossHair.color = Color.white;
        }
    }
}
