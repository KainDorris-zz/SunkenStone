using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{

    [SerializeField] private Enemy enemy;
    private float enemyHealthPercentage;
    private float enemyMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (enemy == null){
            enemy = transform.root.GetComponent<Enemy>();
        } 
        enemyMaxHealth = enemy.GetCurrentHealth(); 
    }

    // Update is called once per frame
    void Update()
    {
          UpdateSize();
    }



    private void UpdateSize(){
        //multiply by 2 because transform.scale.x = 2
        enemyHealthPercentage =  enemy.GetCurrentHealth() / enemyMaxHealth * 2; 
        gameObject.transform.localScale = new Vector3(enemyHealthPercentage, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
