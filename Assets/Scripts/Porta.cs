using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] private int numeroPorta;
    [SerializeField] private bool portaTrancada = false;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    public void AbrirPorta(int nChave = 0)
    {
        if(nChave == 0 && !portaTrancada)
        {
            animator.SetTrigger("Abrir");
        }
        else if (nChave == numeroPorta && portaTrancada)
        {
            animator.SetTrigger("Abrir");
            portaTrancada = false; // Porta � destrancada ap�s ser aberta com a chave correta
        }
    }
    public bool PortaTrancada()
    {
        return portaTrancada;
    }
}
