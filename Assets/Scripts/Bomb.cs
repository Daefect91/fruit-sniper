using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ShootableObject, IShootableObject
{
    public AudioClip clickBombAudioClip;
    private readonly int pointsValue = -100;

    public void UpdateScore()
    {
        onDestroyed.Invoke(-100);
    }

    public void PlayAnimation()
    {
        ParticleSystem ps = GameObject.Find("ClickUnsafe").GetComponent<ParticleSystem>();
        ps.transform.position = transform.position;
        ps.Play();
    }

    protected override void DestroyShootableObject()
    {
        PlayAnimation();
        MusicPlayer.Instance.PlayAudioClip(clickBombAudioClip);
        playerController.gameObject.SetActive(false);
        gameManager.GameOver();
        base.DestroyShootableObject();
        onDestroyed.Invoke(pointsValue);
    }
}
