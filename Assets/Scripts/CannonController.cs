using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ShootingPosition;
    public GameObject BallPrefab;
    public ParticleSystem ParticleSystem;

    private float _shootingSpeed = 1000f;
    private Vector2 _shootingDirection;

    private void OnEnable()
    {
        LevelManager.OnDrawStateFinish += Shoot;
    }

    private void OnDisable()
    {
        LevelManager.OnDrawStateFinish -= Shoot;
    }
    
    private void Awake()
    {
        _shootingDirection = ShootingPosition.transform.right;
    }

    private void Start()
    {
        GameManager.Singleton.SoundManager.PlaySound(GameManager.Singleton.SoundManager.CannonBurningSound);
        ParticleSystem.Play();
    }

    private void Shoot()
    {
        GameManager.Singleton.SoundManager.PlaySound(GameManager.Singleton.SoundManager.CannonShootSound);
        ParticleSystem.Stop();

        var obj = Instantiate(BallPrefab, ShootingPosition.transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(_shootingDirection * _shootingSpeed);
    }
}
