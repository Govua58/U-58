using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    void Update()
    {
        // E�er Alt tu�una bas�l� tutuluyorsa
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            // Fare imlecini g�ster
            Cursor.visible = true;
            // Fare imlecini kilidini a�
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
