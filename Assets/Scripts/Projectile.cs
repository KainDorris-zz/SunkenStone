using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] public ProjectileScriptableObject projectileData;

    private float projectileForce;
    private float projectileDamage;
    private float enemyProjectileDamage;
    private float enemyProjectileForce;
    private DamageType damageType;
    private SpriteRenderer spriteRenderer;
    private Enemy enemycollision;
    private Player playercollision;
    private bool hasImpactedSomething = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Setup();
        if(gameObject.transform.root.GetComponent<Enemy>() is Enemy){
            gameObject.layer = 9;
            projectileForce = enemyProjectileForce;
            projectileDamage = enemyProjectileDamage;
            gameObject.transform.parent = gameObject.transform;
            
        }
        else //assumed to be a player projectile
        {
            gameObject.layer = 8;

        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileForce, ForceMode2D.Impulse);
        StartCoroutine(PlayAudioClip());
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
        
    }

    IEnumerator PlayAudioClip(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }


    private void disableComponents(){
        
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<SpriteRenderer>());

    }

    private void Impact(Collider2D col){
        if (col.gameObject.GetComponent<Enemy>())
        {
            hasImpactedSomething = true;
            disableComponents();
            enemycollision = col.gameObject.GetComponent<Enemy>();
            if(CheckWeaknesses(enemycollision.GetWeaknesses())){
                enemycollision.TakeDamage(projectileDamage * 2);
                //todo implement critical audio clip
                Debug.Log("Critcial!" + projectileDamage * 2);
            }
            else if(CheckResistances(enemycollision.GetResistances())){
                enemycollision.TakeDamage(projectileDamage / 0.5f);
            }
            else{
                enemycollision.TakeDamage(projectileDamage);
            }
            Destroy(gameObject, 2f);
            
        }
        else if (col.gameObject.GetComponent<Player>())
        {
            hasImpactedSomething = true;
            disableComponents();
            playercollision = col.gameObject.GetComponent<Player>();
            playercollision.TakeDamage(projectileDamage);
            Destroy(gameObject, 2f);
            
        }
    }


    private bool CheckWeaknesses(List<DamageType> weaknesses){
        foreach(DamageType weakness in weaknesses){
            if(weakness == damageType){
                return true;
            }
        }
        return false;
    }

    private bool CheckResistances(List<DamageType> resistances){
        foreach(DamageType resistance in resistances){
            if (resistance == damageType){
                return true;
            }
        }
        return false;
    }
    
    

    private void OnTriggerEnter2D(Collider2D col){
        if (hasImpactedSomething == false)
        {
            Impact(col);
        }
    }

    private void Setup(){
        projectileForce = projectileData.projectileForce;
        projectileDamage = projectileData.projectileDamage;
        enemyProjectileDamage = projectileData.enemyProjectileDamage;
        enemyProjectileForce = projectileData.enemyProjectileForce;
        spriteRenderer.sprite = projectileData.projectileSprite;
        damageType = projectileData.damageTypes;
        

    }

    
}
