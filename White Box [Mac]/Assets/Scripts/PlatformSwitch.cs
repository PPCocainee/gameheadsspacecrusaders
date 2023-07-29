using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    public MovingPlatform movingPlatform; // 引用移动平台的脚本

    // 在按钮点击事件中调用该方法切换平台的移动状态
    public void TogglePlatformMovement()
    {
        movingPlatform.ToggleMovement(); // 调用移动平台脚本中的 ToggleMovement 方法
    }
}
