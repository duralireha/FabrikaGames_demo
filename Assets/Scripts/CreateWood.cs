/* Create Wood script 
 * Belirlenen alanda Wood prefab'in belirli aralıklarla, rastgele boyutlarda oluşturulması 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWood : MonoBehaviour {

	public GameObject wood; //yaratmak istediğimiz nesne 
	private float timer; //yaratma aralığı 
	private float positionMax, positionMin; //yaratma pozisyonu 
	private float rangeXZ, rangeY; 

	void Start() { 
		timer = 1.5f; //yaratma aralığının belirlenmesi 
		rangeY = Random.Range(0.5f, 1.0f); //wood nesnesinin y scale değerinin rastgele belirlenmesi 
		rangeXZ = Random.Range(0.3f, 1.0f); //wood nesnesinin x ve z scale değerlerinin aynı rastgele sayı olması 
		positionMax = 2.0f - (rangeY / 2); //wood nesnesinin yaratılma pozisyonunun minimum değeri 
		positionMin = -2.0f + (rangeY / 2); //wood nesnesinin yaratılma pozisyonunun maximum değeri  

        InvokeRepeating ("Create", timer, timer); //Wood fonksiyonunun belirlenen aralıklarla çağırılması 
    } //end Start 
	
	//Belirlediğimiz nesnenin yaratılması fonksiyonu 
	public void Create() { 
		GameObject newWood = Instantiate(wood, new Vector3(Random.Range(positionMin, positionMax), 5.0f, 2.0f), Quaternion.Euler(0, 0, 90)); //wood nesnesinin yaratılması 
		newWood.transform.localScale = new Vector3 (rangeXZ, rangeY, rangeXZ); //yaratılan nesnenin rastgele scale edilmesi 
		newWood.tag = "Split"; //yaratılan nesnenin SplitWood script'ine uygun şekilde etiketlenmesi 
	} //end CreateWood 

} //eof 