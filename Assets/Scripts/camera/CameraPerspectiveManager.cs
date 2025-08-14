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
        if (!moveToObject.CanMove) return;
        moveToObject.CanMove = false;
        latestOrietation = rigidbody.rotation * Quaternion.Euler(0, -90, 0);
        transform.DORotate(latestOrietation.eulerAngles, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            moveToObject.CanMove = true;
        }); ;
    }

    public void RotateRight()
    {
        if (!moveToObject.CanMove) return;
        moveToObject.CanMove = false;
        latestOrietation = rigidbody.rotation * Quaternion.Euler(0, 90, 0);
        transform.DORotate(latestOrietation.eulerAngles, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            moveToObject.CanMove = true;
        }); ;
    }

    public void RotateUp()
    {

    }

    public void RotateDown()
    {

    }

    public void ResetPerspective()
    {
        gameObject.transform.DOMove(new Vector3(-5.50004597e-10f, 1.5f, -7.07805157e-08f), 0.6f).SetEase(Ease.OutSine);
        gameObject.transform.DORotate(latestOrietation.eulerAngles, 0.6f).SetEase(Ease.OutSine).OnComplete(()=>
        {
            moveToObject.CanMove = true;
        });
    }

    public void ResetPerspectiveInstantly()
    {
        gameObject.transform.DOMove(new Vector3(-5.50004597e-10f, 1.5f, -7.07805157e-08f), 0f).SetEase(Ease.OutSine);
        gameObject.transform.DORotate(latestOrietation.eulerAngles, 0f).SetEase(Ease.OutSine);
        
    }
}
