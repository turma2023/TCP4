using DG.Tweening;
using UnityEngine;

public class CameraPerspectiveManager : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Quaternion latestOrietation;
    private MoveToObject moveToObject;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moveToObject = GetComponent<MoveToObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) RotateLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow)) RotateRight();
        if (Input.GetKeyDown(KeyCode.R)) ResetPerspective();
    }

    public void RotateLeft()
    {
        moveToObject.CanMove = false;
        latestOrietation = rigidbody.rotation * Quaternion.Euler(0, -90, 0);
        transform.DORotate(latestOrietation.eulerAngles, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            moveToObject.CanMove = true;
            ResetPerspectiveInstantly();
        });
    }

    public void RotateRight()
    {
        moveToObject.CanMove = false;
        latestOrietation = rigidbody.rotation * Quaternion.Euler(0, 90, 0);
        transform.DORotate(latestOrietation.eulerAngles, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            moveToObject.CanMove = true;
            ResetPerspectiveInstantly();
        });
    }

    public void RotateUp()
    {

    }

    public void RotateDown()
    {

    }

    public void ResetPerspective()
    {
        moveToObject.CanMove = false;
        gameObject.transform.DOMove(new Vector3(-3.03611159e-07f, 1.50000012f, -6.19663538e-08f), 0.6f).SetEase(Ease.OutSine);
        gameObject.transform.DORotate(latestOrietation.eulerAngles, 0.6f).SetEase(Ease.OutSine).OnComplete(() => moveToObject.CanMove = true);
    }
    public void ResetPerspectiveInstantly()
    {
        gameObject.transform.DOMove(new Vector3(-3.03611159e-07f, 1.50000012f, -6.19663538e-08f), 0f).SetEase(Ease.OutSine);
        gameObject.transform.DORotate(latestOrietation.eulerAngles, 0f).SetEase(Ease.OutSine);
    }
}
