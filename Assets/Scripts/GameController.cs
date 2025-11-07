//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;

//// Controlador de juego RA comida
//public class GameController : MonoBehaviour
//{
//    public TextMeshProUGUI targetNameText;
//    public TextMeshProUGUI scoreText;
//    public TextMeshProUGUI livesText;
//    public TextMeshProUGUI depurText;

//    // PONER EL NOMBRE DE LA IMAGEN A BUSCAR
//    private List<string> opcionesBuscar = new List<string> { "hamburguesa", "tartachocolate", "waffle" };
//    private string targetABuscar;
//    private int vidas = 3;
//    private int puntuacion = 0;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        generaSiguienteTarget();
//        ActualizaUI();
//    }

//    void ActualizaUI()
//    {
//        targetNameText.text = "Busca " + targetABuscar;
//        livesText.text = "Vidas: " + vidas;
//        scoreText.text = "Puntuación: " + puntuacion;

//    }

//   public void OnTargetFound(string targetReconocido)
//    {
//        // Para depuración
//        //depurText.text = "Encontrado: " + targetReconocido;

//        if (targetReconocido == targetABuscar)
//        {
//            puntuacion++;
//            generaSiguienteTarget();
//        }
//        else
//        {
//            // Generar lógica de vida perdida y fin del juego
//            vidas--;
//            if (vidas == 0)
//            {
//                // Game Over
//                GameOver();
//            }
//        }
//        ActualizaUI();
//    }

//    void generaSiguienteTarget()
//    {
//        int posAleatoria = Random.Range(0, opcionesBuscar.Count);
//        targetABuscar = opcionesBuscar[posAleatoria];
//    }

//    // REVISAR ESTO PARA HACERLO FUNCIONAL
//    void GameOver()
//    {

//    }

//    // REVISAR ESTO PARA HACERLO FUNCIONAL
//    public void ReiniciarJuego()
//    {

//    }
//}
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI targetNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI depurText;

    public GameObject botonReiniciar;   // referencia al botón oculto
    public GameObject panelVictoria;    // opcional: panel de victoria
    public GameObject panelDerrota;     // opcional: panel de derrota

    private List<string> opcionesBuscar = new List<string> { "hamburguesa", "tartachocolate", "waffle" };
    private string targetABuscar;
    private int vidas = 3;
    private int puntuacion = 0;
    private int puntuacionParaGanar = 5;

    private bool juegoTerminado = false;

    void Start()
    {
        generaSiguienteTarget();
        ActualizaUI();
        botonReiniciar.SetActive(false);

        if (panelVictoria) panelVictoria.SetActive(false);
        if (panelDerrota) panelDerrota.SetActive(false);
    }

    void ActualizaUI()
    {
        targetNameText.text = "Busca " + targetABuscar;
        livesText.text = "Vidas: " + vidas;
        scoreText.text = "Puntuación: " + puntuacion;
    }

    public void OnTargetFound(string targetReconocido)
    {
        if (juegoTerminado) return;

        if (targetReconocido == targetABuscar)
        {
            puntuacion++;

            if (puntuacion >= puntuacionParaGanar)
            {
                Victoria();
                return;
            }

            generaSiguienteTarget();
        }
        else
        {
            vidas--;
            if (vidas <= 0)
            {
                GameOver();
                return;
            }
        }
        ActualizaUI();
    }

    void generaSiguienteTarget()
    {
        int posAleatoria = Random.Range(0, opcionesBuscar.Count);
        targetABuscar = opcionesBuscar[posAleatoria];
    }

    void GameOver()
    {
        juegoTerminado = true;     
        if (panelDerrota) panelDerrota.SetActive(true);
        botonReiniciar.SetActive(true);
    }

    void Victoria()
    {
        juegoTerminado = true;
        if (panelVictoria) panelVictoria.SetActive(true);
        botonReiniciar.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        Debug.Log("Botón Reiniciar presionado");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
