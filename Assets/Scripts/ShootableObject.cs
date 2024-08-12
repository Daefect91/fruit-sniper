using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//ABSTRACTION
public abstract class ShootableObject : MonoBehaviour
{
    //ENCAPSULATION
    protected PlayerController playerController;
    protected GameManager gameManager;
    protected readonly float outOfBoundsY = -18.0f;
    public UnityEvent<int> onDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Crosshair").GetComponent<PlayerController>();
        onDestroyed.AddListener(UpdateScore);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateScore(int points)
    {
        gameManager.score += points;
        gameManager.scoreText.text = "Score: " + gameManager.score;
    }

    void OnMouseOver()
    {
        if (playerController.crossHair != null)
        {
            if (gameObject.CompareTag("Safe_Target"))
            {
                playerController.crossHair.color = Color.green;
            }
            else if (gameObject.CompareTag("Unsafe_Target"))
            {
                playerController.crossHair.color = Color.red;
            }
        }
    }

    void OnMouseExit()
    {
        if (playerController.crossHair != null)
        {
            playerController.crossHair.color = Color.white;
        }
    }

    void OnMouseDown()
    {
        DestroyShootableObject();
    }

    protected virtual void DestroyShootableObject()
    {
        Destroy(gameObject);
    }
}
