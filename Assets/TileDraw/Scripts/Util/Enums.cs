﻿using System;

namespace TileDraw
{
    [Flags]
    public enum Neighbour
    {
        None = 0,
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        LeftTop = Left | Top,
        RightTop = Right | Top,
        LeftBottom = Left | Bottom,
        RightBottom = Right | Bottom
    }
}
