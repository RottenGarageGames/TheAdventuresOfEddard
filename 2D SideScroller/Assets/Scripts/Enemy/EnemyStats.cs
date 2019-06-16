using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{

    public float health;
    public float level;
    public float HealthBarCooldownTime;
    public bool OutOfRangeTimerComplete;
    private bool inRange = false;
    private bool _startTimer = false;
    public bool collidingWithPlayer = false;
    private int meleeDamage;
    private float _timer;

    public ItemList monsterDrops;



    public GameObject enemyHealthBar;
    public bool hasBossHealthBar;
    private Slider slider;
    public GameObject bloodEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (hasBossHealthBar)
        {
            slider = enemyHealthBar.GetComponent<Slider>();
            slider.maxValue = health;
            slider.value = health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_startTimer)
        {
            _timer += Time.deltaTime;
        }

        if(_timer > HealthBarCooldownTime)
        {
            OutOfRangeTimerComplete = true;
        }
        if (enemyHealthBar != null && OutOfRangeTimerComplete)
        {
            enemyHealthBar.SetActive(false);
        }
        if (health <= 0)
        {
            if (bloodEffect != null)
            {
                Instantiate(bloodEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            //if(monsterDrops != null)
            //{
            //    SpawnDrops();
            //}
            Destroy(gameObject);
            
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
            Debug.Log("Enemy: Collided with the Player"); 
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (slider != null)
        {
            slider.value = health;
        }
        
        
    }
    public void TogglePlayerInRange()
    {
        if (collidingWithPlayer)
        {
            inRange = !inRange;
            if (inRange)
            {
                _timer = 0f;
                OutOfRangeTimerComplete = false;
                _startTimer = false;
                if (enemyHealthBar != null)
                {
                    enemyHealthBar.SetActive(true);
                }
            }
            else
            {
                _startTimer = true;
            }
        }
    }
    public void SpawnDrops()
    {
        var length = monsterDrops.itemDatas.Count;
        var itemToSpawn = monsterDrops.itemDatas[Random.Range(0, length)];
        Debug.Log(itemToSpawn);
        Instantiate(itemToSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }   

}
