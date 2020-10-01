/* Create Wood script 
 * Belirlenen alanda Wood prefab'in belirli aralıklarla, rastgele boyutlarda oluşturulması 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWood : MonoBehaviour {

	public GameObject wood; //yaratmak istediğimiz nesne 
	private float timer; //yaratma aralığı 
	private float speed; 

	void Start() { 
		speed = 10.0f; 
		timer = 1.5f; //yaratma aralığının belirlenmesi 
        InvokeRepeating ("Create", timer, timer); //Wood fonksiyonunun belirlenen aralıklarla çağırılması 
    } //end Start 

	void LateUpdate() {

	}

	//Belirlediğimiz nesnenin yaratılması fonksiyonu 
	public void Create() {
		float rangeXZ = Random.Range(0.3f, 1.0f); 
		GameObject newWood = Instantiate(wood, new Vector3(0.0f, 5.0f, 2.0f), Quaternion.Euler(0, 0, 90)); 
		newWood.transform.localScale = new Vector3 (rangeXZ, Random.Range(0.5f, 1.0f), rangeXZ); 
		newWood.GetComponent<Rigidbody>().angularVelocity = new Vector3 (-speed, 0.0f, 0.0f);  
		newWood.tag = "Split"; 
	} //end CreateWood 

} //eof 