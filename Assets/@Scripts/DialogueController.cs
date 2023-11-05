using System.Collections;
using System.Collections.Generic;
using DS;
using DS.Data;
using DS.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public DSDialogueContainerSO Container;
    public TextMeshProUGUI TextContainer;
    public GameObject Pref;

    private List<Button> _currentButton;
    public GameObject PrefContainer;
    public TypeWritterUtility Utility;

    public void Start()
    {
        var container = Container.UngroupedDialogues;
        var text = container[0].Text;
        TextContainer.text = text;

        if (container[0].IsStartingDialogue)
        {
            StartCoroutine(StartDialogue());
        }
    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(2f);

        var choises = Container.UngroupedDialogues;
        var text = choises[1].Text;

        TextContainer.text = text;

        for (int i = 0; i < choises[1].Choices.Count; i++)
        {
            var choise = choises[1].Choices[i];
            var choiseText = choise.Text;
            var button = Instantiate(Pref, PrefContainer.transform);

            button.GetComponentInChildren<TextMeshProUGUI>().text = choiseText;
            button.GetComponent<Button>().onClick.AddListener(() =>OnNextDialogue(choise));
        }
    }

    private void OnNextDialogue(DSDialogueChoiceData choise) 
    {
        var container = choise;
        TextContainer.text = container.NextDialogue.Text;
    }
}
