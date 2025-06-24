using UnityEngine;

public class Machado : MonoBehaviour
{
    [SerializeField] private int dano = 10;
    [SerializeField] private GameObject destroyMachadoPreFab;

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(destroyMachadoPreFab, transform.position, gameObject.transform.rotation);
        GetComponent<ParticleSystem>().Stop();
        Destroy(this.gameObject);


    }
}
