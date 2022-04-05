using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformManager : OrdonedMonoBehaviour
{
    public FloatVariable MapLength;
    public FloatVariable MapHeight;

    public FloatVariable LengthZoomFactor;
    public FloatVariable HeightZoomFactor;
    public FloatVariable MinZoom;
    public FloatVariable ZoomMargin;
    public FloatVariable AdaptationTime;

    public PlayerPositions PlayerPositions;

    private int MaxX;
    private int MinX;
    private int MaxY;
    private int MinY;

    private Vector2 CenterPos;
    private Vector2 CenterPosAtLastWait;

    private float CameraZTarget;
    private float CameraZTargetAtLastWait;
    private float InitialCameraZTarget;

    private float LastWaitTime;

    public override void DoAwake()
    {

    }

    public override void DoUpdate()
    {
        if (!AdaptationTime) return;
        float TimeSinceLastWait = Time.time - LastWaitTime;
        if (TimeSinceLastWait < AdaptationTime.Value)
        {
            float TimeFactor = (1 - TimeSinceLastWait / AdaptationTime.Value);
            Vector2 CameraXY = CenterPos + TimeFactor * (CenterPosAtLastWait - CenterPos);
            float CameraZ = CameraZTarget + TimeFactor * (CameraZTargetAtLastWait - CameraZTarget);
            transform.position = new Vector3(CameraXY.x, CameraXY.y, CameraZ);
        }
    }

    public void OnMapConfigurated()
    {
        if (!MapLength || !MapHeight || !LengthZoomFactor || !HeightZoomFactor) return;
        float CameraX = MapLength.Value % 2 == 0 ? -0.5f : 0f;
        float CameraY = MapHeight.Value % 2 == 0 ? -0.5f : 0f;
        InitialCameraZTarget = Mathf.Min(-(MapLength.Value + 2) * LengthZoomFactor.Value, -(MapHeight.Value + 2) * HeightZoomFactor.Value);
        transform.position = new Vector3(CameraX, CameraY, InitialCameraZTarget);
        LastWaitTime = -1;
    }

    public void OnWaitActionState()
    {
        CenterPosAtLastWait = CenterPos;
        CameraZTargetAtLastWait = CameraZTarget;
        CalcCoordonates();
        CalcZTarget();
        LastWaitTime = Time.time;
    }

    public void CalcCoordonates()
    {
        MaxX = PlayerPositions.GetPosition(0).x;
        MinX = PlayerPositions.GetPosition(0).x;
        MaxY = PlayerPositions.GetPosition(0).y;
        MinY = PlayerPositions.GetPosition(0).y;
        for (int i = 0; i < PlayerPositions.GetPlayerCount(); i++)
        {
            if (PlayerPositions.GetPosition(i).x < MinX) { MinX = PlayerPositions.GetPosition(i).x; }
            if (PlayerPositions.GetPosition(i).x > MaxX) { MaxX = PlayerPositions.GetPosition(i).x; }
            if (PlayerPositions.GetPosition(i).y < MinY) { MinY = PlayerPositions.GetPosition(i).y; }
            if (PlayerPositions.GetPosition(i).y > MaxY) { MaxY = PlayerPositions.GetPosition(i).y; }
        }
        CenterPos = new Vector2(((float)(MinX + MaxX))/2, ((float)(MinY + MaxY))/2);
    }

    public void CalcZTarget()
    {
        CameraZTarget = Mathf.Max(InitialCameraZTarget, Mathf.Min(-((float)(MaxX - MinX + 1) + ZoomMargin.Value) * LengthZoomFactor.Value, -((float)(MaxY - MinY + 1) + ZoomMargin.Value) * HeightZoomFactor.Value, -MinZoom.Value * HeightZoomFactor.Value));
    }
}
