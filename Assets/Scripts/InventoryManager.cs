using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject backGroundPanel;

    [SerializeField] private ItemTooltip tooltipReference;

    [Header("���݂̃C���x���g����")]
    public List<InventorySlot> slots = new List<InventorySlot>();

    [Header("�A�C�e���f�[�^�x�[�X�����Ă�")]
    [SerializeField] private ItemDataBase dataBase;


    private void Awake()
    {
        backGroundPanel.SetActive(false);
    }


    /// <summary>
    /// �����_���ɃA�C�e������(�A�C�e���f�[�^�x�[�X�̃e�X�g�p)
    /// </summary>
    public void RandomAddItem()
    {
        if (dataBase == null || dataBase.Items == null || dataBase.Items.Length == 0)
        {
            Debug.LogWarning("ItemDataBase���A�^�b�`����ĂȂ���");
            return;
        }

        int randNum = Random.Range(0, dataBase.Items.Length);
        ItemData randItem = dataBase.Items[randNum];

        int randAmount = Random.Range(1, 6);

        AddItem(randItem, randAmount);
    }


    /// <summary>
    /// �A�C�e�����C���x���g���ɒǉ�
    /// </summary>
    public void AddItem(ItemData itemToAdd, int amount = 1)
    {
        //�X�^�b�N���\�ȏꍇ�́A�X�^�b�N����
        if (itemToAdd.isStackable)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == itemToAdd && slot.count < itemToAdd.MaxStack)
                {
                    int spaceLeft = itemToAdd.MaxStack - slot.count;
                    int toAdd = Mathf.Min(spaceLeft, amount);
                    slot.count += toAdd;
                    amount -= toAdd;
                    slot.UpdateSlotDisplay();

                    if (amount <= 0) return;
                }
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = itemToAdd;
                slot.count = Mathf.Min(amount, itemToAdd.MaxStack);
                amount -= slot.count;
                slot.UpdateSlotDisplay();
                Debug.Log("��X���b�g�ɒǉ�");

                ItemFrameController frameCtrl = slot.GetComponentInChildren<ItemFrameController>(true);
                if (frameCtrl != null)
                {
                    frameCtrl.SetItemData(itemToAdd);
                    Debug.Log($"[DEBUG] {slot.name} �� {itemToAdd.itemName} ��ݒ肵�܂���");
                }
                else
                {
                    Debug.LogWarning($"[DEBUG] {slot.name} �� ItemFrameController ��������Ȃ�");
                }

                if (amount <= 0) return;
            }
        }

        if (amount > 0)
        {
            Debug.Log("�C���x���g���������ς�����");
        }

    }

    [Header("�t���[���֘A")]
    [Tooltip("�t���[���v���n�u�����Ă�")]
    [SerializeField] private GameObject itemFrame;
    [Tooltip("�t���[���̐�����͂��Ă�")]
    [SerializeField] int frameNumX;
    [SerializeField] int frameNumY;
    [Tooltip("�t���[���Ԃ̕�")]
    [SerializeField] float space;

    private void Start()
    {
        GenerateFrames();
    }

    /// <summary>
    /// �A�C�e���̘g�𓙊Ԋu�ɐ�������X�N���v�g
    /// </summary>
    public void GenerateFrames()
    {
        //�eUI��RectTransform���擾
        RectTransform parentRect = GetComponent<RectTransform>();
        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;

        //�v���n�u�̕����擾
        RectTransform prefabRect = itemFrame.GetComponent<RectTransform>();
        float frameWidth = prefabRect.rect.width;
        float frameHeight = prefabRect.rect.height;

        //�eUI�Ɛ�������I�u�W�F�N�g�̕����Z�o
        float totalWidth = (frameWidth * frameNumX) + (space * (frameNumX - 1));
        float totalHeight = (frameHeight * frameNumY) + (space * (frameNumY - 1));

        //�ŏ��̐�������I�u�W�F�N�g��x���W
        float startX = -(totalWidth / 2f) + (frameWidth / 2f);
        float startY = (totalHeight / 2f) - (frameHeight / 2f);


        for (int y = 0; y < frameNumY; y++)
        {
            for (int x = 0; x < frameNumX; x++)
            {
                //�v���n�u���q�I�u�W�F�N�g�Ƃ��Ĕz�u����
                GameObject frame = Instantiate(itemFrame, transform);

                ItemFrameController frameController = frame.GetComponent<ItemFrameController>();
                if(frameController != null)
                {
                    frameController.SetTooltip(tooltipReference);
                }

                //�t���[����RectTransform���擾
                RectTransform rt = frame.GetComponent<RectTransform>();

                //�v�Z�����ʒu�ɔz�u
                float xPos = startX + x * (frameWidth + space);
                float yPos = startY - y * (frameHeight + space);
                rt.anchoredPosition = new Vector2(xPos, yPos);

                //�X���b�g�̏����擾
                InventorySlot slot = frame.GetComponent<InventorySlot>();
                if (slot != null)
                {
                    slots.Add(slot);
                }
                else
                {
                    Debug.LogWarning("InventorySlot���A�^�b�`����Ă��Ȃ���");
                }

            }

        }
    }

}
