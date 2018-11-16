using UnityEngine;
using System.Collections;

public class enemybehaviour : MonoBehaviour {

public float health = 160f;
public GameObject projectile;
public float projectilevel = 10f;
public float shotspersecond = 0.5f; 
private ScoreKeeper scorekeeper;
public int Scorevalue =130;
public AudioClip firesound;
public AudioClip deathsound;

    void Start() {
    
    scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    
    
    }

    void Update() {
     float probability = Time.deltaTime * shotspersecond;
     if(Random.value < probability) {
     Fire();
    }
   } 
    
    void Fire() {
    
		Vector3 startposition = transform.position + new Vector3(0,-1,0);
		GameObject missile = Instantiate(projectile,startposition,Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector3(0,-projectilevel,0);
		AudioSource.PlayClipAtPoint(firesound,transform.position);
		
    
    
    
    }

	void OnTriggerEnter2D(Collider2D collider) {
	
	Projectile missile = collider.gameObject.GetComponent<Projectile>();
	if(missile) {
	health-=missile.GetDamage();
	missile.Hit();
	if(health <= 0) {
	Die();
	}
   }
 }
 
 void Die() {
 
		AudioSource.PlayClipAtPoint(deathsound,transform.position);
		Destroy(gameObject);
		scorekeeper.Score(Scorevalue);
 
 
 }
}
