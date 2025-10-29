using UnityEngine;
using Vuforia;

public class ImageTargetHandler : MonoBehaviour
{
    // Referencia al componente ObserverBehaviour, que se utiliza para manejar el estado del objetivo de imagen en Vuforia
    private ObserverBehaviour observerBehaviour;

    // Referencia al controlador del juego, que probablemente maneja la lógica principal del juego
    private GameController gameController;

    // Start se ejecuta una vez antes de la primera actualización del frame (Update)
    void Start()
    {
        // Obtiene el componente ObserverBehaviour asociado a este GameObject
        observerBehaviour = GetComponent<ObserverBehaviour>();

        // Busca la primera instancia del GameController en la escena
        gameController = FindFirstObjectByType<GameController>();

        // Si el componente ObserverBehaviour existe, se suscribe al evento OnTargetStatusChanged
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    // Método que se ejecuta cuando cambia el estado del objetivo de imagen (target)
    // behaviour: referencia al ObserverBehaviour que detectó el cambio
    // status: nuevo estado del objetivo (por ejemplo, detectado, perdido, etc.)
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED)
        {
            gameController.OnTargetFound(behaviour.TargetName);
        }
    }
}