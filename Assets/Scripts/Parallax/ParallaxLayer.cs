using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ÊÓ²î²ã
/// </summary>
[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform background; // ±³¾°
    [SerializeField] private float parallaxMultiplier; // ÅÜ¶¯ÏµÊý
    [SerializeField] private float imageWidthOffset = 10; // Í¼Æ¬¿í¶ÈÆ«ÒÆÁ¿

    private float imageFullWidth; // Í¼Æ¬×Ü¿í
    private float imageHalfWidth; // Í¼Æ¬×Ü¿íÒ»°ë
    /// <summary>
    /// ¼ÆËãÍ¼Æ¬¾«Áé¿í¶È
    /// </summary>
    public void CalculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidth = imageFullWidth / 2;
    }
    /// <summary>
    /// Í¼Æ¬ÒÆ¶¯
    /// </summary>
    public void Move(float distanceToMove)
    {
        background.position += Vector3.right * (distanceToMove * parallaxMultiplier);
    }
    /// <summary>
    /// ±³¾°ÎÞÏÞÑ­»·
    /// </summary>
    /// <param name="cameraLeftEdge">ÉãÏñ»ú×ó±ß½ç</param>
    /// <param name="cameraRightEdge">ÉãÏñ»úÓÒ±ß½ç</param>
    public void LoopBackground(float cameraLeftEdge, float cameraRightEdge)
    {
        float imageRightEdge = (background.position.x + imageHalfWidth) - imageWidthOffset; // Í¼Æ¬ÓÒ±ß½ç
        float imageLeftEdge = (background.position.x - imageHalfWidth) + imageWidthOffset;  // Í¼Æ¬×ó±ß½ç

        if (imageRightEdge < cameraLeftEdge)
            background.position += Vector3.right * imageFullWidth;
        else if (imageLeftEdge > cameraRightEdge)
            background.position += Vector3.right * -imageFullWidth;
    }
}
