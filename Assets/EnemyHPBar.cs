using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public EnemyHealth hp;
    public Slider slider;
    public Vector3 Offset;

    void Start()
    {
        hp = GetComponentInParent<EnemyHealth>();
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = hp.health;
    }
    public void Damage(int amount)
    {

        hp.health -= amount;

        if (hp.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        if (this.slider == null) return;
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        slider.value = hp.health;
    }
}

