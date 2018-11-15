using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodImage : RawImage
{
    private Slider _BloodSlider;
    protected override void OnRectTransformDimensionsChange()
    {
        if (_BloodSlider == null)
            _BloodSlider = transform.parent.parent.GetComponent<Slider>();

        //获取血条的值
        if (_BloodSlider != null)
        {
            //刷新血条的显示
            float value = _BloodSlider.value;
            uvRect = new Rect(0, 0, value, 1);
        }
    }
}
