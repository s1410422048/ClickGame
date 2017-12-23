using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {
    [SerializeField]//當使用 private 或 protected 等其他修飾字來宣告時，如果，希望該欄位變數也可以在 Inspector 視窗出現可編輯的欄位，可以在它的上一行插入 SerializeField 
    private Slider healthSlider;
    private int currentHealth;
    [SerializeField]
    private float speed = 5;
    public bool IsOver
    {
        get
        {
            return currentHealth <= healthSlider.minValue;
        }
    }

    [ContextMenu("Test Init 100")] //初始化血量為100
    private void TestInit()
    {
        Init(100);
    }

    [ContextMenu("Test Init 50")]//初始化傷害為50
    private void TestHurt()
    {
        Hurt(50);
    }

    // Use this for initialization
    public void Init(int maxHealth)//初始化血量
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
    }
    public void Hurt(int damage)
    {
        currentHealth -= damage;
        currentHealth = (int)Mathf.Max(currentHealth, healthSlider.minValue);
    }
    private void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * speed); 
    }
}
