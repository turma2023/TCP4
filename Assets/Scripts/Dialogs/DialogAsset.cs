using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NovoDialogo", menuName = "Dialogo/Dialogo Asset")]
public class DialogAsset : ScriptableObject
{
    public List<DialogoUnidade> dialogos = new List<DialogoUnidade>();
}
