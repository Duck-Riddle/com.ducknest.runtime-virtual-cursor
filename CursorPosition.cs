#nullable enable
using System;
using DuckNest.Core.Common;
using UnityEngine;

namespace DuckNest.RuntimeVirtualCursor
{
    [Serializable]
    public class CursorPosition : ICursorPosition
    {
        ISpatialPosition spatialData;
        [SerializeField] Camera viewCamera;
        
        public Vector3 WorldPosition
        {
            get => spatialData.Position;
            private set => spatialData.Position = value;
        }
        
        public Vector3 ScreenPosition
        {
            get => viewCamera.WorldToScreenPoint(spatialData.Position);
            set => viewCamera.ScreenToWorldPoint(value);
        }

        public CursorPosition(ISpatialPosition spatialData, Camera viewCamera)
        {
            this.spatialData = spatialData;
            this.viewCamera = viewCamera;
        }
    }
    
    public interface ICursorPosition
    {
        Vector3 WorldPosition { get; }
        Vector3 ScreenPosition { get; set; }
    }
}