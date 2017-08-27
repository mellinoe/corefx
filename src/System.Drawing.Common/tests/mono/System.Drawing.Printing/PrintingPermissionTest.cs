//
// PrintingPermissionTest.cs - NUnit Test Cases for PrintingPermission
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2004-2005 Novell, Inc (http://www.novell.com)
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

using Xunit;
using System;
using System.IO;
using System.Drawing.Printing;
using System.Security;
using System.Security.Permissions;

namespace MonoTests.System.Drawing.Printing {

	[TestFixture]
	public class PrintingPermissionTest {

		static PrintingPermissionLevel[] AllLevel = {
			PrintingPermissionLevel.NoPrinting,
			PrintingPermissionLevel.SafePrinting,
			PrintingPermissionLevel.DefaultPrinting,
			PrintingPermissionLevel.AllPrinting,
		};

		static PrintingPermissionLevel[] AllLevelExceptNoLevel = {
			PrintingPermissionLevel.SafePrinting,
			PrintingPermissionLevel.DefaultPrinting,
			PrintingPermissionLevel.AllPrinting,
		};

		static PrintingPermissionLevel[] AllLevelExceptAllLevel = {
			PrintingPermissionLevel.NoPrinting,
			PrintingPermissionLevel.SafePrinting,
			PrintingPermissionLevel.DefaultPrinting,
		};

		static PrintingPermissionLevel[] AllLevelExceptNoAndAllLevel = {
			PrintingPermissionLevel.SafePrinting,
			PrintingPermissionLevel.DefaultPrinting,
		};

		[Fact]
		public void PermissionState_None ()
		{
			PermissionState ps = PermissionState.None;
			PrintingPermission pp = new PrintingPermission (ps);
			Assert.Equal (PrintingPermissionLevel.NoPrinting, pp.Level, "Level");
			Assert.False (pp.IsUnrestricted (), "IsUnrestricted");

			SecurityElement se = pp.ToXml ();
			// only class and version are present
			Assert.Equal ("NoPrinting", se.Attribute ("Level"), "Xml-Level");
			Assert.Null (se.Children, "Xml-Children");

			PrintingPermission copy = (PrintingPermission)pp.Copy ();
			Assert.False (Object.ReferenceEquals (pp, copy), "ReferenceEquals");
			Assert.Equal (pp.Level, copy.Level, "Level");
			Assert.Equal (pp.IsUnrestricted (), copy.IsUnrestricted (), "IsUnrestricted ()");
		}

		[Fact]
		public void PermissionState_Unrestricted ()
		{
			PermissionState ps = PermissionState.Unrestricted;
			PrintingPermission pp = new PrintingPermission (ps);
			Assert.Equal (PrintingPermissionLevel.AllPrinting, pp.Level, "Level");
			Assert.True (pp.IsUnrestricted (), "IsUnrestricted");

			SecurityElement se = pp.ToXml ();
			// only class and version are present
			Assert.Equal ("true", se.Attribute ("Unrestricted"), "Xml-Unrestricted");
			Assert.Null (se.Children, "Xml-Children");

			PrintingPermission copy = (PrintingPermission)pp.Copy ();
			Assert.False (Object.ReferenceEquals (pp, copy), "ReferenceEquals");
			Assert.Equal (pp.Level, copy.Level, "Level");
			Assert.Equal (pp.IsUnrestricted (), copy.IsUnrestricted (), "IsUnrestricted ()");
		}

		[Fact]
		[ExpectedException (typeof (ArgumentException))]
		public void PermissionState_Bad ()
		{
			PermissionState ps = (PermissionState)77;
			PrintingPermission pp = new PrintingPermission (ps);
		}

		[Fact]
		[ExpectedException (typeof (ArgumentException))]
		public void PrintingPermissionLevels_Bad ()
		{
			PrintingPermissionLevel ppl = (PrintingPermissionLevel)(PrintingPermissionLevel.AllPrinting + 1);
			PrintingPermission pp = new PrintingPermission (ppl);
		}

		[Fact]
		[ExpectedException (typeof (ArgumentException))]
		public void Level_PrintingPermissionLevels_Bad ()
		{
			PrintingPermissionLevel ppl = (PrintingPermissionLevel)(PrintingPermissionLevel.AllPrinting + 1);
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			pp.Level = ppl;
		}

		[Fact]
		public void Copy ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				pp.Level = ppl;
				PrintingPermission copy = (PrintingPermission)pp.Copy ();
				Assert.Equal (ppl, copy.Level, ppl.ToString ());
			}
		}

		[Fact]
		public void Intersect_Null ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			// No intersection with null
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				pp.Level = ppl;
				Assert.Null (pp.Intersect (null), ppl.ToString ());
			}
		}

		[Fact]
		public void Intersect_None ()
		{
			PrintingPermission sp1 = new PrintingPermission (PermissionState.None);
			PrintingPermission sp2 = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				sp2.Level = ppl;
				// 1. Intersect None with ppl
				PrintingPermission result = (PrintingPermission)sp1.Intersect (sp2);
				Assert.Null (result, "None N " + ppl.ToString ());
				// 2. Intersect ppl with None
				result = (PrintingPermission)sp2.Intersect (sp1);
				Assert.Null (result, "None N " + ppl.ToString ());
			}
		}

		[Fact]
		public void Intersect_Self ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				pp.Level = ppl;
				PrintingPermission result = (PrintingPermission)pp.Intersect (pp);
				Assert.Equal (ppl, result.Level, ppl.ToString ());
			}
		}

		[Fact]
		public void Intersect_Unrestricted ()
		{
			// Intersection with unrestricted == Copy
			// a. source (this) is unrestricted
			PrintingPermission sp1 = new PrintingPermission (PermissionState.Unrestricted);
			PrintingPermission sp2 = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				sp2.Level = ppl;
				PrintingPermission result = (PrintingPermission)sp1.Intersect (sp2);
				Assert.Equal (sp2.Level, result.Level, "target " + ppl.ToString ());
			}
			// b. destination (target) is unrestricted
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				sp2.Level = ppl;
				PrintingPermission result = (PrintingPermission)sp2.Intersect (sp1);
				Assert.Equal (sp2.Level, result.Level, "source " + ppl.ToString ());
			}
			// exceptions for NoLevel
			sp2.Level = PrintingPermissionLevel.NoPrinting;
			Assert.Null (sp1.Intersect (sp2), "target NoLevel");
			Assert.Null (sp2.Intersect (sp1), "source NoLevel");
		}

		[Fact]
		public void IsSubset_Null ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			Assert.True (pp.IsSubsetOf (null), "NoLevel");
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				pp.Level = ppl;
				Assert.False (pp.IsSubsetOf (null), ppl.ToString ());
			}
		}

		[Fact]
		public void IsSubset_None ()
		{
			// IsSubset with none
			// a. source (this) is none -> target is never a subset
			PrintingPermission sp1 = new PrintingPermission (PermissionState.None);
			PrintingPermission sp2 = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				sp2.Level = ppl;
				Assert.True (sp1.IsSubsetOf (sp2), "target " + ppl.ToString ());
			}
			// b. destination (target) is none -> target is always a subset
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				sp2.Level = ppl;
				Assert.False (sp2.IsSubsetOf (sp1), "source " + ppl.ToString ());
			}
			// exception of NoLevel
			sp2.Level = PrintingPermissionLevel.NoPrinting;
			Assert.True (sp2.IsSubsetOf (sp1), "source NoLevel");
		}

		[Fact]
		public void IsSubset_Self ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				pp.Level = ppl;
				PrintingPermission result = (PrintingPermission)pp.Intersect (pp);
				Assert.True (pp.IsSubsetOf (pp), ppl.ToString ());
			}
		}

		[Fact]
		public void IsSubset_Unrestricted ()
		{
			// IsSubset with unrestricted
			// a. source (this) is unrestricted -> target is never a subset
			PrintingPermission sp1 = new PrintingPermission (PermissionState.Unrestricted);
			PrintingPermission sp2 = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevelExceptAllLevel) {
				sp2.Level = ppl;
				Assert.False (sp1.IsSubsetOf (sp2), "target " + ppl.ToString ());
			}
			// exception of AllLevel
			sp2.Level = PrintingPermissionLevel.AllPrinting;
			Assert.True (sp1.IsSubsetOf (sp2), "target AllLevel");
			// b. destination (target) is unrestricted -> target is always a subset
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				sp2.Level = ppl;
				Assert.True (sp2.IsSubsetOf (sp1), "source " + ppl.ToString ());
			}
		}

		[Fact]
		public void Union_Null ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			// Union with null is a simple copy
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				pp.Level = ppl;
				PrintingPermission union = (PrintingPermission)pp.Union (null);
				Assert.Equal (ppl, union.Level, ppl.ToString ());
			}
		}

		[Fact]
		public void Union_None ()
		{
			// Union with none is same
			PrintingPermission pp1 = new PrintingPermission (PermissionState.None);
			PrintingPermission pp2 = new PrintingPermission (PermissionState.None);
			PrintingPermission union = null;

			// a. source (this) is none
			pp2.Level = PrintingPermissionLevel.NoPrinting;
			union = (PrintingPermission)pp1.Union (pp2);
			Assert.Null (union, "target NoPrinting");
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoAndAllLevel) {
				pp2.Level = ppl;
				union = (PrintingPermission)pp1.Union (pp2);
				Assert.False (union.IsUnrestricted (), "target " + ppl.ToString ());
			}
			pp2.Level = PrintingPermissionLevel.AllPrinting;
			union = (PrintingPermission)pp1.Union (pp2);
			Assert.True (union.IsUnrestricted (), "target AllPrinting");

			// b. destination (target) is none
			pp2.Level = PrintingPermissionLevel.NoPrinting;
			union = (PrintingPermission)pp2.Union (pp1);
			Assert.Null (union, "source NoPrinting");
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoAndAllLevel) {
				pp2.Level = ppl;
				union = (PrintingPermission)pp2.Union (pp1);
				Assert.False (union.IsUnrestricted (), "source " + ppl.ToString ());
			}
			pp2.Level = PrintingPermissionLevel.AllPrinting;
			union = (PrintingPermission)pp2.Union (pp1);
			Assert.True (union.IsUnrestricted (), "source AllPrinting");
		}

		[Fact]
		public void Union_Self ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			foreach (PrintingPermissionLevel ppl in AllLevelExceptNoLevel) {
				pp.Level = ppl;
				PrintingPermission result = (PrintingPermission)pp.Union (pp);
				Assert.Equal (ppl, result.Level, ppl.ToString ());
			}
			// union of NoPrinting with NoPrinting == null
			pp.Level = PrintingPermissionLevel.NoPrinting;
			Assert.Null (pp.Union (pp), "NoPrinting");
		}

		[Fact]
		public void Union_Unrestricted ()
		{
			// Union with unrestricted is unrestricted
			PrintingPermission sp1 = new PrintingPermission (PermissionState.Unrestricted);
			PrintingPermission sp2 = new PrintingPermission (PermissionState.None);
			// a. source (this) is unrestricted
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				sp2.Level = ppl;
				PrintingPermission union = (PrintingPermission)sp1.Union (sp2);
				Assert.True (union.IsUnrestricted (), "target " + ppl.ToString ());
			}
			// b. destination (target) is unrestricted
			foreach (PrintingPermissionLevel ppl in AllLevel) {
				sp2.Level = ppl;
				PrintingPermission union = (PrintingPermission)sp2.Union (sp1);
				Assert.True (union.IsUnrestricted (), "source " + ppl.ToString ());
			}
		}

		[Fact]
		[ExpectedException (typeof (ArgumentNullException))]
		public void FromXml_Null ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			pp.FromXml (null);
		}

		[Fact]
		public void FromXml_WrongTag ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			SecurityElement se = pp.ToXml ();
			se.Tag = "IMono";
			pp.FromXml (se);
			// note: normally IPermission classes (in corlib) DO care about the
			// IPermission tag
		}

		[Fact]
		public void FromXml_WrongTagCase ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			SecurityElement se = pp.ToXml ();
			se.Tag = "IPERMISSION"; // instead of IPermission
			pp.FromXml (se);
			// note: normally IPermission classes (in corlib) DO care about the
			// IPermission tag
		}

		[Fact]
		public void FromXml_WrongClass ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			SecurityElement se = pp.ToXml ();

			SecurityElement w = new SecurityElement (se.Tag);
			w.AddAttribute ("class", "Wrong" + se.Attribute ("class"));
			w.AddAttribute ("version", se.Attribute ("version"));
			pp.FromXml (w);
			// doesn't care of the class name at that stage
			// anyway the class has already be created so...
		}

		[Fact]
		[ExpectedException (typeof (ArgumentException))]
		public void FromXml_NoClass ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			SecurityElement se = pp.ToXml ();

			SecurityElement w = new SecurityElement (se.Tag);
			w.AddAttribute ("version", se.Attribute ("version"));
			pp.FromXml (w);
			// note: normally IPermission classes (in corlib) DO NOT care about
			// attribute "class" name presence in the XML
		}

		[Fact]
		[ExpectedException (typeof (ArgumentException))]
		public void FromXml_WrongVersion ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			SecurityElement se = pp.ToXml ();
			se.Attributes.Remove ("version");
			se.Attributes.Add ("version", "2");
			pp.FromXml (se);
		}

		[Fact]
		public void FromXml_NoVersion ()
		{
			PrintingPermission pp = new PrintingPermission (PermissionState.None);
			SecurityElement se = pp.ToXml ();

			SecurityElement w = new SecurityElement (se.Tag);
			w.AddAttribute ("class", se.Attribute ("class"));
			pp.FromXml (w);
		}

		// Unification tests (with the MS final key)
		// note: corlib already test the ECMA key support for unification
		private const string PermissionPattern = "<PermissionSet class=\"System.Security.PermissionSet\" version=\"1\"><IPermission class=\"System.Drawing.Printing.PrintingPermission, System.Drawing, Version={0}, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a\" version=\"1\" Level=\"NoPrinting\"/></PermissionSet>";
		private const string fx10version = "1.0.3300.0";
		private const string fx11version = "1.0.5000.0";
		private const string fx20version = "2.0.0.0";

		private void Unification (string xml)
		{
			PermissionSetAttribute psa = new PermissionSetAttribute (SecurityAction.Assert);
			psa.XML = xml;
			string pset = psa.CreatePermissionSet ().ToString ();
			string currentVersion = typeof (string).Assembly.GetName ().Version.ToString ();
			Assert.True ((pset.IndexOf (currentVersion) > 0), currentVersion);
		}

		[Fact]
		public void Unification_FromFx10 ()
		{
			Unification (String.Format (PermissionPattern, fx10version));
		}

		[Fact]
		public void Unification_FromFx11 ()
		{
			Unification (String.Format (PermissionPattern, fx11version));
		}

		[Fact]
		public void Unification_FromFx20 ()
		{
			Unification (String.Format (PermissionPattern, fx20version));
		}

		[Fact]
		[Category ("NotWorking")]
		[ExpectedException (typeof (FileLoadException))]
		public void Unification_FromFx99 ()
		{
			Type.GetType (String.Format (PermissionPattern, "9.99.999.9999"));
		}
	}
}
