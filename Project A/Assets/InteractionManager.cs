using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject crystal; // Ýlk etkileþime geçilecek nesne
    public GameObject loadSceneController; // Ýkinci etkileþime geçilecek nesne
    public Transform spawnLocation; // Ýkinci nesnenin spawn olacaðý yer

    private bool isCrystalInteracted = false;

    void Start()
    {
        // Ýkinci nesneyi baþlangýçta devre dýþý býrak
        if (loadSceneController != null)
        {
            loadSceneController.SetActive(false);
            Debug.Log("LoadSceneController baþlangýçta devre dýþý býrakýldý.");
        }
        else
        {
            Debug.LogError("LoadSceneController atanmadý.");
        }

        if (crystal == null)
        {
            Debug.LogError("Crystal atanmadý.");
        }

        if (spawnLocation == null)
        {
            Debug.LogError("SpawnLocation atanmadý.");
        }
    }

    void Update()
    {
        // Eðer Crystal ile etkileþime geçildiyse ve F tuþuna basýldýysa
        if (isCrystalInteracted && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F tuþuna basýldý ve Crystal ile etkileþimde.");
            // Ýkinci nesneyi belirtilen konumda etkinleþtir
            if (loadSceneController != null)
            {
                loadSceneController.SetActive(true);
                loadSceneController.transform.position = spawnLocation.position;
                loadSceneController.transform.rotation = spawnLocation.rotation;
                Debug.Log("LoadSceneController etkinleþtirildi.");
            }
        }
        else if (isCrystalInteracted)
        {
            Debug.Log("Crystal ile etkileþimde ancak F tuþuna basýlmadý.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer Crystal ile çarpýþýldýysa
        if (other.gameObject == crystal)
        {
            Debug.Log("Crystal ile etkileþime girildi.");
            isCrystalInteracted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Eðer Crystal'den çýkýldýysa
        if (other.gameObject == crystal)
        {
            Debug.Log("Crystal ile etkileþimden çýkýldý.");
            isCrystalInteracted = false;
        }
    }
}
