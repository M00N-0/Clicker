using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    [SerializeField] private Text nameText;

    [SerializeField] private string monsterName;
    [SerializeField] private float maxHp;
    private float curHp;

    private bool isDead = false;
    private Animator animator;

    private void Awake()
    {
        curHp = maxHp;
        nameText.text = monsterName;
    }

    public void OnHit(float damage)
    {
        curHp -= damage;
        if(curHp < 0)
        {
            curHp = 0;
            isDead = true;
        }
        Debug.Log("Slime Hit!, Current Hp : " + curHp);
        hpBar.ChangeHpBarAmount(curHp / maxHp);

        if (isDead)
        {
            Debug.Log("Slime is Dead");
            Destroy(gameObject, 1.5f);
            Destroy(nameText);
            hpBar.OnDestroy();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
