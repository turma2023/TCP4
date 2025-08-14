using UnityEngine;

[System.Serializable]
public class DialogoUnidade
{
    public Sprite imagemFundoTexto;
    public Sprite imagemPersonagem;
    [TextArea(3, 10)] 
    public string texto;
}
