using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DialogueText;

    public Animator Animator;

    private Queue<string> _sentences = new Queue<string>();

    void Start()
    {
        
    }

    public void StartDialog(Dialogue dialogue)
    {
        Animator.SetBool("IsOpen", true);

        TitleText.text = dialogue.Name;

        _sentences.Clear();

        foreach(var sentence in dialogue.Sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if(!_sentences.Any())
        {
            EndDialogue();

            return;
        }

        var sentence = _sentences.Dequeue();
        DialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        Animator.SetBool("IsOpen", false);
    }
}
