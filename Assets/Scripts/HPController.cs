using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public Image HPBar;

    public float HPAmount = 10;

    public float HP = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = HP / HPAmount;
        if (HP < 0.00001)
        {
            StartCoroutine(Death());
        }
    }

    public IEnumerator Death()
    {
        HP = 0;
        HPBar.fillAmount = 0;
        var animator = GetComponent<Animator>();
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(0.33333f);
        DestroyMe();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
