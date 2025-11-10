using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Playgame()
    {
        //Reemplaza siempre por el nombre de tu escena de juego o el nº de indice de la escena
        SceneManager.LoadScene(1);
    }
    
    public void Quitgame()
    {
        Application.Quit(); //En android cerrará la app
    }
    public void Informacion()
    {
        SceneManager.LoadScene(2);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }
}
