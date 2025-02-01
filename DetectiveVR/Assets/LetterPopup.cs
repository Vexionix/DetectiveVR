using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class MultiPhasePopup : MonoBehaviour
{
    [Header("UI References")]
    public GameObject popupPanel;
    public Text popupText;

    [Header("Phases")]
    public string[] phaseTexts = { "Catalin era student in anul doi de facultate cand fratele sau a disparut fara urma. Initial, a incercat sa colaboreze cu autoritatile, dar a realizat rapid ca acestea nu trateaza cazul cu seriozitate. Dezamagit si hotarat sa nu renunte, si-a schimbat complet directia profesionala, devenind detectiv particular. In urmatorii sapte ani, si-a perfectionat abilitatile de investigatie, rezolvand numeroase cazuri, dar niciodata fara a cauta indicii despre fratele sau.",
        "Intr-o zi, printre facturile obisnuite din cutia postala, Catalin descopera o scrisoare ciudata, patata de sange si semnata cu initiale necunoscute. La deschiderea ei, gaseste numele fratelui sau si mesaje criptice. Initial, suspecteaza o gluma proasta sau o amenintare legata de un caz recent in care ajutase la prinderea unui membru al mafiei. Cateva zile mai tarziu, cineva ii sparge geamul biroului aruncand o caramida de care era atasata o noua scrisoare—de data aceasta cu o adresa.",
        "Adresa il conduce la o padure aflata la 230 km distanta, iar cercetand harta, Catalin isi aminteste ca locul respectiv are o semnificatie speciala: este casa unde fusese candva intr-o vacanta cu tatal sau, decedat de zece ani. Dar cine ar putea sti aceste detalii? Misterul devine din ce in ce mai profund. Constient de pericol, dar hotarat sa-si continue misiunea, decide sa mearga la locul indicat, sperand ca acolo va gasi raspunsurile pe care le cauta de atatia ani.",
        "Obiectivul jocului: Catalin trebuie sa gaseasca cele doua chei care vor deschide usa catre camere ce contine raspunsurile de care are nevoie. Jcatorul poate gasi 3 hint-uri care sa-l indrume spre cele doua chei. Glhf! :)" };

    private int currentPhase = 0;

    void Start()
    {
        currentPhase = 0;
        popupText.text = phaseTexts[currentPhase];

        popupPanel.SetActive(true);
    }

    void Update()
    {
        if (popupPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentPhase++;
                if (currentPhase < phaseTexts.Length)
                {
                    popupText.text = phaseTexts[currentPhase];
                }
                else
                {
                    ClosePopup();
                }
            }
        }
    }

    private void ClosePopup()
    {

        popupPanel.SetActive(false);
        currentPhase = 0;
    }
}