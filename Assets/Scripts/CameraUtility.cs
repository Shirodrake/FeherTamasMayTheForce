using UnityEngine;

static class CameraUtility 
{
    public static Rect GetOrtographicRect(Camera camera)
    {
        float sizeY = camera.orthographicSize * 2;
        float sizeX = sizeY * camera.aspect;
        Vector2 size = new(sizeX, sizeY);

        Vector2 center = camera.transform.position;
        Vector2 position = new(center.x - sizeX / 2, center.y - sizeY / 2);

        return new Rect(position, size);
    }
}