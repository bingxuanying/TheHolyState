using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    private Animator _animator;
    public float HP = 10;
    public float HPAmount = 10;
    public Image HPBar;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Hurt(float hp)
    {
        HP -= hp;
        HPBar.fillAmount = HP / HPAmount;
        if (HP < 0.00001)
            StartCoroutine(Death());
        // else
        //     StartCoroutine(HurtAnimation());
    }

    private IEnumerator HurtAnimation()
    {
        _animator?.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.1f);
        _animator?.SetBool("Hurt", false);
    }

    public void Heal(float hp)
    {
        if (HP > 0.00001)
        {
            HP += hp;
            HPBar.fillAmount = HP / HPAmount;
        }
    }

    public IEnumerator Death()
    {
        HP = 0;
        HPBar.fillAmount = 0;
        _animator?.SetBool("Death", true);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}