using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    void Update()
    {
        // Eðer Alt tuþuna basýlý tutuluyorsa
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            // Fare imlecini göster
            Cursor.visible = true;
            // Fare imlecini kilidini aç
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Fare imlecini gizle
            Cursor.visible = false;
            // Fare imlecini kilitle
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
