using UnityEngine;

public class DispararFlecha : MonoBehaviour
{
    
    [SerializeField] private int dano;
    [SerializeField] private GameObject destroyFlechaPreFab;

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(destroyMachadoPreFab, transform.position, gameObject.transform.rotation);
        GetComponent<ParticleSystem>().Stop();

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SistemaDeVida>().Dano(dano);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }

    }



}


