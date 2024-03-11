using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject windowDialog;
    public TextMeshProUGUI textDialog;
    public Button button;

    public string[] message;
    private int numberDialog = 0;
    private bool IsChatting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsChatting)
        {
            return;
        }

        IsChatting = true;

        Debug.Log("123");
        if (collision.tag == "Player")
        {
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
        button.onClick.RemoveAllListeners();
        numberDialog = 0;
        IsChatting = false;
    }
    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
        }
    }
}
