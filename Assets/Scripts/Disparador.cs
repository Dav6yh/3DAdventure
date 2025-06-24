using System.Collections;
using UnityEngine;

public class Disparador : MonoBehaviour
{


    [SerializeField] private GameObject flechaPreFab;
    [SerializeField] private GameObject miraFlecha;
    [SerializeField] private int forcaTiro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Atirar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Atirar()
    {
        StartCoroutine(AtirarFlecha());
        
    }

    IEnumerator AtirarFlecha()
    {
        yield return new WaitForSeconds(3f);
        GameObject flecha = Instantiate(flechaPreFab, miraFlecha.transform.position, miraFlecha.transform.rotation);
        flecha.transform.rotation *= Quaternion.Euler(270, 0, 0);
        Rigidbody rbFlecha = flecha.GetComponent<Rigidbody>();
        rbFlecha.AddForce(miraFlecha.transform.forward * forcaTiro, ForceMode.Impulse);
        StartCoroutine(AtirarFlecha());
    }
}
