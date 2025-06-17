using UnityEngine;

public class ObjetoQuebra : MonoBehaviour
{
    [SerializeField] private int vidaObj;
    [SerializeField] private GameObject objetoQuebra;

    public void Quebrar(int dano)
    {
        vidaObj -= dano;
        if (vidaObj <= 0)
        {
            Instantiate(objetoQuebra, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
