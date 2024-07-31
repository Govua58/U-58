using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject crystal; // �lk etkile�ime ge�ilecek nesne
    public GameObject loadSceneController; // �kinci etkile�ime ge�ilecek nesne
    public Transform spawnLocation; // �kinci nesnenin spawn olaca�� yer

    private bool isCrystalInteracted = false;

    void Start()
    {
        // �kinci nesneyi ba�lang��ta devre d��� b�rak
        if (loadSceneController != null)
        {
            loadSceneController.SetActive(false);
            Debug.Log("LoadSceneController ba�lang��ta devre d��� b�rak�ld�.");
        }
        else
        {
            Debug.LogError("LoadSceneController atanmad�.");
        }

        if (crystal == null)
        {
            Debug.LogError("Crystal atanmad�.");
        }

        if (spawnLocation == null)
        {
            Debug.LogError("SpawnLocation atanmad�.");
        }
    }

    void Update()
    {
        // E�er Crystal ile etkile�ime ge�ildiyse ve F tu�una bas�ld�ysa
        if (isCrystalInteracted && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F tu�una bas�ld� ve Crystal ile etkile�imde.");
            // �kinci nesneyi belirtilen konumda etkinle�tir
            if (loadSceneController != null)
            {
                loadSceneController.SetActive(true);
                loadSceneController.transform.position = spawnLocation.position;
                loadSceneController.transform.rotation = spawnLocation.rotation;
                Debug.Log("LoadSceneController etkinle�tirildi.");
            }
        }
        else if (isCrystalInteracted)
        {
            Debug.Log("Crystal ile etkile�imde ancak F tu�una bas�lmad�.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // E�er Crystal ile �arp���ld�ysa
        if (other.gameObject == crystal)
        {
            Debug.Log("Crystal ile etkile�ime girildi.");
            isCrystalInteracted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // E�er Crystal'den ��k�ld�ysa
        if (other.gameObject == crystal)
        {
            Debug.Log("Crystal ile etkile�imden ��k�ld�.");
            isCrystalInteracted = false;
        }
    }
}
