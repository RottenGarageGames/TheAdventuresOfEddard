using UnityEngine;

public class PlayerWheel : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
