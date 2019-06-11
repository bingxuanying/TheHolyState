using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    private Animator _animator;
    public float HP = 10;
    public float HPAmount = 10;
    public Image EnemyHPBar;
    public Image SelfHPBar;
    private Image HPBar;
    public bool isEnemy;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (isEnemy)
        {
            HPBar = EnemyHPBar;
            SelfHPBar.enabled = false;
        }
        else
        {
            HPBar = SelfHPBar;
            EnemyHPBar.enabled = false;

            if (CompareTag("Goblin"))
                GlobalVars.Goblin++;
            if (CompareTag("FireSpirit"))
                GlobalVars.FireSpirit++;
            if (CompareTag("EarthSpirit"))
                GlobalVars.EarthSpirit++;
            if (CompareTag("IceSpirit") || CompareTag("Purify"))
                GlobalVars.IceSpirit++;
            if (CompareTag("WindSpirit"))
                GlobalVars.WindSpirit++;
            else if (CompareTag("Skull"))
                GlobalVars.Skull++;
            else if (CompareTag("Slime") || CompareTag("Pollute"))
                GlobalVars.Slime++;
            else if (CompareTag("Ghost"))
                GlobalVars.Ghost++;
        }
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