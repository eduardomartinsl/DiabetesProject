using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CastDeAlimentos : MonoBehaviour {

	public AlimentoPositionFormater ReferenciaDeAlimentos;
	public GameObject ParticulasDeExplosao;
	public AudioClip SomAlimento;

	// Use this for initialization
	void Start () {
		ReferenciaDeAlimentos = GameObject.Find ("Plane1").GetComponent<AlimentoPositionFormater> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			RaycastHit hit; 
			if ( Physics.Raycast (ray,out hit,100.0f)) {
				Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
			}
			if (hit.collider.transform.name.Contains("1")) {
				StartCoroutine(ExecutaExplosao (hit.transform));
				Destroy (hit.collider.gameObject);
				StartCoroutine( ReferenciaDeAlimentos.FormataTubo (ReferenciaDeAlimentos.tubo1, "1"));
			}
			if (hit.collider.transform.name.Contains("2")) {
				StartCoroutine(ExecutaExplosao (hit.transform));
				Destroy (hit.collider.gameObject);
				StartCoroutine( ReferenciaDeAlimentos.FormataTubo (ReferenciaDeAlimentos.tubo2, "2")); 
			}
			if (hit.collider.transform.name.Contains("3")) {
				StartCoroutine(ExecutaExplosao (hit.transform));
				Destroy (hit.collider.gameObject);
				StartCoroutine( ReferenciaDeAlimentos.FormataTubo (ReferenciaDeAlimentos.tubo3, "3")); 
			}
			if (hit.collider.transform.name.Contains("4")) {
				StartCoroutine(ExecutaExplosao (hit.transform));
				Destroy (hit.collider.gameObject);
				StartCoroutine( ReferenciaDeAlimentos.FormataTubo (ReferenciaDeAlimentos.tubo4, "4")); 
			}
		}
	}

	public IEnumerator ExecutaExplosao(Transform posicaoDeExplosao){
		GetComponent<AudioSource> ().PlayOneShot(SomAlimento);
		GameObject EXPLOSION = Instantiate (ParticulasDeExplosao, posicaoDeExplosao.position, Quaternion.identity) as GameObject;
		EXPLOSION.GetComponent<ParticleSystem> ().Play();
		yield return new WaitForSeconds (1);
		Destroy (EXPLOSION);
	}
}
