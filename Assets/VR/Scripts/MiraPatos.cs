using System;
using UnityEngine;

public class MiraPatos : MonoBehaviour
{
    [SerializeField] private RectTransform miraUI;
    [SerializeField] private Transform mira;

    private void Update()
    {
        float miraUIX = (miraUI.localPosition.x/ (1920/2)) * 9;
        float miraUIY = (miraUI.localPosition.y / (1080/2)) * 5;
        //Debug.Log(miraUIX);
        Vector3 nuevaPos = new Vector3(miraUIX, miraUIY, mira.position.z);
        mira.position = nuevaPos;
    }
}
