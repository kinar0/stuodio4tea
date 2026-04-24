using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Obj")]
    public GameObject Level2Obj;
    
    [Header("Hands")]
    public GameObject leftHand;
    public GameObject rightHand;

    [Header("Spawn Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Debug")]
    public float debugLevelSwitchTime = 10f;

    private float timer = 0f;
    private bool level2Started = false;

    void Start()
    {
        // 游戏开始时，把玩家放到A点
        MovePlayerTo(pointA);
        Level2Obj.SetActive(false); // 第二关的物体初始时隐藏  
        leftHand.SetActive(false); // 显示左手
        rightHand.SetActive(false); // 显示右手
    }

    void Update()
    {
        // 调试用：计时10秒后进入第二关
        if (!level2Started)
        {
            timer += Time.deltaTime;

            if (timer >= debugLevelSwitchTime)
            {
                EnterLevel2();
            }
        }
    }

    /// <summary>
    /// 进入第二关（以后可以被真正的通关条件调用）
    /// </summary>
    public void EnterLevel2()
    {
        if (level2Started) return;

        level2Started = true;

        Debug.Log("进入第二关");

        MovePlayerTo(pointB);

        Level2Obj.SetActive(true); // 激活第二关的物体
        leftHand.SetActive(true); // 显示左手
        rightHand.SetActive(true); // 显示右手
        leftHand.GetComponent<MeshRenderer>().enabled = false; // 确保左手可见
        rightHand.GetComponent<MeshRenderer>().enabled = false; // 确保右手可见

        // 👉 这里可以扩展：
        // - 切换UI
        // - 激活/禁用关卡物体
        // - 播放过场动画
    }

    /// <summary>
    /// 移动玩家到指定点
    /// </summary>
    void MovePlayerTo(Transform targetPoint)
    {
        player.transform.position = targetPoint.position;

        // 如果你有旋转需求：
        player.transform.rotation = targetPoint.rotation;
    }
}