//
// EmfPlusRecordType class unit tests
//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Drawing.Imaging;
using System.Security.Permissions;
using Xunit;

namespace MonoTests.System.Drawing.Imaging {

	[TestFixture]
	public class EmfPlusRecordTypeTest {

		[Fact]
		public void EmfRecords ()
		{
			Assert.Equal (1, (int)EmfPlusRecordType.EmfMin, "EmfMin");
			Assert.Equal (1, (int)EmfPlusRecordType.EmfHeader, "EmfHeader");
			Assert.Equal (2, (int)EmfPlusRecordType.EmfPolyBezier, "EmfPolyBezier");
			Assert.Equal (3, (int)EmfPlusRecordType.EmfPolygon, "EmfPolygon");
			Assert.Equal (4, (int)EmfPlusRecordType.EmfPolyline, "EmfPolyline");
			Assert.Equal (5, (int)EmfPlusRecordType.EmfPolyBezierTo, "EmfPolyBezierTo");
			Assert.Equal (6, (int)EmfPlusRecordType.EmfPolyLineTo, "EmfPolyLineTo");
			Assert.Equal (7, (int)EmfPlusRecordType.EmfPolyPolyline, "EmfPolyPolyline");
			Assert.Equal (8, (int)EmfPlusRecordType.EmfPolyPolygon, "EmfPolyPolygon");
			Assert.Equal (9, (int)EmfPlusRecordType.EmfSetWindowExtEx, "EmfSetWindowExtEx");
			Assert.Equal (10, (int)EmfPlusRecordType.EmfSetWindowOrgEx, "EmfSetWindowOrgEx");
			Assert.Equal (11, (int)EmfPlusRecordType.EmfSetViewportExtEx, "EmfSetViewportExtEx");
			Assert.Equal (12, (int)EmfPlusRecordType.EmfSetViewportOrgEx, "EmfSetViewportOrgEx");
			Assert.Equal (13, (int)EmfPlusRecordType.EmfSetBrushOrgEx, "EmfSetBrushOrgEx");
			Assert.Equal (14, (int)EmfPlusRecordType.EmfEof, "EmfEof");
			Assert.Equal (15, (int)EmfPlusRecordType.EmfSetPixelV, "EmfSetPixelV");
			Assert.Equal (16, (int)EmfPlusRecordType.EmfSetMapperFlags, "EmfSetMapperFlags");
			Assert.Equal (17, (int)EmfPlusRecordType.EmfSetMapMode, "EmfSetMapMode");
			Assert.Equal (18, (int)EmfPlusRecordType.EmfSetBkMode, "EmfSetBkMode");
			Assert.Equal (19, (int)EmfPlusRecordType.EmfSetPolyFillMode, "EmfSetPolyFillMode");
			Assert.Equal (20, (int)EmfPlusRecordType.EmfSetROP2, "EmfSetROP2");
			Assert.Equal (21, (int)EmfPlusRecordType.EmfSetStretchBltMode, "EmfSetStretchBltMode");
			Assert.Equal (22, (int)EmfPlusRecordType.EmfSetTextAlign, "EmfSetTextAlign");
			Assert.Equal (23, (int)EmfPlusRecordType.EmfSetColorAdjustment, "EmfSetColorAdjustment");
			Assert.Equal (24, (int)EmfPlusRecordType.EmfSetTextColor, "EmfSetTextColor");
			Assert.Equal (25, (int)EmfPlusRecordType.EmfSetBkColor, "EmfSetBkColor");
			Assert.Equal (26, (int)EmfPlusRecordType.EmfOffsetClipRgn, "EmfOffsetClipRgn");
			Assert.Equal (27, (int)EmfPlusRecordType.EmfMoveToEx, "EmfMoveToEx");
			Assert.Equal (28, (int)EmfPlusRecordType.EmfSetMetaRgn, "EmfSetMetaRgn");
			Assert.Equal (29, (int)EmfPlusRecordType.EmfExcludeClipRect, "EmfExcludeClipRect");
			Assert.Equal (30, (int)EmfPlusRecordType.EmfIntersectClipRect, "EmfIntersectClipRect");
			Assert.Equal (31, (int)EmfPlusRecordType.EmfScaleViewportExtEx, "EmfScaleViewportExtEx");
			Assert.Equal (32, (int)EmfPlusRecordType.EmfScaleWindowExtEx, "EmfScaleWindowExtEx");
			Assert.Equal (33, (int)EmfPlusRecordType.EmfSaveDC, "EmfSaveDC");
			Assert.Equal (34, (int)EmfPlusRecordType.EmfRestoreDC, "EmfRestoreDC");
			Assert.Equal (35, (int)EmfPlusRecordType.EmfSetWorldTransform, "EmfSetWorldTransform");
			Assert.Equal (36, (int)EmfPlusRecordType.EmfModifyWorldTransform, "EmfModifyWorldTransform");
			Assert.Equal (37, (int)EmfPlusRecordType.EmfSelectObject, "EmfSelectObject");
			Assert.Equal (38, (int)EmfPlusRecordType.EmfCreatePen, "EmfCreatePen");
			Assert.Equal (39, (int)EmfPlusRecordType.EmfCreateBrushIndirect, "EmfCreateBrushIndirect");
			Assert.Equal (40, (int)EmfPlusRecordType.EmfDeleteObject, "EmfDeleteObject");
			Assert.Equal (41, (int)EmfPlusRecordType.EmfAngleArc, "EmfAngleArc");
			Assert.Equal (42, (int)EmfPlusRecordType.EmfEllipse, "EmfEllipse");
			Assert.Equal (43, (int)EmfPlusRecordType.EmfRectangle, "EmfRectangle");
			Assert.Equal (44, (int)EmfPlusRecordType.EmfRoundRect, "EmfRoundRect");
			Assert.Equal (45, (int)EmfPlusRecordType.EmfRoundArc, "EmfRoundArc");
			Assert.Equal (46, (int)EmfPlusRecordType.EmfChord, "EmfChord");
			Assert.Equal (47, (int)EmfPlusRecordType.EmfPie, "EmfPie");
			Assert.Equal (48, (int)EmfPlusRecordType.EmfSelectPalette, "EmfSelectPalette");
			Assert.Equal (49, (int)EmfPlusRecordType.EmfCreatePalette, "EmfCreatePalette");
			Assert.Equal (50, (int)EmfPlusRecordType.EmfSetPaletteEntries, "EmfSetPaletteEntries");
			Assert.Equal (51, (int)EmfPlusRecordType.EmfResizePalette, "EmfResizePalette");
			Assert.Equal (52, (int)EmfPlusRecordType.EmfRealizePalette, "EmfRealizePalette");
			Assert.Equal (53, (int)EmfPlusRecordType.EmfExtFloodFill, "EmfExtFloodFill");
			Assert.Equal (54, (int)EmfPlusRecordType.EmfLineTo, "EmfLineTo");
			Assert.Equal (55, (int)EmfPlusRecordType.EmfArcTo, "EmfArcTo");
			Assert.Equal (56, (int)EmfPlusRecordType.EmfPolyDraw, "EmfPolyDraw");
			Assert.Equal (57, (int)EmfPlusRecordType.EmfSetArcDirection, "EmfSetArcDirection");
			Assert.Equal (58, (int)EmfPlusRecordType.EmfSetMiterLimit, "EmfSetMiterLimit");
			Assert.Equal (59, (int)EmfPlusRecordType.EmfBeginPath, "EmfBeginPath");
			Assert.Equal (60, (int)EmfPlusRecordType.EmfEndPath, "EmfEndPath");
			Assert.Equal (61, (int)EmfPlusRecordType.EmfCloseFigure, "EmfCloseFigure");
			Assert.Equal (62, (int)EmfPlusRecordType.EmfFillPath, "EmfFillPath");
			Assert.Equal (63, (int)EmfPlusRecordType.EmfStrokeAndFillPath, "EmfStrokeAndFillPath");
			Assert.Equal (64, (int)EmfPlusRecordType.EmfStrokePath, "EmfStrokePath");
			Assert.Equal (65, (int)EmfPlusRecordType.EmfFlattenPath, "EmfFlattenPath");
			Assert.Equal (66, (int)EmfPlusRecordType.EmfWidenPath, "EmfWidenPath");
			Assert.Equal (67, (int)EmfPlusRecordType.EmfSelectClipPath, "EmfSelectClipPath");
			Assert.Equal (68, (int)EmfPlusRecordType.EmfAbortPath, "EmfAbortPath");
			Assert.Equal (69, (int)EmfPlusRecordType.EmfReserved069, "EmfReserved069");
			Assert.Equal (70, (int)EmfPlusRecordType.EmfGdiComment, "EmfGdiComment");
			Assert.Equal (71, (int)EmfPlusRecordType.EmfFillRgn, "EmfFillRgn");
			Assert.Equal (72, (int)EmfPlusRecordType.EmfFrameRgn, "EmfFrameRgn");
			Assert.Equal (73, (int)EmfPlusRecordType.EmfInvertRgn, "EmfInvertRgn");
			Assert.Equal (74, (int)EmfPlusRecordType.EmfPaintRgn, "EmfPaintRgn");
			Assert.Equal (75, (int)EmfPlusRecordType.EmfExtSelectClipRgn, "EmfExtSelectClipRgn");
			Assert.Equal (76, (int)EmfPlusRecordType.EmfBitBlt, "EmfBitBlt");
			Assert.Equal (77, (int)EmfPlusRecordType.EmfStretchBlt, "EmfStretchBlt");
			Assert.Equal (78, (int)EmfPlusRecordType.EmfMaskBlt, "EmfMaskBlt");
			Assert.Equal (79, (int)EmfPlusRecordType.EmfPlgBlt, "EmfPlgBlt");
			Assert.Equal (80, (int)EmfPlusRecordType.EmfSetDIBitsToDevice, "EmfSetDIBitsToDevice");
			Assert.Equal (81, (int)EmfPlusRecordType.EmfStretchDIBits, "EmfStretchDIBits");
			Assert.Equal (82, (int)EmfPlusRecordType.EmfExtCreateFontIndirect, "EmfExtCreateFontIndirect");
			Assert.Equal (83, (int)EmfPlusRecordType.EmfExtTextOutA, "EmfExtTextOutA");
			Assert.Equal (84, (int)EmfPlusRecordType.EmfExtTextOutW, "EmfExtTextOutW");
			Assert.Equal (85, (int)EmfPlusRecordType.EmfPolyBezier16, "EmfPolyBezier16");
			Assert.Equal (86, (int)EmfPlusRecordType.EmfPolygon16, "EmfPolygon16");
			Assert.Equal (87, (int)EmfPlusRecordType.EmfPolyline16, "EmfPolyline16");
			Assert.Equal (88, (int)EmfPlusRecordType.EmfPolyBezierTo16, "EmfPolyBezierTo16");
			Assert.Equal (89, (int)EmfPlusRecordType.EmfPolylineTo16, "EmfPolylineTo16");
			Assert.Equal (90, (int)EmfPlusRecordType.EmfPolyPolyline16, "EmfPolyPolyline16");
			Assert.Equal (91, (int)EmfPlusRecordType.EmfPolyPolygon16, "EmfPolyPolygon16");
			Assert.Equal (92, (int)EmfPlusRecordType.EmfPolyDraw16, "EmfPolyDraw16");
			Assert.Equal (93, (int)EmfPlusRecordType.EmfCreateMonoBrush, "EmfCreateMonoBrush");
			Assert.Equal (94, (int)EmfPlusRecordType.EmfCreateDibPatternBrushPt, "EmfCreateDibPatternBrushPt");
			Assert.Equal (95, (int)EmfPlusRecordType.EmfExtCreatePen, "EmfExtCreatePen");
			Assert.Equal (96, (int)EmfPlusRecordType.EmfPolyTextOutA, "EmfPolyTextOutA");
			Assert.Equal (97, (int)EmfPlusRecordType.EmfPolyTextOutW, "EmfPolyTextOutW");
			Assert.Equal (98, (int)EmfPlusRecordType.EmfSetIcmMode, "EmfSetIcmMode");
			Assert.Equal (99, (int)EmfPlusRecordType.EmfCreateColorSpace, "EmfCreateColorSpace");
			Assert.Equal (100, (int)EmfPlusRecordType.EmfSetColorSpace, "EmfSetColorSpace");
			Assert.Equal (101, (int)EmfPlusRecordType.EmfDeleteColorSpace, "EmfDeleteColorSpace");
			Assert.Equal (102, (int)EmfPlusRecordType.EmfGlsRecord, "EmfGlsRecord");
			Assert.Equal (103, (int)EmfPlusRecordType.EmfGlsBoundedRecord, "EmfGlsBoundedRecord");
			Assert.Equal (104, (int)EmfPlusRecordType.EmfPixelFormat, "EmfPixelFormat");
			Assert.Equal (105, (int)EmfPlusRecordType.EmfDrawEscape, "EmfDrawEscape");
			Assert.Equal (106, (int)EmfPlusRecordType.EmfExtEscape, "EmfExtEscape");
			Assert.Equal (107, (int)EmfPlusRecordType.EmfStartDoc, "EmfStartDoc");
			Assert.Equal (108, (int)EmfPlusRecordType.EmfSmallTextOut, "EmfSmallTextOut");
			Assert.Equal (109, (int)EmfPlusRecordType.EmfForceUfiMapping, "EmfForceUfiMapping");
			Assert.Equal (110, (int)EmfPlusRecordType.EmfNamedEscpae, "EmfNamedEscpae");
			Assert.Equal (111, (int)EmfPlusRecordType.EmfColorCorrectPalette, "EmfColorCorrectPalette");
			Assert.Equal (112, (int)EmfPlusRecordType.EmfSetIcmProfileA, "EmfSetIcmProfileA");
			Assert.Equal (113, (int)EmfPlusRecordType.EmfSetIcmProfileW, "EmfSetIcmProfileW");
			Assert.Equal (114, (int)EmfPlusRecordType.EmfAlphaBlend, "EmfAlphaBlend");
			Assert.Equal (115, (int)EmfPlusRecordType.EmfSetLayout, "EmfSetLayout");
			Assert.Equal (116, (int)EmfPlusRecordType.EmfTransparentBlt, "EmfTransparentBlt");
			Assert.Equal (117, (int)EmfPlusRecordType.EmfReserved117, "EmfReserved117");
			Assert.Equal (118, (int)EmfPlusRecordType.EmfGradientFill, "EmfGradientFill");
			Assert.Equal (119, (int)EmfPlusRecordType.EmfSetLinkedUfis, "EmfSetLinkedUfis");
			Assert.Equal (120, (int)EmfPlusRecordType.EmfSetTextJustification, "EmfSetTextJustification");
			Assert.Equal (121, (int)EmfPlusRecordType.EmfColorMatchToTargetW, "EmfColorMatchToTargetW");
			Assert.Equal (122, (int)EmfPlusRecordType.EmfCreateColorSpaceW, "EmfCreateColorSpaceW");
			Assert.Equal (122, (int)EmfPlusRecordType.EmfMax, "EmfMax");
		}

		[Fact]
		public void EmfPlusRecords ()
		{
			Assert.Equal (16384, (int)EmfPlusRecordType.EmfPlusRecordBase, "EmfPlusRecordBase");
			Assert.Equal (16384, (int)EmfPlusRecordType.Invalid, "Invalid");
			Assert.Equal (16385, (int)EmfPlusRecordType.Min, "Min");
			Assert.Equal (16385, (int)EmfPlusRecordType.Header, "Header");
			Assert.Equal (16386, (int)EmfPlusRecordType.EndOfFile, "EndOfFile");
			Assert.Equal (16387, (int)EmfPlusRecordType.Comment, "Comment");
			Assert.Equal (16388, (int)EmfPlusRecordType.GetDC, "GetDC");
			Assert.Equal (16389, (int)EmfPlusRecordType.MultiFormatStart, "MultiFormatStart");
			Assert.Equal (16390, (int)EmfPlusRecordType.MultiFormatSection, "MultiFormatSection");
			Assert.Equal (16391, (int)EmfPlusRecordType.MultiFormatEnd, "MultiFormatEnd");
			Assert.Equal (16392, (int)EmfPlusRecordType.Object, "Object");
			Assert.Equal (16393, (int)EmfPlusRecordType.Clear, "Clear");
			Assert.Equal (16394, (int)EmfPlusRecordType.FillRects, "FillRects");
			Assert.Equal (16395, (int)EmfPlusRecordType.DrawRects, "DrawRects");
			Assert.Equal (16396, (int)EmfPlusRecordType.FillPolygon, "FillPolygon");
			Assert.Equal (16397, (int)EmfPlusRecordType.DrawLines, "DrawLines");
			Assert.Equal (16398, (int)EmfPlusRecordType.FillEllipse, "FillEllipse");
			Assert.Equal (16399, (int)EmfPlusRecordType.DrawEllipse, "DrawEllipse");
			Assert.Equal (16400, (int)EmfPlusRecordType.FillPie, "FillPie");
			Assert.Equal (16401, (int)EmfPlusRecordType.DrawPie, "DrawPie");
			Assert.Equal (16402, (int)EmfPlusRecordType.DrawArc, "DrawArc");
			Assert.Equal (16403, (int)EmfPlusRecordType.FillRegion, "FillRegion");
			Assert.Equal (16404, (int)EmfPlusRecordType.FillPath, "FillPath");
			Assert.Equal (16405, (int)EmfPlusRecordType.DrawPath, "DrawPath");
			Assert.Equal (16406, (int)EmfPlusRecordType.FillClosedCurve, "FillClosedCurve");
			Assert.Equal (16407, (int)EmfPlusRecordType.DrawClosedCurve, "DrawClosedCurve");
			Assert.Equal (16408, (int)EmfPlusRecordType.DrawCurve, "DrawCurve");
			Assert.Equal (16409, (int)EmfPlusRecordType.DrawBeziers, "DrawBeziers");
			Assert.Equal (16410, (int)EmfPlusRecordType.DrawImage, "DrawImage");
			Assert.Equal (16411, (int)EmfPlusRecordType.DrawImagePoints, "DrawImagePoints");
			Assert.Equal (16412, (int)EmfPlusRecordType.DrawString, "DrawString");
			Assert.Equal (16413, (int)EmfPlusRecordType.SetRenderingOrigin, "SetRenderingOrigin");
			Assert.Equal (16414, (int)EmfPlusRecordType.SetAntiAliasMode, "SetAntiAliasMode");
			Assert.Equal (16415, (int)EmfPlusRecordType.SetTextRenderingHint, "SetTextRenderingHint");
			Assert.Equal (16416, (int)EmfPlusRecordType.SetTextContrast, "SetTextContrast");
			Assert.Equal (16417, (int)EmfPlusRecordType.SetInterpolationMode, "SetInterpolationMode");
			Assert.Equal (16418, (int)EmfPlusRecordType.SetPixelOffsetMode, "SetPixelOffsetMode");
			Assert.Equal (16419, (int)EmfPlusRecordType.SetCompositingMode, "SetCompositingMode");
			Assert.Equal (16420, (int)EmfPlusRecordType.SetCompositingQuality, "SetCompositingQuality");
			Assert.Equal (16421, (int)EmfPlusRecordType.Save, "Save");
			Assert.Equal (16422, (int)EmfPlusRecordType.Restore, "Restore");
			Assert.Equal (16423, (int)EmfPlusRecordType.BeginContainer, "BeginContainer");
			Assert.Equal (16424, (int)EmfPlusRecordType.BeginContainerNoParams, "BeginContainerNoParams");
			Assert.Equal (16425, (int)EmfPlusRecordType.EndContainer, "EndContainer");
			Assert.Equal (16426, (int)EmfPlusRecordType.SetWorldTransform, "SetWorldTransform");
			Assert.Equal (16427, (int)EmfPlusRecordType.ResetWorldTransform, "ResetWorldTransform");
			Assert.Equal (16428, (int)EmfPlusRecordType.MultiplyWorldTransform, "MultiplyWorldTransform");
			Assert.Equal (16429, (int)EmfPlusRecordType.TranslateWorldTransform, "TranslateWorldTransform");
			Assert.Equal (16430, (int)EmfPlusRecordType.ScaleWorldTransform, "ScaleWorldTransform");
			Assert.Equal (16431, (int)EmfPlusRecordType.RotateWorldTransform, "RotateWorldTransform");
			Assert.Equal (16432, (int)EmfPlusRecordType.SetPageTransform, "SetPageTransform");
			Assert.Equal (16433, (int)EmfPlusRecordType.ResetClip, "ResetClip");
			Assert.Equal (16434, (int)EmfPlusRecordType.SetClipRect, "SetClipRect");
			Assert.Equal (16435, (int)EmfPlusRecordType.SetClipPath, "SetClipPath");
			Assert.Equal (16436, (int)EmfPlusRecordType.SetClipRegion, "SetClipRegion");
			Assert.Equal (16437, (int)EmfPlusRecordType.OffsetClip, "OffsetClip");
			Assert.Equal (16438, (int)EmfPlusRecordType.DrawDriverString, "DrawDriverString");
			Assert.Equal (16438, (int)EmfPlusRecordType.Max, "Max");
			Assert.Equal (16439, (int)EmfPlusRecordType.Total, "Total");
		}

		[Fact]
		public void WmfRecords ()
		{
			Assert.Equal (65536, (int)EmfPlusRecordType.WmfRecordBase, "WmfRecordBase");
			Assert.Equal (65566, (int)EmfPlusRecordType.WmfSaveDC, "WmfSaveDC");
			Assert.Equal (65589, (int)EmfPlusRecordType.WmfRealizePalette, "WmfRealizePalette");
			Assert.Equal (65591, (int)EmfPlusRecordType.WmfSetPalEntries, "WmfSetPalEntries");
			Assert.Equal (65783, (int)EmfPlusRecordType.WmfCreatePalette, "WmfCreatePalette");
			Assert.Equal (65794, (int)EmfPlusRecordType.WmfSetBkMode, "WmfSetBkMode");
			Assert.Equal (65795, (int)EmfPlusRecordType.WmfSetMapMode, "WmfSetMapMode");
			Assert.Equal (65796, (int)EmfPlusRecordType.WmfSetROP2, "WmfSetROP2");
			Assert.Equal (65797, (int)EmfPlusRecordType.WmfSetRelAbs, "WmfSetRelAbs");
			Assert.Equal (65798, (int)EmfPlusRecordType.WmfSetPolyFillMode, "WmfSetPolyFillMode");
			Assert.Equal (65799, (int)EmfPlusRecordType.WmfSetStretchBltMode, "WmfSetStretchBltMode");
			Assert.Equal (65800, (int)EmfPlusRecordType.WmfSetTextCharExtra, "WmfSetTextCharExtra");
			Assert.Equal (65831, (int)EmfPlusRecordType.WmfRestoreDC, "WmfRestoreDC");
			Assert.Equal (65834, (int)EmfPlusRecordType.WmfInvertRegion, "WmfInvertRegion");
			Assert.Equal (65835, (int)EmfPlusRecordType.WmfPaintRegion, "WmfPaintRegion");
			Assert.Equal (65836, (int)EmfPlusRecordType.WmfSelectClipRegion, "WmfSelectClipRegion");
			Assert.Equal (65837, (int)EmfPlusRecordType.WmfSelectObject, "WmfSelectObject");
			Assert.Equal (65838, (int)EmfPlusRecordType.WmfSetTextAlign, "WmfSetTextAlign");
			Assert.Equal (65849, (int)EmfPlusRecordType.WmfResizePalette, "WmfResizePalette");
			Assert.Equal (65858, (int)EmfPlusRecordType.WmfDibCreatePatternBrush, "WmfDibCreatePatternBrush");
			Assert.Equal (65865, (int)EmfPlusRecordType.WmfSetLayout, "WmfSetLayout");
			Assert.Equal (66032, (int)EmfPlusRecordType.WmfDeleteObject, "WmfDeleteObject");
			Assert.Equal (66041, (int)EmfPlusRecordType.WmfCreatePatternBrush, "WmfCreatePatternBrush");
			Assert.Equal (66049, (int)EmfPlusRecordType.WmfSetBkColor, "WmfSetBkColor");
			Assert.Equal (66057, (int)EmfPlusRecordType.WmfSetTextColor, "WmfSetTextColor");
			Assert.Equal (66058, (int)EmfPlusRecordType.WmfSetTextJustification, "WmfSetTextJustification");
			Assert.Equal (66059, (int)EmfPlusRecordType.WmfSetWindowOrg, "WmfSetWindowOrg");
			Assert.Equal (66060, (int)EmfPlusRecordType.WmfSetWindowExt, "WmfSetWindowExt");
			Assert.Equal (66061, (int)EmfPlusRecordType.WmfSetViewportOrg, "WmfSetViewportOrg");
			Assert.Equal (66062, (int)EmfPlusRecordType.WmfSetViewportExt, "WmfSetViewportExt");
			Assert.Equal (66063, (int)EmfPlusRecordType.WmfOffsetWindowOrg, "WmfOffsetWindowOrg");
			Assert.Equal (66065, (int)EmfPlusRecordType.WmfOffsetViewportOrg, "WmfOffsetViewportOrg");
			Assert.Equal (66067, (int)EmfPlusRecordType.WmfLineTo, "WmfLineTo");
			Assert.Equal (66068, (int)EmfPlusRecordType.WmfMoveTo, "WmfMoveTo");
			Assert.Equal (66080, (int)EmfPlusRecordType.WmfOffsetCilpRgn, "WmfOffsetCilpRgn");
			Assert.Equal (66088, (int)EmfPlusRecordType.WmfFillRegion, "WmfFillRegion");
			Assert.Equal (66097, (int)EmfPlusRecordType.WmfSetMapperFlags, "WmfSetMapperFlags");
			Assert.Equal (66100, (int)EmfPlusRecordType.WmfSelectPalette, "WmfSelectPalette");
			Assert.Equal (66298, (int)EmfPlusRecordType.WmfCreatePenIndirect, "WmfCreatePenIndirect");
			Assert.Equal (66299, (int)EmfPlusRecordType.WmfCreateFontIndirect, "WmfCreateFontIndirect");
			Assert.Equal (66300, (int)EmfPlusRecordType.WmfCreateBrushIndirect, "WmfCreateBrushIndirect");
			Assert.Equal (66340, (int)EmfPlusRecordType.WmfPolygon, "WmfPolygon");
			Assert.Equal (66341, (int)EmfPlusRecordType.WmfPolyline, "WmfPolyline");
			Assert.Equal (66576, (int)EmfPlusRecordType.WmfScaleWindowExt, "WmfScaleWindowExt");
			Assert.Equal (66578, (int)EmfPlusRecordType.WmfScaleViewportExt, "WmfScaleViewportExt");
			Assert.Equal (66581, (int)EmfPlusRecordType.WmfExcludeClipRect, "WmfExcludeClipRect");
			Assert.Equal (66582, (int)EmfPlusRecordType.WmfIntersectClipRect, "WmfIntersectClipRect");
			Assert.Equal (66584, (int)EmfPlusRecordType.WmfEllipse, "WmfEllipse");
			Assert.Equal (66585, (int)EmfPlusRecordType.WmfFloodFill, "WmfFloodFill");
			Assert.Equal (66587, (int)EmfPlusRecordType.WmfRectangle, "WmfRectangle");
			Assert.Equal (66591, (int)EmfPlusRecordType.WmfSetPixel, "WmfSetPixel");
			Assert.Equal (66601, (int)EmfPlusRecordType.WmfFrameRegion, "WmfFrameRegion");
			Assert.Equal (66614, (int)EmfPlusRecordType.WmfAnimatePalette, "WmfAnimatePalette");
			Assert.Equal (66849, (int)EmfPlusRecordType.WmfTextOut, "WmfTextOut");
			Assert.Equal (66872, (int)EmfPlusRecordType.WmfPolyPolygon, "WmfPolyPolygon");
			Assert.Equal (66888, (int)EmfPlusRecordType.WmfExtFloodFill, "WmfExtFloodFill");
			Assert.Equal (67100, (int)EmfPlusRecordType.WmfRoundRect, "WmfRoundRect");
			Assert.Equal (67101, (int)EmfPlusRecordType.WmfPatBlt, "WmfPatBlt");
			Assert.Equal (67110, (int)EmfPlusRecordType.WmfEscape, "WmfEscape");
			Assert.Equal (67327, (int)EmfPlusRecordType.WmfCreateRegion, "WmfCreateRegion");
			Assert.Equal (67607, (int)EmfPlusRecordType.WmfArc, "WmfArc");
			Assert.Equal (67610, (int)EmfPlusRecordType.WmfPie, "WmfPie");
			Assert.Equal (67632, (int)EmfPlusRecordType.WmfChord, "WmfChord");
			Assert.Equal (67874, (int)EmfPlusRecordType.WmfBitBlt, "WmfBitBlt");
			Assert.Equal (67904, (int)EmfPlusRecordType.WmfDibBitBlt, "WmfDibBitBlt");
			Assert.Equal (68146, (int)EmfPlusRecordType.WmfExtTextOut, "WmfExtTextOut");
			Assert.Equal (68387, (int)EmfPlusRecordType.WmfStretchBlt, "WmfStretchBlt");
			Assert.Equal (68417, (int)EmfPlusRecordType.WmfDibStretchBlt, "WmfDibStretchBlt");
			Assert.Equal (68915, (int)EmfPlusRecordType.WmfSetDibToDev, "WmfSetDibToDev");
			Assert.Equal (69443, (int)EmfPlusRecordType.WmfStretchDib, "WmfStretchDib");
		}
	}
}
