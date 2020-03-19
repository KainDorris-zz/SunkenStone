using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] float projectileForce = 5f;
    [SerializeField] float projectileDamage = 10f;
    
    private Enemy enemycollision;
    private Player playercollision;


    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.root.GetComponent<Enemy>() is Enemy){
            gameObject.layer = 9;
            projectileForce = 3f;
            projectileDamage = 1f;
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
        Destroy(gameObject, 3.0f);
        
    }

    IEnumerator PlayAudioClip(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }

    private void Impact()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<SpriteRenderer>());
    }

    private void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.GetComponent<Enemy>())
        {
            
            Impact();
            enemycollision = col.gameObject.GetComponent<Enemy>();
            enemycollision.TakeDamage(projectileDamage);
            Destroy(gameObject, 2f);
               
        }
        else if (col.gameObject.GetComponent<Player>())
        {
            
            Impact();
            playercollision = col.gameObject.GetComponent<Player>();
            playercollision.TakeDamage(projectileDamage);
            Destroy(gameObject, 2f);
            
        }
        else
        {
            
        }
    }

    
}
