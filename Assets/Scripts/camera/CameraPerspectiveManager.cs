using DG.Tweening;
using UnityEngine;

public class CameraPerspectiveManager : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Quaternion latestOrietation;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) RotateLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow)) RotateRight();
        if (Input.GetKeyDown(KeyCode.R)) ResetPerspective();
    }

    public void RotateLeft()
    {
        latestOrietation = rigidbody.rotation * Quaternion.Euler(0, -90, 0);
        transform.DORotate(latestOrietation.eulerAngles, 0.3f).SetEase(Ease.OutSine);
    }

    public void RotateRight()
    {
        latestOrietation = rigidbody.rotation * Quaternion.Euler(0, 90, 0);
        transform.DORotate(latestOrietation.eulerAngles, 0.3f).SetEase(Ease.OutSine);
    }

    public void RotateUp()
    {

    }

    public void RotateDown()
    {

    }

    public void ResetPerspective()
    {
        gameObject.transform.DOMove(new Vector3(0, 1.4f, 0), 0.6f).SetEase(Ease.OutSine);
        gameObject.transform.DORotate(latestOrietation.eulerAngles, 0.6f).SetEase(Ease.OutSine);
    }
}
