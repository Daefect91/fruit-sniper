using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : ShootableObject, IShootableObject
{
    private readonly int pointsValue = 50;

    protected override void Update() 
    {
        if (transform.position.y < outOfBoundsY)
        {
            playerController.gameObject.SetActive(false);
            gameManager.GameOver();
            Destroy(gameObject);
        }
        base.Update();
    }

    public void PlayAnimation()
    {
        ParticleSystem ps = GameObject.Find("ClickSafe").GetComponent<ParticleSystem>();
        ps.transform.position = transform.position;
        ps.Play();
    } 

    protected override void DestroyShootableObject()
    {
        PlayAnimation();
        base.DestroyShootableObject();
        onDestroyed.Invoke(pointsValue);
    }
}
