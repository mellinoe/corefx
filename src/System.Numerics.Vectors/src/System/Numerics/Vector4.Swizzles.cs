// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Numerics
{
    /// <summary>
    /// Expresses component-swizzling operations for Vector4.
    /// </summary>
    public static class Vector4Swizzles
    {
        /// <summary>Returns a new Vector2 whose components are the XX components of this Vector4.</summary>
        public static Vector2 XX(this Vector4 v) => new Vector2(v.X, v.X);

        /// <summary>Returns a new Vector2 whose components are the XY components of this Vector4.</summary>
        public static Vector2 XY(this Vector4 v) => new Vector2(v.X, v.Y);

        /// <summary>Returns a new Vector2 whose components are the XZ components of this Vector4.</summary>
        public static Vector2 XZ(this Vector4 v) => new Vector2(v.X, v.Z);

        /// <summary>Returns a new Vector2 whose components are the XW components of this Vector4.</summary>
        public static Vector2 XW(this Vector4 v) => new Vector2(v.X, v.W);

        /// <summary>Returns a new Vector2 whose components are the YX components of this Vector4.</summary>
        public static Vector2 YX(this Vector4 v) => new Vector2(v.Y, v.X);

        /// <summary>Returns a new Vector2 whose components are the YY components of this Vector4.</summary>
        public static Vector2 YY(this Vector4 v) => new Vector2(v.Y, v.Y);

        /// <summary>Returns a new Vector2 whose components are the YZ components of this Vector4.</summary>
        public static Vector2 YZ(this Vector4 v) => new Vector2(v.Y, v.Z);

        /// <summary>Returns a new Vector2 whose components are the YW components of this Vector4.</summary>
        public static Vector2 YW(this Vector4 v) => new Vector2(v.Y, v.W);

        /// <summary>Returns a new Vector2 whose components are the ZX components of this Vector4.</summary>
        public static Vector2 ZX(this Vector4 v) => new Vector2(v.Z, v.X);

        /// <summary>Returns a new Vector2 whose components are the ZY components of this Vector4.</summary>
        public static Vector2 ZY(this Vector4 v) => new Vector2(v.Z, v.Y);

        /// <summary>Returns a new Vector2 whose components are the ZZ components of this Vector4.</summary>
        public static Vector2 ZZ(this Vector4 v) => new Vector2(v.Z, v.Z);

        /// <summary>Returns a new Vector2 whose components are the ZW components of this Vector4.</summary>
        public static Vector2 ZW(this Vector4 v) => new Vector2(v.Z, v.W);

        /// <summary>Returns a new Vector2 whose components are the WX components of this Vector4.</summary>
        public static Vector2 WX(this Vector4 v) => new Vector2(v.W, v.X);

        /// <summary>Returns a new Vector2 whose components are the WY components of this Vector4.</summary>
        public static Vector2 WY(this Vector4 v) => new Vector2(v.W, v.Y);

        /// <summary>Returns a new Vector2 whose components are the WZ components of this Vector4.</summary>
        public static Vector2 WZ(this Vector4 v) => new Vector2(v.W, v.Z);

        /// <summary>Returns a new Vector2 whose components are the WW components of this Vector4.</summary>
        public static Vector2 WW(this Vector4 v) => new Vector2(v.W, v.W);

        /// <summary>Returns a new Vector3 whose components are the XXX components of this Vector4.</summary>
        public static Vector3 XXX(this Vector4 v) => new Vector3(v.X, v.X, v.X);

        /// <summary>Returns a new Vector3 whose components are the XXY components of this Vector4.</summary>
        public static Vector3 XXY(this Vector4 v) => new Vector3(v.X, v.X, v.Y);

        /// <summary>Returns a new Vector3 whose components are the XXZ components of this Vector4.</summary>
        public static Vector3 XXZ(this Vector4 v) => new Vector3(v.X, v.X, v.Z);

        /// <summary>Returns a new Vector3 whose components are the XXW components of this Vector4.</summary>
        public static Vector3 XXW(this Vector4 v) => new Vector3(v.X, v.X, v.W);

        /// <summary>Returns a new Vector3 whose components are the XYX components of this Vector4.</summary>
        public static Vector3 XYX(this Vector4 v) => new Vector3(v.X, v.Y, v.X);

        /// <summary>Returns a new Vector3 whose components are the XYY components of this Vector4.</summary>
        public static Vector3 XYY(this Vector4 v) => new Vector3(v.X, v.Y, v.Y);

        /// <summary>Returns a new Vector3 whose components are the XYZ components of this Vector4.</summary>
        public static Vector3 XYZ(this Vector4 v) => new Vector3(v.X, v.Y, v.Z);

        /// <summary>Returns a new Vector3 whose components are the XYW components of this Vector4.</summary>
        public static Vector3 XYW(this Vector4 v) => new Vector3(v.X, v.Y, v.W);

        /// <summary>Returns a new Vector3 whose components are the XZX components of this Vector4.</summary>
        public static Vector3 XZX(this Vector4 v) => new Vector3(v.X, v.Z, v.X);

        /// <summary>Returns a new Vector3 whose components are the XZY components of this Vector4.</summary>
        public static Vector3 XZY(this Vector4 v) => new Vector3(v.X, v.Z, v.Y);

        /// <summary>Returns a new Vector3 whose components are the XZZ components of this Vector4.</summary>
        public static Vector3 XZZ(this Vector4 v) => new Vector3(v.X, v.Z, v.Z);

        /// <summary>Returns a new Vector3 whose components are the XZW components of this Vector4.</summary>
        public static Vector3 XZW(this Vector4 v) => new Vector3(v.X, v.Z, v.W);

        /// <summary>Returns a new Vector3 whose components are the XWX components of this Vector4.</summary>
        public static Vector3 XWX(this Vector4 v) => new Vector3(v.X, v.W, v.X);

        /// <summary>Returns a new Vector3 whose components are the XWY components of this Vector4.</summary>
        public static Vector3 XWY(this Vector4 v) => new Vector3(v.X, v.W, v.Y);

        /// <summary>Returns a new Vector3 whose components are the XWZ components of this Vector4.</summary>
        public static Vector3 XWZ(this Vector4 v) => new Vector3(v.X, v.W, v.Z);

        /// <summary>Returns a new Vector3 whose components are the XWW components of this Vector4.</summary>
        public static Vector3 XWW(this Vector4 v) => new Vector3(v.X, v.W, v.W);

        /// <summary>Returns a new Vector3 whose components are the YXX components of this Vector4.</summary>
        public static Vector3 YXX(this Vector4 v) => new Vector3(v.Y, v.X, v.X);

        /// <summary>Returns a new Vector3 whose components are the YXY components of this Vector4.</summary>
        public static Vector3 YXY(this Vector4 v) => new Vector3(v.Y, v.X, v.Y);

        /// <summary>Returns a new Vector3 whose components are the YXZ components of this Vector4.</summary>
        public static Vector3 YXZ(this Vector4 v) => new Vector3(v.Y, v.X, v.Z);

        /// <summary>Returns a new Vector3 whose components are the YXW components of this Vector4.</summary>
        public static Vector3 YXW(this Vector4 v) => new Vector3(v.Y, v.X, v.W);

        /// <summary>Returns a new Vector3 whose components are the YYX components of this Vector4.</summary>
        public static Vector3 YYX(this Vector4 v) => new Vector3(v.Y, v.Y, v.X);

        /// <summary>Returns a new Vector3 whose components are the YYY components of this Vector4.</summary>
        public static Vector3 YYY(this Vector4 v) => new Vector3(v.Y, v.Y, v.Y);

        /// <summary>Returns a new Vector3 whose components are the YYZ components of this Vector4.</summary>
        public static Vector3 YYZ(this Vector4 v) => new Vector3(v.Y, v.Y, v.Z);

        /// <summary>Returns a new Vector3 whose components are the YYW components of this Vector4.</summary>
        public static Vector3 YYW(this Vector4 v) => new Vector3(v.Y, v.Y, v.W);

        /// <summary>Returns a new Vector3 whose components are the YZX components of this Vector4.</summary>
        public static Vector3 YZX(this Vector4 v) => new Vector3(v.Y, v.Z, v.X);

        /// <summary>Returns a new Vector3 whose components are the YZY components of this Vector4.</summary>
        public static Vector3 YZY(this Vector4 v) => new Vector3(v.Y, v.Z, v.Y);

        /// <summary>Returns a new Vector3 whose components are the YZZ components of this Vector4.</summary>
        public static Vector3 YZZ(this Vector4 v) => new Vector3(v.Y, v.Z, v.Z);

        /// <summary>Returns a new Vector3 whose components are the YZW components of this Vector4.</summary>
        public static Vector3 YZW(this Vector4 v) => new Vector3(v.Y, v.Z, v.W);

        /// <summary>Returns a new Vector3 whose components are the YWX components of this Vector4.</summary>
        public static Vector3 YWX(this Vector4 v) => new Vector3(v.Y, v.W, v.X);

        /// <summary>Returns a new Vector3 whose components are the YWY components of this Vector4.</summary>
        public static Vector3 YWY(this Vector4 v) => new Vector3(v.Y, v.W, v.Y);

        /// <summary>Returns a new Vector3 whose components are the YWZ components of this Vector4.</summary>
        public static Vector3 YWZ(this Vector4 v) => new Vector3(v.Y, v.W, v.Z);

        /// <summary>Returns a new Vector3 whose components are the YWW components of this Vector4.</summary>
        public static Vector3 YWW(this Vector4 v) => new Vector3(v.Y, v.W, v.W);

        /// <summary>Returns a new Vector3 whose components are the ZXX components of this Vector4.</summary>
        public static Vector3 ZXX(this Vector4 v) => new Vector3(v.Z, v.X, v.X);

        /// <summary>Returns a new Vector3 whose components are the ZXY components of this Vector4.</summary>
        public static Vector3 ZXY(this Vector4 v) => new Vector3(v.Z, v.X, v.Y);

        /// <summary>Returns a new Vector3 whose components are the ZXZ components of this Vector4.</summary>
        public static Vector3 ZXZ(this Vector4 v) => new Vector3(v.Z, v.X, v.Z);

        /// <summary>Returns a new Vector3 whose components are the ZXW components of this Vector4.</summary>
        public static Vector3 ZXW(this Vector4 v) => new Vector3(v.Z, v.X, v.W);

        /// <summary>Returns a new Vector3 whose components are the ZYX components of this Vector4.</summary>
        public static Vector3 ZYX(this Vector4 v) => new Vector3(v.Z, v.Y, v.X);

        /// <summary>Returns a new Vector3 whose components are the ZYY components of this Vector4.</summary>
        public static Vector3 ZYY(this Vector4 v) => new Vector3(v.Z, v.Y, v.Y);

        /// <summary>Returns a new Vector3 whose components are the ZYZ components of this Vector4.</summary>
        public static Vector3 ZYZ(this Vector4 v) => new Vector3(v.Z, v.Y, v.Z);

        /// <summary>Returns a new Vector3 whose components are the ZYW components of this Vector4.</summary>
        public static Vector3 ZYW(this Vector4 v) => new Vector3(v.Z, v.Y, v.W);

        /// <summary>Returns a new Vector3 whose components are the ZZX components of this Vector4.</summary>
        public static Vector3 ZZX(this Vector4 v) => new Vector3(v.Z, v.Z, v.X);

        /// <summary>Returns a new Vector3 whose components are the ZZY components of this Vector4.</summary>
        public static Vector3 ZZY(this Vector4 v) => new Vector3(v.Z, v.Z, v.Y);

        /// <summary>Returns a new Vector3 whose components are the ZZZ components of this Vector4.</summary>
        public static Vector3 ZZZ(this Vector4 v) => new Vector3(v.Z, v.Z, v.Z);

        /// <summary>Returns a new Vector3 whose components are the ZZW components of this Vector4.</summary>
        public static Vector3 ZZW(this Vector4 v) => new Vector3(v.Z, v.Z, v.W);

        /// <summary>Returns a new Vector3 whose components are the ZWX components of this Vector4.</summary>
        public static Vector3 ZWX(this Vector4 v) => new Vector3(v.Z, v.W, v.X);

        /// <summary>Returns a new Vector3 whose components are the ZWY components of this Vector4.</summary>
        public static Vector3 ZWY(this Vector4 v) => new Vector3(v.Z, v.W, v.Y);

        /// <summary>Returns a new Vector3 whose components are the ZWZ components of this Vector4.</summary>
        public static Vector3 ZWZ(this Vector4 v) => new Vector3(v.Z, v.W, v.Z);

        /// <summary>Returns a new Vector3 whose components are the ZWW components of this Vector4.</summary>
        public static Vector3 ZWW(this Vector4 v) => new Vector3(v.Z, v.W, v.W);

        /// <summary>Returns a new Vector3 whose components are the WXX components of this Vector4.</summary>
        public static Vector3 WXX(this Vector4 v) => new Vector3(v.W, v.X, v.X);

        /// <summary>Returns a new Vector3 whose components are the WXY components of this Vector4.</summary>
        public static Vector3 WXY(this Vector4 v) => new Vector3(v.W, v.X, v.Y);

        /// <summary>Returns a new Vector3 whose components are the WXZ components of this Vector4.</summary>
        public static Vector3 WXZ(this Vector4 v) => new Vector3(v.W, v.X, v.Z);

        /// <summary>Returns a new Vector3 whose components are the WXW components of this Vector4.</summary>
        public static Vector3 WXW(this Vector4 v) => new Vector3(v.W, v.X, v.W);

        /// <summary>Returns a new Vector3 whose components are the WYX components of this Vector4.</summary>
        public static Vector3 WYX(this Vector4 v) => new Vector3(v.W, v.Y, v.X);

        /// <summary>Returns a new Vector3 whose components are the WYY components of this Vector4.</summary>
        public static Vector3 WYY(this Vector4 v) => new Vector3(v.W, v.Y, v.Y);

        /// <summary>Returns a new Vector3 whose components are the WYZ components of this Vector4.</summary>
        public static Vector3 WYZ(this Vector4 v) => new Vector3(v.W, v.Y, v.Z);

        /// <summary>Returns a new Vector3 whose components are the WYW components of this Vector4.</summary>
        public static Vector3 WYW(this Vector4 v) => new Vector3(v.W, v.Y, v.W);

        /// <summary>Returns a new Vector3 whose components are the WZX components of this Vector4.</summary>
        public static Vector3 WZX(this Vector4 v) => new Vector3(v.W, v.Z, v.X);

        /// <summary>Returns a new Vector3 whose components are the WZY components of this Vector4.</summary>
        public static Vector3 WZY(this Vector4 v) => new Vector3(v.W, v.Z, v.Y);

        /// <summary>Returns a new Vector3 whose components are the WZZ components of this Vector4.</summary>
        public static Vector3 WZZ(this Vector4 v) => new Vector3(v.W, v.Z, v.Z);

        /// <summary>Returns a new Vector3 whose components are the WZW components of this Vector4.</summary>
        public static Vector3 WZW(this Vector4 v) => new Vector3(v.W, v.Z, v.W);

        /// <summary>Returns a new Vector3 whose components are the WWX components of this Vector4.</summary>
        public static Vector3 WWX(this Vector4 v) => new Vector3(v.W, v.W, v.X);

        /// <summary>Returns a new Vector3 whose components are the WWY components of this Vector4.</summary>
        public static Vector3 WWY(this Vector4 v) => new Vector3(v.W, v.W, v.Y);

        /// <summary>Returns a new Vector3 whose components are the WWZ components of this Vector4.</summary>
        public static Vector3 WWZ(this Vector4 v) => new Vector3(v.W, v.W, v.Z);

        /// <summary>Returns a new Vector3 whose components are the WWW components of this Vector4.</summary>
        public static Vector3 WWW(this Vector4 v) => new Vector3(v.W, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the XXXX components of this Vector4.</summary>
        public static Vector4 XXXX(this Vector4 v) => new Vector4(v.X, v.X, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the XXXY components of this Vector4.</summary>
        public static Vector4 XXXY(this Vector4 v) => new Vector4(v.X, v.X, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XXXZ components of this Vector4.</summary>
        public static Vector4 XXXZ(this Vector4 v) => new Vector4(v.X, v.X, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XXXW components of this Vector4.</summary>
        public static Vector4 XXXW(this Vector4 v) => new Vector4(v.X, v.X, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the XXYX components of this Vector4.</summary>
        public static Vector4 XXYX(this Vector4 v) => new Vector4(v.X, v.X, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the XXYY components of this Vector4.</summary>
        public static Vector4 XXYY(this Vector4 v) => new Vector4(v.X, v.X, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XXYZ components of this Vector4.</summary>
        public static Vector4 XXYZ(this Vector4 v) => new Vector4(v.X, v.X, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XXYW components of this Vector4.</summary>
        public static Vector4 XXYW(this Vector4 v) => new Vector4(v.X, v.X, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the XXZX components of this Vector4.</summary>
        public static Vector4 XXZX(this Vector4 v) => new Vector4(v.X, v.X, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the XXZY components of this Vector4.</summary>
        public static Vector4 XXZY(this Vector4 v) => new Vector4(v.X, v.X, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XXZZ components of this Vector4.</summary>
        public static Vector4 XXZZ(this Vector4 v) => new Vector4(v.X, v.X, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XXZW components of this Vector4.</summary>
        public static Vector4 XXZW(this Vector4 v) => new Vector4(v.X, v.X, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the XXWX components of this Vector4.</summary>
        public static Vector4 XXWX(this Vector4 v) => new Vector4(v.X, v.X, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the XXWY components of this Vector4.</summary>
        public static Vector4 XXWY(this Vector4 v) => new Vector4(v.X, v.X, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XXWZ components of this Vector4.</summary>
        public static Vector4 XXWZ(this Vector4 v) => new Vector4(v.X, v.X, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XXWW components of this Vector4.</summary>
        public static Vector4 XXWW(this Vector4 v) => new Vector4(v.X, v.X, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the XYXX components of this Vector4.</summary>
        public static Vector4 XYXX(this Vector4 v) => new Vector4(v.X, v.Y, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the XYXY components of this Vector4.</summary>
        public static Vector4 XYXY(this Vector4 v) => new Vector4(v.X, v.Y, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XYXZ components of this Vector4.</summary>
        public static Vector4 XYXZ(this Vector4 v) => new Vector4(v.X, v.Y, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XYXW components of this Vector4.</summary>
        public static Vector4 XYXW(this Vector4 v) => new Vector4(v.X, v.Y, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the XYYX components of this Vector4.</summary>
        public static Vector4 XYYX(this Vector4 v) => new Vector4(v.X, v.Y, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the XYYY components of this Vector4.</summary>
        public static Vector4 XYYY(this Vector4 v) => new Vector4(v.X, v.Y, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XYYZ components of this Vector4.</summary>
        public static Vector4 XYYZ(this Vector4 v) => new Vector4(v.X, v.Y, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XYYW components of this Vector4.</summary>
        public static Vector4 XYYW(this Vector4 v) => new Vector4(v.X, v.Y, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the XYZX components of this Vector4.</summary>
        public static Vector4 XYZX(this Vector4 v) => new Vector4(v.X, v.Y, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the XYZY components of this Vector4.</summary>
        public static Vector4 XYZY(this Vector4 v) => new Vector4(v.X, v.Y, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XYZZ components of this Vector4.</summary>
        public static Vector4 XYZZ(this Vector4 v) => new Vector4(v.X, v.Y, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XYZW components of this Vector4.</summary>
        public static Vector4 XYZW(this Vector4 v) => new Vector4(v.X, v.Y, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the XYWX components of this Vector4.</summary>
        public static Vector4 XYWX(this Vector4 v) => new Vector4(v.X, v.Y, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the XYWY components of this Vector4.</summary>
        public static Vector4 XYWY(this Vector4 v) => new Vector4(v.X, v.Y, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XYWZ components of this Vector4.</summary>
        public static Vector4 XYWZ(this Vector4 v) => new Vector4(v.X, v.Y, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XYWW components of this Vector4.</summary>
        public static Vector4 XYWW(this Vector4 v) => new Vector4(v.X, v.Y, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the XZXX components of this Vector4.</summary>
        public static Vector4 XZXX(this Vector4 v) => new Vector4(v.X, v.Z, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the XZXY components of this Vector4.</summary>
        public static Vector4 XZXY(this Vector4 v) => new Vector4(v.X, v.Z, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XZXZ components of this Vector4.</summary>
        public static Vector4 XZXZ(this Vector4 v) => new Vector4(v.X, v.Z, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XZXW components of this Vector4.</summary>
        public static Vector4 XZXW(this Vector4 v) => new Vector4(v.X, v.Z, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the XZYX components of this Vector4.</summary>
        public static Vector4 XZYX(this Vector4 v) => new Vector4(v.X, v.Z, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the XZYY components of this Vector4.</summary>
        public static Vector4 XZYY(this Vector4 v) => new Vector4(v.X, v.Z, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XZYZ components of this Vector4.</summary>
        public static Vector4 XZYZ(this Vector4 v) => new Vector4(v.X, v.Z, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XZYW components of this Vector4.</summary>
        public static Vector4 XZYW(this Vector4 v) => new Vector4(v.X, v.Z, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the XZZX components of this Vector4.</summary>
        public static Vector4 XZZX(this Vector4 v) => new Vector4(v.X, v.Z, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the XZZY components of this Vector4.</summary>
        public static Vector4 XZZY(this Vector4 v) => new Vector4(v.X, v.Z, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XZZZ components of this Vector4.</summary>
        public static Vector4 XZZZ(this Vector4 v) => new Vector4(v.X, v.Z, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XZZW components of this Vector4.</summary>
        public static Vector4 XZZW(this Vector4 v) => new Vector4(v.X, v.Z, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the XZWX components of this Vector4.</summary>
        public static Vector4 XZWX(this Vector4 v) => new Vector4(v.X, v.Z, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the XZWY components of this Vector4.</summary>
        public static Vector4 XZWY(this Vector4 v) => new Vector4(v.X, v.Z, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XZWZ components of this Vector4.</summary>
        public static Vector4 XZWZ(this Vector4 v) => new Vector4(v.X, v.Z, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XZWW components of this Vector4.</summary>
        public static Vector4 XZWW(this Vector4 v) => new Vector4(v.X, v.Z, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the XWXX components of this Vector4.</summary>
        public static Vector4 XWXX(this Vector4 v) => new Vector4(v.X, v.W, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the XWXY components of this Vector4.</summary>
        public static Vector4 XWXY(this Vector4 v) => new Vector4(v.X, v.W, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XWXZ components of this Vector4.</summary>
        public static Vector4 XWXZ(this Vector4 v) => new Vector4(v.X, v.W, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XWXW components of this Vector4.</summary>
        public static Vector4 XWXW(this Vector4 v) => new Vector4(v.X, v.W, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the XWYX components of this Vector4.</summary>
        public static Vector4 XWYX(this Vector4 v) => new Vector4(v.X, v.W, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the XWYY components of this Vector4.</summary>
        public static Vector4 XWYY(this Vector4 v) => new Vector4(v.X, v.W, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XWYZ components of this Vector4.</summary>
        public static Vector4 XWYZ(this Vector4 v) => new Vector4(v.X, v.W, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XWYW components of this Vector4.</summary>
        public static Vector4 XWYW(this Vector4 v) => new Vector4(v.X, v.W, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the XWZX components of this Vector4.</summary>
        public static Vector4 XWZX(this Vector4 v) => new Vector4(v.X, v.W, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the XWZY components of this Vector4.</summary>
        public static Vector4 XWZY(this Vector4 v) => new Vector4(v.X, v.W, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XWZZ components of this Vector4.</summary>
        public static Vector4 XWZZ(this Vector4 v) => new Vector4(v.X, v.W, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XWZW components of this Vector4.</summary>
        public static Vector4 XWZW(this Vector4 v) => new Vector4(v.X, v.W, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the XWWX components of this Vector4.</summary>
        public static Vector4 XWWX(this Vector4 v) => new Vector4(v.X, v.W, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the XWWY components of this Vector4.</summary>
        public static Vector4 XWWY(this Vector4 v) => new Vector4(v.X, v.W, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the XWWZ components of this Vector4.</summary>
        public static Vector4 XWWZ(this Vector4 v) => new Vector4(v.X, v.W, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the XWWW components of this Vector4.</summary>
        public static Vector4 XWWW(this Vector4 v) => new Vector4(v.X, v.W, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the YXXX components of this Vector4.</summary>
        public static Vector4 YXXX(this Vector4 v) => new Vector4(v.Y, v.X, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the YXXY components of this Vector4.</summary>
        public static Vector4 YXXY(this Vector4 v) => new Vector4(v.Y, v.X, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YXXZ components of this Vector4.</summary>
        public static Vector4 YXXZ(this Vector4 v) => new Vector4(v.Y, v.X, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YXXW components of this Vector4.</summary>
        public static Vector4 YXXW(this Vector4 v) => new Vector4(v.Y, v.X, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the YXYX components of this Vector4.</summary>
        public static Vector4 YXYX(this Vector4 v) => new Vector4(v.Y, v.X, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the YXYY components of this Vector4.</summary>
        public static Vector4 YXYY(this Vector4 v) => new Vector4(v.Y, v.X, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YXYZ components of this Vector4.</summary>
        public static Vector4 YXYZ(this Vector4 v) => new Vector4(v.Y, v.X, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YXYW components of this Vector4.</summary>
        public static Vector4 YXYW(this Vector4 v) => new Vector4(v.Y, v.X, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the YXZX components of this Vector4.</summary>
        public static Vector4 YXZX(this Vector4 v) => new Vector4(v.Y, v.X, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the YXZY components of this Vector4.</summary>
        public static Vector4 YXZY(this Vector4 v) => new Vector4(v.Y, v.X, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YXZZ components of this Vector4.</summary>
        public static Vector4 YXZZ(this Vector4 v) => new Vector4(v.Y, v.X, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YXZW components of this Vector4.</summary>
        public static Vector4 YXZW(this Vector4 v) => new Vector4(v.Y, v.X, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the YXWX components of this Vector4.</summary>
        public static Vector4 YXWX(this Vector4 v) => new Vector4(v.Y, v.X, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the YXWY components of this Vector4.</summary>
        public static Vector4 YXWY(this Vector4 v) => new Vector4(v.Y, v.X, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YXWZ components of this Vector4.</summary>
        public static Vector4 YXWZ(this Vector4 v) => new Vector4(v.Y, v.X, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YXWW components of this Vector4.</summary>
        public static Vector4 YXWW(this Vector4 v) => new Vector4(v.Y, v.X, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the YYXX components of this Vector4.</summary>
        public static Vector4 YYXX(this Vector4 v) => new Vector4(v.Y, v.Y, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the YYXY components of this Vector4.</summary>
        public static Vector4 YYXY(this Vector4 v) => new Vector4(v.Y, v.Y, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YYXZ components of this Vector4.</summary>
        public static Vector4 YYXZ(this Vector4 v) => new Vector4(v.Y, v.Y, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YYXW components of this Vector4.</summary>
        public static Vector4 YYXW(this Vector4 v) => new Vector4(v.Y, v.Y, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the YYYX components of this Vector4.</summary>
        public static Vector4 YYYX(this Vector4 v) => new Vector4(v.Y, v.Y, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the YYYY components of this Vector4.</summary>
        public static Vector4 YYYY(this Vector4 v) => new Vector4(v.Y, v.Y, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YYYZ components of this Vector4.</summary>
        public static Vector4 YYYZ(this Vector4 v) => new Vector4(v.Y, v.Y, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YYYW components of this Vector4.</summary>
        public static Vector4 YYYW(this Vector4 v) => new Vector4(v.Y, v.Y, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the YYZX components of this Vector4.</summary>
        public static Vector4 YYZX(this Vector4 v) => new Vector4(v.Y, v.Y, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the YYZY components of this Vector4.</summary>
        public static Vector4 YYZY(this Vector4 v) => new Vector4(v.Y, v.Y, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YYZZ components of this Vector4.</summary>
        public static Vector4 YYZZ(this Vector4 v) => new Vector4(v.Y, v.Y, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YYZW components of this Vector4.</summary>
        public static Vector4 YYZW(this Vector4 v) => new Vector4(v.Y, v.Y, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the YYWX components of this Vector4.</summary>
        public static Vector4 YYWX(this Vector4 v) => new Vector4(v.Y, v.Y, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the YYWY components of this Vector4.</summary>
        public static Vector4 YYWY(this Vector4 v) => new Vector4(v.Y, v.Y, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YYWZ components of this Vector4.</summary>
        public static Vector4 YYWZ(this Vector4 v) => new Vector4(v.Y, v.Y, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YYWW components of this Vector4.</summary>
        public static Vector4 YYWW(this Vector4 v) => new Vector4(v.Y, v.Y, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the YZXX components of this Vector4.</summary>
        public static Vector4 YZXX(this Vector4 v) => new Vector4(v.Y, v.Z, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the YZXY components of this Vector4.</summary>
        public static Vector4 YZXY(this Vector4 v) => new Vector4(v.Y, v.Z, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YZXZ components of this Vector4.</summary>
        public static Vector4 YZXZ(this Vector4 v) => new Vector4(v.Y, v.Z, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YZXW components of this Vector4.</summary>
        public static Vector4 YZXW(this Vector4 v) => new Vector4(v.Y, v.Z, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the YZYX components of this Vector4.</summary>
        public static Vector4 YZYX(this Vector4 v) => new Vector4(v.Y, v.Z, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the YZYY components of this Vector4.</summary>
        public static Vector4 YZYY(this Vector4 v) => new Vector4(v.Y, v.Z, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YZYZ components of this Vector4.</summary>
        public static Vector4 YZYZ(this Vector4 v) => new Vector4(v.Y, v.Z, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YZYW components of this Vector4.</summary>
        public static Vector4 YZYW(this Vector4 v) => new Vector4(v.Y, v.Z, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the YZZX components of this Vector4.</summary>
        public static Vector4 YZZX(this Vector4 v) => new Vector4(v.Y, v.Z, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the YZZY components of this Vector4.</summary>
        public static Vector4 YZZY(this Vector4 v) => new Vector4(v.Y, v.Z, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YZZZ components of this Vector4.</summary>
        public static Vector4 YZZZ(this Vector4 v) => new Vector4(v.Y, v.Z, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YZZW components of this Vector4.</summary>
        public static Vector4 YZZW(this Vector4 v) => new Vector4(v.Y, v.Z, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the YZWX components of this Vector4.</summary>
        public static Vector4 YZWX(this Vector4 v) => new Vector4(v.Y, v.Z, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the YZWY components of this Vector4.</summary>
        public static Vector4 YZWY(this Vector4 v) => new Vector4(v.Y, v.Z, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YZWZ components of this Vector4.</summary>
        public static Vector4 YZWZ(this Vector4 v) => new Vector4(v.Y, v.Z, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YZWW components of this Vector4.</summary>
        public static Vector4 YZWW(this Vector4 v) => new Vector4(v.Y, v.Z, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the YWXX components of this Vector4.</summary>
        public static Vector4 YWXX(this Vector4 v) => new Vector4(v.Y, v.W, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the YWXY components of this Vector4.</summary>
        public static Vector4 YWXY(this Vector4 v) => new Vector4(v.Y, v.W, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YWXZ components of this Vector4.</summary>
        public static Vector4 YWXZ(this Vector4 v) => new Vector4(v.Y, v.W, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YWXW components of this Vector4.</summary>
        public static Vector4 YWXW(this Vector4 v) => new Vector4(v.Y, v.W, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the YWYX components of this Vector4.</summary>
        public static Vector4 YWYX(this Vector4 v) => new Vector4(v.Y, v.W, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the YWYY components of this Vector4.</summary>
        public static Vector4 YWYY(this Vector4 v) => new Vector4(v.Y, v.W, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YWYZ components of this Vector4.</summary>
        public static Vector4 YWYZ(this Vector4 v) => new Vector4(v.Y, v.W, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YWYW components of this Vector4.</summary>
        public static Vector4 YWYW(this Vector4 v) => new Vector4(v.Y, v.W, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the YWZX components of this Vector4.</summary>
        public static Vector4 YWZX(this Vector4 v) => new Vector4(v.Y, v.W, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the YWZY components of this Vector4.</summary>
        public static Vector4 YWZY(this Vector4 v) => new Vector4(v.Y, v.W, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YWZZ components of this Vector4.</summary>
        public static Vector4 YWZZ(this Vector4 v) => new Vector4(v.Y, v.W, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YWZW components of this Vector4.</summary>
        public static Vector4 YWZW(this Vector4 v) => new Vector4(v.Y, v.W, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the YWWX components of this Vector4.</summary>
        public static Vector4 YWWX(this Vector4 v) => new Vector4(v.Y, v.W, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the YWWY components of this Vector4.</summary>
        public static Vector4 YWWY(this Vector4 v) => new Vector4(v.Y, v.W, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the YWWZ components of this Vector4.</summary>
        public static Vector4 YWWZ(this Vector4 v) => new Vector4(v.Y, v.W, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the YWWW components of this Vector4.</summary>
        public static Vector4 YWWW(this Vector4 v) => new Vector4(v.Y, v.W, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZXXX components of this Vector4.</summary>
        public static Vector4 ZXXX(this Vector4 v) => new Vector4(v.Z, v.X, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZXXY components of this Vector4.</summary>
        public static Vector4 ZXXY(this Vector4 v) => new Vector4(v.Z, v.X, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZXXZ components of this Vector4.</summary>
        public static Vector4 ZXXZ(this Vector4 v) => new Vector4(v.Z, v.X, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZXXW components of this Vector4.</summary>
        public static Vector4 ZXXW(this Vector4 v) => new Vector4(v.Z, v.X, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZXYX components of this Vector4.</summary>
        public static Vector4 ZXYX(this Vector4 v) => new Vector4(v.Z, v.X, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZXYY components of this Vector4.</summary>
        public static Vector4 ZXYY(this Vector4 v) => new Vector4(v.Z, v.X, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZXYZ components of this Vector4.</summary>
        public static Vector4 ZXYZ(this Vector4 v) => new Vector4(v.Z, v.X, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZXYW components of this Vector4.</summary>
        public static Vector4 ZXYW(this Vector4 v) => new Vector4(v.Z, v.X, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZXZX components of this Vector4.</summary>
        public static Vector4 ZXZX(this Vector4 v) => new Vector4(v.Z, v.X, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZXZY components of this Vector4.</summary>
        public static Vector4 ZXZY(this Vector4 v) => new Vector4(v.Z, v.X, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZXZZ components of this Vector4.</summary>
        public static Vector4 ZXZZ(this Vector4 v) => new Vector4(v.Z, v.X, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZXZW components of this Vector4.</summary>
        public static Vector4 ZXZW(this Vector4 v) => new Vector4(v.Z, v.X, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZXWX components of this Vector4.</summary>
        public static Vector4 ZXWX(this Vector4 v) => new Vector4(v.Z, v.X, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZXWY components of this Vector4.</summary>
        public static Vector4 ZXWY(this Vector4 v) => new Vector4(v.Z, v.X, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZXWZ components of this Vector4.</summary>
        public static Vector4 ZXWZ(this Vector4 v) => new Vector4(v.Z, v.X, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZXWW components of this Vector4.</summary>
        public static Vector4 ZXWW(this Vector4 v) => new Vector4(v.Z, v.X, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZYXX components of this Vector4.</summary>
        public static Vector4 ZYXX(this Vector4 v) => new Vector4(v.Z, v.Y, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZYXY components of this Vector4.</summary>
        public static Vector4 ZYXY(this Vector4 v) => new Vector4(v.Z, v.Y, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZYXZ components of this Vector4.</summary>
        public static Vector4 ZYXZ(this Vector4 v) => new Vector4(v.Z, v.Y, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZYXW components of this Vector4.</summary>
        public static Vector4 ZYXW(this Vector4 v) => new Vector4(v.Z, v.Y, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZYYX components of this Vector4.</summary>
        public static Vector4 ZYYX(this Vector4 v) => new Vector4(v.Z, v.Y, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZYYY components of this Vector4.</summary>
        public static Vector4 ZYYY(this Vector4 v) => new Vector4(v.Z, v.Y, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZYYZ components of this Vector4.</summary>
        public static Vector4 ZYYZ(this Vector4 v) => new Vector4(v.Z, v.Y, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZYYW components of this Vector4.</summary>
        public static Vector4 ZYYW(this Vector4 v) => new Vector4(v.Z, v.Y, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZYZX components of this Vector4.</summary>
        public static Vector4 ZYZX(this Vector4 v) => new Vector4(v.Z, v.Y, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZYZY components of this Vector4.</summary>
        public static Vector4 ZYZY(this Vector4 v) => new Vector4(v.Z, v.Y, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZYZZ components of this Vector4.</summary>
        public static Vector4 ZYZZ(this Vector4 v) => new Vector4(v.Z, v.Y, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZYZW components of this Vector4.</summary>
        public static Vector4 ZYZW(this Vector4 v) => new Vector4(v.Z, v.Y, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZYWX components of this Vector4.</summary>
        public static Vector4 ZYWX(this Vector4 v) => new Vector4(v.Z, v.Y, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZYWY components of this Vector4.</summary>
        public static Vector4 ZYWY(this Vector4 v) => new Vector4(v.Z, v.Y, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZYWZ components of this Vector4.</summary>
        public static Vector4 ZYWZ(this Vector4 v) => new Vector4(v.Z, v.Y, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZYWW components of this Vector4.</summary>
        public static Vector4 ZYWW(this Vector4 v) => new Vector4(v.Z, v.Y, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZZXX components of this Vector4.</summary>
        public static Vector4 ZZXX(this Vector4 v) => new Vector4(v.Z, v.Z, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZZXY components of this Vector4.</summary>
        public static Vector4 ZZXY(this Vector4 v) => new Vector4(v.Z, v.Z, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZZXZ components of this Vector4.</summary>
        public static Vector4 ZZXZ(this Vector4 v) => new Vector4(v.Z, v.Z, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZZXW components of this Vector4.</summary>
        public static Vector4 ZZXW(this Vector4 v) => new Vector4(v.Z, v.Z, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZZYX components of this Vector4.</summary>
        public static Vector4 ZZYX(this Vector4 v) => new Vector4(v.Z, v.Z, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZZYY components of this Vector4.</summary>
        public static Vector4 ZZYY(this Vector4 v) => new Vector4(v.Z, v.Z, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZZYZ components of this Vector4.</summary>
        public static Vector4 ZZYZ(this Vector4 v) => new Vector4(v.Z, v.Z, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZZYW components of this Vector4.</summary>
        public static Vector4 ZZYW(this Vector4 v) => new Vector4(v.Z, v.Z, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZZZX components of this Vector4.</summary>
        public static Vector4 ZZZX(this Vector4 v) => new Vector4(v.Z, v.Z, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZZZY components of this Vector4.</summary>
        public static Vector4 ZZZY(this Vector4 v) => new Vector4(v.Z, v.Z, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZZZZ components of this Vector4.</summary>
        public static Vector4 ZZZZ(this Vector4 v) => new Vector4(v.Z, v.Z, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZZZW components of this Vector4.</summary>
        public static Vector4 ZZZW(this Vector4 v) => new Vector4(v.Z, v.Z, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZZWX components of this Vector4.</summary>
        public static Vector4 ZZWX(this Vector4 v) => new Vector4(v.Z, v.Z, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZZWY components of this Vector4.</summary>
        public static Vector4 ZZWY(this Vector4 v) => new Vector4(v.Z, v.Z, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZZWZ components of this Vector4.</summary>
        public static Vector4 ZZWZ(this Vector4 v) => new Vector4(v.Z, v.Z, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZZWW components of this Vector4.</summary>
        public static Vector4 ZZWW(this Vector4 v) => new Vector4(v.Z, v.Z, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZWXX components of this Vector4.</summary>
        public static Vector4 ZWXX(this Vector4 v) => new Vector4(v.Z, v.W, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZWXY components of this Vector4.</summary>
        public static Vector4 ZWXY(this Vector4 v) => new Vector4(v.Z, v.W, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZWXZ components of this Vector4.</summary>
        public static Vector4 ZWXZ(this Vector4 v) => new Vector4(v.Z, v.W, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZWXW components of this Vector4.</summary>
        public static Vector4 ZWXW(this Vector4 v) => new Vector4(v.Z, v.W, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZWYX components of this Vector4.</summary>
        public static Vector4 ZWYX(this Vector4 v) => new Vector4(v.Z, v.W, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZWYY components of this Vector4.</summary>
        public static Vector4 ZWYY(this Vector4 v) => new Vector4(v.Z, v.W, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZWYZ components of this Vector4.</summary>
        public static Vector4 ZWYZ(this Vector4 v) => new Vector4(v.Z, v.W, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZWYW components of this Vector4.</summary>
        public static Vector4 ZWYW(this Vector4 v) => new Vector4(v.Z, v.W, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZWZX components of this Vector4.</summary>
        public static Vector4 ZWZX(this Vector4 v) => new Vector4(v.Z, v.W, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZWZY components of this Vector4.</summary>
        public static Vector4 ZWZY(this Vector4 v) => new Vector4(v.Z, v.W, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZWZZ components of this Vector4.</summary>
        public static Vector4 ZWZZ(this Vector4 v) => new Vector4(v.Z, v.W, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZWZW components of this Vector4.</summary>
        public static Vector4 ZWZW(this Vector4 v) => new Vector4(v.Z, v.W, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the ZWWX components of this Vector4.</summary>
        public static Vector4 ZWWX(this Vector4 v) => new Vector4(v.Z, v.W, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the ZWWY components of this Vector4.</summary>
        public static Vector4 ZWWY(this Vector4 v) => new Vector4(v.Z, v.W, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the ZWWZ components of this Vector4.</summary>
        public static Vector4 ZWWZ(this Vector4 v) => new Vector4(v.Z, v.W, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the ZWWW components of this Vector4.</summary>
        public static Vector4 ZWWW(this Vector4 v) => new Vector4(v.Z, v.W, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the WXXX components of this Vector4.</summary>
        public static Vector4 WXXX(this Vector4 v) => new Vector4(v.W, v.X, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the WXXY components of this Vector4.</summary>
        public static Vector4 WXXY(this Vector4 v) => new Vector4(v.W, v.X, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WXXZ components of this Vector4.</summary>
        public static Vector4 WXXZ(this Vector4 v) => new Vector4(v.W, v.X, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WXXW components of this Vector4.</summary>
        public static Vector4 WXXW(this Vector4 v) => new Vector4(v.W, v.X, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the WXYX components of this Vector4.</summary>
        public static Vector4 WXYX(this Vector4 v) => new Vector4(v.W, v.X, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the WXYY components of this Vector4.</summary>
        public static Vector4 WXYY(this Vector4 v) => new Vector4(v.W, v.X, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WXYZ components of this Vector4.</summary>
        public static Vector4 WXYZ(this Vector4 v) => new Vector4(v.W, v.X, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WXYW components of this Vector4.</summary>
        public static Vector4 WXYW(this Vector4 v) => new Vector4(v.W, v.X, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the WXZX components of this Vector4.</summary>
        public static Vector4 WXZX(this Vector4 v) => new Vector4(v.W, v.X, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the WXZY components of this Vector4.</summary>
        public static Vector4 WXZY(this Vector4 v) => new Vector4(v.W, v.X, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WXZZ components of this Vector4.</summary>
        public static Vector4 WXZZ(this Vector4 v) => new Vector4(v.W, v.X, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WXZW components of this Vector4.</summary>
        public static Vector4 WXZW(this Vector4 v) => new Vector4(v.W, v.X, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the WXWX components of this Vector4.</summary>
        public static Vector4 WXWX(this Vector4 v) => new Vector4(v.W, v.X, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the WXWY components of this Vector4.</summary>
        public static Vector4 WXWY(this Vector4 v) => new Vector4(v.W, v.X, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WXWZ components of this Vector4.</summary>
        public static Vector4 WXWZ(this Vector4 v) => new Vector4(v.W, v.X, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WXWW components of this Vector4.</summary>
        public static Vector4 WXWW(this Vector4 v) => new Vector4(v.W, v.X, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the WYXX components of this Vector4.</summary>
        public static Vector4 WYXX(this Vector4 v) => new Vector4(v.W, v.Y, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the WYXY components of this Vector4.</summary>
        public static Vector4 WYXY(this Vector4 v) => new Vector4(v.W, v.Y, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WYXZ components of this Vector4.</summary>
        public static Vector4 WYXZ(this Vector4 v) => new Vector4(v.W, v.Y, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WYXW components of this Vector4.</summary>
        public static Vector4 WYXW(this Vector4 v) => new Vector4(v.W, v.Y, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the WYYX components of this Vector4.</summary>
        public static Vector4 WYYX(this Vector4 v) => new Vector4(v.W, v.Y, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the WYYY components of this Vector4.</summary>
        public static Vector4 WYYY(this Vector4 v) => new Vector4(v.W, v.Y, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WYYZ components of this Vector4.</summary>
        public static Vector4 WYYZ(this Vector4 v) => new Vector4(v.W, v.Y, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WYYW components of this Vector4.</summary>
        public static Vector4 WYYW(this Vector4 v) => new Vector4(v.W, v.Y, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the WYZX components of this Vector4.</summary>
        public static Vector4 WYZX(this Vector4 v) => new Vector4(v.W, v.Y, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the WYZY components of this Vector4.</summary>
        public static Vector4 WYZY(this Vector4 v) => new Vector4(v.W, v.Y, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WYZZ components of this Vector4.</summary>
        public static Vector4 WYZZ(this Vector4 v) => new Vector4(v.W, v.Y, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WYZW components of this Vector4.</summary>
        public static Vector4 WYZW(this Vector4 v) => new Vector4(v.W, v.Y, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the WYWX components of this Vector4.</summary>
        public static Vector4 WYWX(this Vector4 v) => new Vector4(v.W, v.Y, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the WYWY components of this Vector4.</summary>
        public static Vector4 WYWY(this Vector4 v) => new Vector4(v.W, v.Y, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WYWZ components of this Vector4.</summary>
        public static Vector4 WYWZ(this Vector4 v) => new Vector4(v.W, v.Y, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WYWW components of this Vector4.</summary>
        public static Vector4 WYWW(this Vector4 v) => new Vector4(v.W, v.Y, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the WZXX components of this Vector4.</summary>
        public static Vector4 WZXX(this Vector4 v) => new Vector4(v.W, v.Z, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the WZXY components of this Vector4.</summary>
        public static Vector4 WZXY(this Vector4 v) => new Vector4(v.W, v.Z, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WZXZ components of this Vector4.</summary>
        public static Vector4 WZXZ(this Vector4 v) => new Vector4(v.W, v.Z, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WZXW components of this Vector4.</summary>
        public static Vector4 WZXW(this Vector4 v) => new Vector4(v.W, v.Z, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the WZYX components of this Vector4.</summary>
        public static Vector4 WZYX(this Vector4 v) => new Vector4(v.W, v.Z, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the WZYY components of this Vector4.</summary>
        public static Vector4 WZYY(this Vector4 v) => new Vector4(v.W, v.Z, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WZYZ components of this Vector4.</summary>
        public static Vector4 WZYZ(this Vector4 v) => new Vector4(v.W, v.Z, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WZYW components of this Vector4.</summary>
        public static Vector4 WZYW(this Vector4 v) => new Vector4(v.W, v.Z, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the WZZX components of this Vector4.</summary>
        public static Vector4 WZZX(this Vector4 v) => new Vector4(v.W, v.Z, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the WZZY components of this Vector4.</summary>
        public static Vector4 WZZY(this Vector4 v) => new Vector4(v.W, v.Z, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WZZZ components of this Vector4.</summary>
        public static Vector4 WZZZ(this Vector4 v) => new Vector4(v.W, v.Z, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WZZW components of this Vector4.</summary>
        public static Vector4 WZZW(this Vector4 v) => new Vector4(v.W, v.Z, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the WZWX components of this Vector4.</summary>
        public static Vector4 WZWX(this Vector4 v) => new Vector4(v.W, v.Z, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the WZWY components of this Vector4.</summary>
        public static Vector4 WZWY(this Vector4 v) => new Vector4(v.W, v.Z, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WZWZ components of this Vector4.</summary>
        public static Vector4 WZWZ(this Vector4 v) => new Vector4(v.W, v.Z, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WZWW components of this Vector4.</summary>
        public static Vector4 WZWW(this Vector4 v) => new Vector4(v.W, v.Z, v.W, v.W);

        /// <summary>Returns a new Vector4 whose components are the WWXX components of this Vector4.</summary>
        public static Vector4 WWXX(this Vector4 v) => new Vector4(v.W, v.W, v.X, v.X);

        /// <summary>Returns a new Vector4 whose components are the WWXY components of this Vector4.</summary>
        public static Vector4 WWXY(this Vector4 v) => new Vector4(v.W, v.W, v.X, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WWXZ components of this Vector4.</summary>
        public static Vector4 WWXZ(this Vector4 v) => new Vector4(v.W, v.W, v.X, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WWXW components of this Vector4.</summary>
        public static Vector4 WWXW(this Vector4 v) => new Vector4(v.W, v.W, v.X, v.W);

        /// <summary>Returns a new Vector4 whose components are the WWYX components of this Vector4.</summary>
        public static Vector4 WWYX(this Vector4 v) => new Vector4(v.W, v.W, v.Y, v.X);

        /// <summary>Returns a new Vector4 whose components are the WWYY components of this Vector4.</summary>
        public static Vector4 WWYY(this Vector4 v) => new Vector4(v.W, v.W, v.Y, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WWYZ components of this Vector4.</summary>
        public static Vector4 WWYZ(this Vector4 v) => new Vector4(v.W, v.W, v.Y, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WWYW components of this Vector4.</summary>
        public static Vector4 WWYW(this Vector4 v) => new Vector4(v.W, v.W, v.Y, v.W);

        /// <summary>Returns a new Vector4 whose components are the WWZX components of this Vector4.</summary>
        public static Vector4 WWZX(this Vector4 v) => new Vector4(v.W, v.W, v.Z, v.X);

        /// <summary>Returns a new Vector4 whose components are the WWZY components of this Vector4.</summary>
        public static Vector4 WWZY(this Vector4 v) => new Vector4(v.W, v.W, v.Z, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WWZZ components of this Vector4.</summary>
        public static Vector4 WWZZ(this Vector4 v) => new Vector4(v.W, v.W, v.Z, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WWZW components of this Vector4.</summary>
        public static Vector4 WWZW(this Vector4 v) => new Vector4(v.W, v.W, v.Z, v.W);

        /// <summary>Returns a new Vector4 whose components are the WWWX components of this Vector4.</summary>
        public static Vector4 WWWX(this Vector4 v) => new Vector4(v.W, v.W, v.W, v.X);

        /// <summary>Returns a new Vector4 whose components are the WWWY components of this Vector4.</summary>
        public static Vector4 WWWY(this Vector4 v) => new Vector4(v.W, v.W, v.W, v.Y);

        /// <summary>Returns a new Vector4 whose components are the WWWZ components of this Vector4.</summary>
        public static Vector4 WWWZ(this Vector4 v) => new Vector4(v.W, v.W, v.W, v.Z);

        /// <summary>Returns a new Vector4 whose components are the WWWW components of this Vector4.</summary>
        public static Vector4 WWWW(this Vector4 v) => new Vector4(v.W, v.W, v.W, v.W);

    }
}