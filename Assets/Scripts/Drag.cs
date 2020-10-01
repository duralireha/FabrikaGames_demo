/* Drag script 
 * Mobil cihazlar için oyun kontrolü 
 * Ekrana dokunarak testerenin sağa ya da sola hareket ettirilmesini sağlayan script 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	private Touch touch; //mobil cihazlar için tanımladığımız bir "dokunma" değişkeni 
	private float speed; //nesnenin hareket hızı 

    void Start() { 
		speed = 0.005f; 
    } //end Start 

	void Update() {

		if (Input.touchCount > 0) { //ekrana dokunup dokunmadığımızın kontrolü 
			touch = Input.GetTouch(0); //çok sayıda parmağı algılayan cihazlar için ilk dokunmayı seçiyoruz, bize yalnızca bir parmak gerek ve yeter 

			if (touch.phase == TouchPhase.Moved) { //sürükleme hareketinin algılanması 

				if (transform.position.x <= 1.7f) { //testerenin belirlediğimiz sınırlarda kalmasını sağlayan if koşulu
					//ekranda parmağımızı ne yöne sürüklediğimizi hesaplayıp, nesnenin bu yönde yerinin değiştirilmesi 
					transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
				} else { //sınır dışına çıkılması durumunda testerenin sınırın içine atılması 
					transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
				} //end if-else trnasform.position.x 

				if (transform.position.x >= -1.7f) { //testerenin belirlediğimiz sınırlarda kalmasını sağlayan if koşulu
					//ekranda parmağımızı ne yöne sürüklediğimizi hesaplayıp, nesnenin bu yönde yerinin değiştirilmesi 
					transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
				} else { //sınır dışına çıkılması durumunda testerenin sınırın içine atılması 
					transform.position = new Vector3(-1.7f, transform.position.y, transform.position.z);
				} //end if-else trnasform.position.x 



			} //end if touch.phase Moved  

		} //end if touchCount

    } //end Update 

} //eof 