using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalRobot : MonoBehaviour
{
    [SerializeField] private Fade fade;

    public void finalMalo()
    {
        fade.activar();
        Invoke("cambiarAlFinal", 3);
    }

    private void cambiarAlFinal()
    {
        SceneManager.LoadScene(9);
    }
}
