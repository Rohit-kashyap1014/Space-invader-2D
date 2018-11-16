using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

   public float speed = 15.0f;
   public float padding = 1.0f;
   
   public GameObject projectile;
   public float projectilesp;
   
   public float firingrate = 0.2f;
   public float health = 360f;
   public AudioClip firesound;
  
   
   float xmax;
   float xmin;
   
  
   
    void Start () {
    float distance = transform.position.z - Camera.main.transform.position.z;
    Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
	Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
	 xmin = leftmost.x + padding;
	 xmax = rightmost.x - padding;
    
    
    }
	void Fire () {
	    Vector3 offset = new Vector3(0,1,0);
		GameObject beam = Instantiate(projectile,transform.position+offset,Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0,projectilesp,0);
		AudioSource.PlayClipAtPoint(firesound,transform.position);
	
	}
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Space)) {
	InvokeRepeating("Fire",0.00001f,firingrate);
	
	} 
	if (Input.GetKeyUp(KeyCode.Space)) {
	
	CancelInvoke("Fire");
	}
	
	if (Input.GetKey(KeyCode.LeftArrow)) {
	
	transform.position+= Vector3.left*speed * Time.deltaTime;
	} else if(Input.GetKey(KeyCode.RightArrow)) {
	transform.position+= Vector3.right*speed * Time.deltaTime;
	}
	float newX = Mathf.Clamp(this.transform.position.x,xmin,xmax);
	transform.position = new Vector3(newX,this.transform.position.y,this.transform.position.z);
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
	
		Destroy(gameObject);
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen");
	
	}
	
}



