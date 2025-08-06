using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreeManager : MonoBehaviour
{

    public Transform buttonParent;
    public List<Button> buttons = new List<Button>();
    List<TalentButton> listTalentButtons = new List<TalentButton>();
    

    public void Start()
    {
        List<Talent> listTalents = GameSaveManager.LoadTalents();
        buttons.AddRange(buttonParent.GetComponentsInChildren<Button>());

        listTalentButtons = PairButtonsWithTalents(listTalents, buttons, listTalentButtons);
        foreach (var talentButton in listTalentButtons)
        {
            PaintButton(talentButton);
            talentButton.button.onClick.AddListener(() => OnTalentClicked(talentButton, listTalentButtons));
        }
    }

    public void OnTalentClicked(TalentButton talentButton, List<TalentButton> listTalentButtons)
    {
        Boolean enabled = talentButton.talent.enabled;
        Boolean locked = talentButton.talent.locked;
        if (!enabled && !locked)
        {
            talentButton.talent.enabled = true;
        }
        else if (enabled && !locked)
        {
            talentButton.talent.enabled = false;
        }
        PaintButton(talentButton);
        CheckRequirementsTalents(talentButton, listTalentButtons);

    }

    public void CheckRequirementsTalents(TalentButton tbParent, List<TalentButton> listTalentButtons)
    {
        foreach (var talentButton in listTalentButtons)
        {
            if (tbParent.talent.require1 == talentButton.talent.name && tbParent.talent.enabled)
            {
                talentButton.talent.locked = true;
                PaintButton(talentButton);
            }
            else if (talentButton.talent.require1 == tbParent.talent.name && tbParent.talent.enabled)
            {
                talentButton.talent.locked = false;
                PaintButton(talentButton);
            }
            else if (tbParent.talent.require1 == talentButton.talent.name && !tbParent.talent.enabled)
            {
                talentButton.talent.locked = false;
                PaintButton(talentButton);
            }
            else if (talentButton.talent.require1 == tbParent.talent.name && !tbParent.talent.enabled)
            {
                talentButton.talent.locked = true;
                PaintButton(talentButton);
            }
        }
    }


    public void PaintButton(TalentButton talentButton)
    {
        Boolean enabled = talentButton.talent.enabled;
        Boolean locked = talentButton.talent.locked;
        if (enabled && !locked)
        {
            talentButton.button.image.color = Color.green;
            //talentButton.button.interactable = true;
        }
        else if (enabled && locked)
        {
            talentButton.button.image.color = Color.magenta;
            //talentButton.button.interactable = false;
        }
        else if (!enabled && !locked)
        {
            talentButton.button.image.color = Color.white;
            //talentButton.button.interactable = true;
        }
        else if (!enabled && locked)
        {
            talentButton.button.image.color = Color.red;
            //talentButton.button.interactable = false;
        }

    }

    public List<TalentButton> PairButtonsWithTalents(List<Talent> talents, List<Button> buttons, List<TalentButton> listTalentButtons)
    {
        foreach (var talent in talents)
        {
            foreach (var button in buttons)
            {
                if (talent.name == button.name)
                {
                    TalentButton talentButton = new TalentButton(talent, button);
                    listTalentButtons.Add(talentButton);
                }
            }
        }
        return listTalentButtons;
    }

    public void SaveDataToJSON()
    {
        List<Talent> listTalents = new List<Talent>();
        foreach (var tb in listTalentButtons)
        {
            listTalents.Add(tb.talent);
        }
        GameSaveManager.SaveTalents(listTalents);
    }
}