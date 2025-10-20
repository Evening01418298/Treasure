using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �X�N���v�^�u���I�u�W�F�N�g�̃A�C�e�����
/// </summary> 

[CreateAssetMenu(fileName ="CreateItemData",menuName ="CreateNewItem/Item Data",order =0)]
public class ItemData : ScriptableObject
{
    [Header("��{���")]
    [Space(10)]
    [Tooltip("�A�C�e���̖��O")]
    public string itemName;

    [Tooltip("�A�C�e���̃C���[�W�摜")]
    public Sprite itemImage;

    [Tooltip("�A�C�e���̃��A���e�B")]
    public Quality itemQuality;

    [Tooltip("�A�C�e���̊�b�l�i")]
    public int BasicPrice;
    [HideInInspector]
    public int price;           //���ꂪ���ۂ̃A�C�e���̒l�i(��b�l�ix�i���ŋ��߂����)

    [Tooltip("�A�C�e���̎��")]
    public ObjType type;

    [Tooltip("�A�C�e���̍ő�X�^�b�N��")]
    public int MaxStack;

    //�X�^�b�N�o����ꍇ��1�ȏ�
    public bool isStackable => MaxStack > 1;


    public int Price()
    {
        float multiplier = 1f;

        switch (itemQuality)
        {
            case Quality.Inferior:
                multiplier = 1.0f;
                break;

            case Quality.Damaged:
                multiplier = 1.5f;
                break;

            case Quality.Normal:
                multiplier = 2.0f;
                break;

            case Quality.Perfect:
                multiplier = 3.0f;
                break;
        }

        return Mathf.RoundToInt(BasicPrice * multiplier);
    }

}


public enum ObjType
{ 
    States,             //�|�[�V�������ѓ��ɐU�蕪����\��
    Valuables,          //�M�d�i�B��Γ��ɐU�蕪����\��
    Weapons,            //����
}

public enum Quality
{
    Perfect,        //����
    Normal,         //����
    Damaged,        //����
    Inferior,       //�e���i
}