// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Imaging
{
    /*
     * EmfPlusRecordType constants
     */

    /// <summary>
    ///    
    ///       Specifies the methods available in a metafile to read and write graphic
    ///       commands.
    ///    
    /// </summary>    
    public enum EmfPlusRecordType
    {
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfRecordBase = 0x00010000,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetBkColor = WmfRecordBase | 0x201,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetBkMode = WmfRecordBase | 0x102,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetMapMode = WmfRecordBase | 0x103,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetROP2 = WmfRecordBase | 0x104,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetRelAbs = WmfRecordBase | 0x105,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetPolyFillMode = WmfRecordBase | 0x106,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetStretchBltMode = WmfRecordBase | 0x107,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetTextCharExtra = WmfRecordBase | 0x108,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetTextColor = WmfRecordBase | 0x209,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetTextJustification = WmfRecordBase | 0x20A,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetWindowOrg = WmfRecordBase | 0x20B,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetWindowExt = WmfRecordBase | 0x20C,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetViewportOrg = WmfRecordBase | 0x20D,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetViewportExt = WmfRecordBase | 0x20E,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfOffsetWindowOrg = WmfRecordBase | 0x20F,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfScaleWindowExt = WmfRecordBase | 0x410,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfOffsetViewportOrg = WmfRecordBase | 0x211,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfScaleViewportExt = WmfRecordBase | 0x412,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfLineTo = WmfRecordBase | 0x213,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfMoveTo = WmfRecordBase | 0x214,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfExcludeClipRect = WmfRecordBase | 0x415,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfIntersectClipRect = WmfRecordBase | 0x416,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfArc = WmfRecordBase | 0x817,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfEllipse = WmfRecordBase | 0x418,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfFloodFill = WmfRecordBase | 0x419,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfPie = WmfRecordBase | 0x81A,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfRectangle = WmfRecordBase | 0x41B,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfRoundRect = WmfRecordBase | 0x61C,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfPatBlt = WmfRecordBase | 0x61D,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSaveDC = WmfRecordBase | 0x01E,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetPixel = WmfRecordBase | 0x41F,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfOffsetCilpRgn = WmfRecordBase | 0x220,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfTextOut = WmfRecordBase | 0x521,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfBitBlt = WmfRecordBase | 0x922,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfStretchBlt = WmfRecordBase | 0xB23,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfPolygon = WmfRecordBase | 0x324,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfPolyline = WmfRecordBase | 0x325,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfEscape = WmfRecordBase | 0x626,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfRestoreDC = WmfRecordBase | 0x127,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfFillRegion = WmfRecordBase | 0x228,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfFrameRegion = WmfRecordBase | 0x429,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfInvertRegion = WmfRecordBase | 0x12A,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfPaintRegion = WmfRecordBase | 0x12B,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSelectClipRegion = WmfRecordBase | 0x12C,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSelectObject = WmfRecordBase | 0x12D,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetTextAlign = WmfRecordBase | 0x12E,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfChord = WmfRecordBase | 0x830,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetMapperFlags = WmfRecordBase | 0x231,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfExtTextOut = WmfRecordBase | 0xA32,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetDibToDev = WmfRecordBase | 0xD33,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSelectPalette = WmfRecordBase | 0x234,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfRealizePalette = WmfRecordBase | 0x035,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfAnimatePalette = WmfRecordBase | 0x436,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetPalEntries = WmfRecordBase | 0x037,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfPolyPolygon = WmfRecordBase | 0x538,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfResizePalette = WmfRecordBase | 0x139,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfDibBitBlt = WmfRecordBase | 0x940,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfDibStretchBlt = WmfRecordBase | 0xb41,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfDibCreatePatternBrush = WmfRecordBase | 0x142,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfStretchDib = WmfRecordBase | 0xf43,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfExtFloodFill = WmfRecordBase | 0x548,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfSetLayout = WmfRecordBase | 0x149, // META_SETLAYOUT
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfDeleteObject = WmfRecordBase | 0x1f0,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfCreatePalette = WmfRecordBase | 0x0f7,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfCreatePatternBrush = WmfRecordBase | 0x1f9,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfCreatePenIndirect = WmfRecordBase | 0x2fa,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfCreateFontIndirect = WmfRecordBase | 0x2fb,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfCreateBrushIndirect = WmfRecordBase | 0x2fc,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        WmfCreateRegion = WmfRecordBase | 0x6ff,

        // Since we have to enumerate GDI records right along with GDI+ records,
        // we list all the GDI records here so that they can be part of the
        // same enumeration type which is used in the enumeration callback.

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfHeader = 1,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyBezier = 2,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolygon = 3,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyline = 4,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyBezierTo = 5,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyLineTo = 6,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyPolyline = 7,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyPolygon = 8,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetWindowExtEx = 9,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetWindowOrgEx = 10,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetViewportExtEx = 11,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetViewportOrgEx = 12,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetBrushOrgEx = 13,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfEof = 14,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetPixelV = 15,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetMapperFlags = 16,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetMapMode = 17,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetBkMode = 18,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetPolyFillMode = 19,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetROP2 = 20,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetStretchBltMode = 21,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetTextAlign = 22,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetColorAdjustment = 23,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetTextColor = 24,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetBkColor = 25,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfOffsetClipRgn = 26,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfMoveToEx = 27,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetMetaRgn = 28,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExcludeClipRect = 29,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfIntersectClipRect = 30,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfScaleViewportExtEx = 31,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfScaleWindowExtEx = 32,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSaveDC = 33,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfRestoreDC = 34,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetWorldTransform = 35,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfModifyWorldTransform = 36,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSelectObject = 37,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreatePen = 38,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreateBrushIndirect = 39,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfDeleteObject = 40,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfAngleArc = 41,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfEllipse = 42,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfRectangle = 43,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfRoundRect = 44,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfRoundArc = 45,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfChord = 46,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPie = 47,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSelectPalette = 48,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreatePalette = 49,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetPaletteEntries = 50,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfResizePalette = 51,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfRealizePalette = 52,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtFloodFill = 53,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfLineTo = 54,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfArcTo = 55,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyDraw = 56,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetArcDirection = 57,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetMiterLimit = 58,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfBeginPath = 59,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfEndPath = 60,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCloseFigure = 61,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfFillPath = 62,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfStrokeAndFillPath = 63,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfStrokePath = 64,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfFlattenPath = 65,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfWidenPath = 66,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSelectClipPath = 67,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfAbortPath = 68,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfReserved069 = 69,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfGdiComment = 70,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfFillRgn = 71,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfFrameRgn = 72,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfInvertRgn = 73,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPaintRgn = 74,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtSelectClipRgn = 75,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfBitBlt = 76,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfStretchBlt = 77,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfMaskBlt = 78,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPlgBlt = 79,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetDIBitsToDevice = 80,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfStretchDIBits = 81,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtCreateFontIndirect = 82,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtTextOutA = 83,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtTextOutW = 84,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyBezier16 = 85,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolygon16 = 86,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyline16 = 87,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyBezierTo16 = 88,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolylineTo16 = 89,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyPolyline16 = 90,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyPolygon16 = 91,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyDraw16 = 92,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreateMonoBrush = 93,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreateDibPatternBrushPt = 94,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtCreatePen = 95,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyTextOutA = 96,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPolyTextOutW = 97,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetIcmMode = 98,  // EMR_SETICMMODE,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreateColorSpace = 99,  // EMR_CREATECOLORSPACE,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetColorSpace = 100, // EMR_SETCOLORSPACE,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfDeleteColorSpace = 101, // EMR_DELETECOLORSPACE,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfGlsRecord = 102, // EMR_GLSRECORD,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfGlsBoundedRecord = 103, // EMR_GLSBOUNDEDRECORD,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPixelFormat = 104, // EMR_PIXELFORMAT,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfDrawEscape = 105, // EMR_RESERVED_105,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfExtEscape = 106, // EMR_RESERVED_106,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfStartDoc = 107, // EMR_RESERVED_107,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSmallTextOut = 108, // EMR_RESERVED_108,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfForceUfiMapping = 109, // EMR_RESERVED_109,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfNamedEscpae = 110, // EMR_RESERVED_110,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfColorCorrectPalette = 111, // EMR_COLORCORRECTPALETTE,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetIcmProfileA = 112, // EMR_SETICMPROFILEA,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetIcmProfileW = 113, // EMR_SETICMPROFILEW,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfAlphaBlend = 114, // EMR_ALPHABLEND,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetLayout = 115, // EMR_SETLAYOUT,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfTransparentBlt = 116, // EMR_TRANSPARENTBLT,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfReserved117 = 117,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfGradientFill = 118, // EMR_GRADIENTFILL,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetLinkedUfis = 119, // EMR_RESERVED_119,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfSetTextJustification = 120, // EMR_RESERVED_120,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfColorMatchToTargetW = 121, // EMR_COLORMATCHTOTARGETW,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfCreateColorSpaceW = 122, // EMR_CREATECOLORSPACEW,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfMax = 122,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfMin = 1,

        // That is the END of the GDI EMF records.

        // Now we start the list of EMF+ records.  We leave quite
        // a bit of room here for the addition of any new GDI
        // records that may be added later.

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EmfPlusRecordBase = 0x00004000,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Invalid = EmfPlusRecordBase,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Header,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EndOfFile,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Comment,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        GetDC,    // the application grabbed the metafile dc

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        MultiFormatStart,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        MultiFormatSection,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        MultiFormatEnd,

        // For all Persistent Objects
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Object,
        // Drawing Records
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Clear,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillRects,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawRects,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillPolygon,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawLines,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillEllipse,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawEllipse,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillPie,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawPie,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawArc,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillRegion,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillPath,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawPath,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        FillClosedCurve,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawClosedCurve,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawCurve,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawBeziers,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawImage,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawImagePoints,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawString,

        // Graphics State Records
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetRenderingOrigin,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetAntiAliasMode,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetTextRenderingHint,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetTextContrast,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetInterpolationMode,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetPixelOffsetMode,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetCompositingMode,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetCompositingQuality,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Save,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Restore,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        BeginContainer,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        BeginContainerNoParams,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        EndContainer,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetWorldTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        ResetWorldTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        MultiplyWorldTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        TranslateWorldTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        ScaleWorldTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        RotateWorldTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetPageTransform,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        ResetClip,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetClipRect,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetClipPath,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        SetClipRegion,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        OffsetClip,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        DrawDriverString,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Total,

        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Max = Total - 1,
        /// <summary>
        ///    [To be supplied.]
        /// </summary>
        Min = Header
    }
}
