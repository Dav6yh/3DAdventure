using UnityEngine;

public class Chave : MonoBehaviour
{
    // This script is used to represent a key in the game.
    [SerializeField] private int numeroPorta;

    public int NumeroPorta()
    {
        return numeroPorta;
    }

    public void PegarChave()
    {
        Destroy(gameObject);
    }

    public void UsarChave()
    {

    }
}
