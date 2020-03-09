using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] float projectileForce = 5f;
    [SerializeField] float projectileDamage = 10f;
    
    private Enemy enemycollision;


    // Start is called before the first frame update
    void Start()
    {
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
            
        }

        Destroy(gameObject, 2f);   
    }

    
}
