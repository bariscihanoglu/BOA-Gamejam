using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float damageTaken;
    public bool isAlive = true;
    public float assignedSpeed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private CircleCollider2D _circleCollider2D;
    private EnemyAI _enemyAI;
    private GameObject _player;
    private PlayerStats _playerStats;
    private GameObject _audioManagerObject;
    private AudioManager _audioManager;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _enemyAI = GetComponent<EnemyAI>();
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            _playerStats = _player.GetComponent<PlayerStats>();
        }
        _audioManagerObject = GameObject.FindGameObjectWithTag("Audio");
        if(_audioManagerObject != null)
        {
            _audioManager = _audioManagerObject.GetComponent<AudioManager>();
        }
        health = maxHealth;
        assignedSpeed = _enemyAI.speed;
    }

    private void DealDamage(float damage)
    {
        health -= damage;
        _animator.Play("HitTree");
        CheckDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DealDamage(damageTaken);
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            _enemyAI.speed = 0;
            //boris sikmiş düzeltilecek
            if (isAlive)
            {
                _audioManager.PlaySFX(_audioManager.enemyDeath);
            }
            isAlive = false;
            _playerStats.killCnt++;
            _animator.SetTrigger("death");
            // DEATH ANIMATION WILL CALL THE RESTART
            //RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    
    private void CloseCol()
    {
        _circleCollider2D.enabled = false;
    }

    private void returnAssignedSpeed()
    {
        _enemyAI.speed = assignedSpeed;
    }
}
