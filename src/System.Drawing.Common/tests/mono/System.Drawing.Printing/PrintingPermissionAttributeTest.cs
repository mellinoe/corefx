//
// PrintingPermissionAttributeTest.cs -
//	NUnit Test Cases for PrintingPermissionAttribute
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
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
using System.Drawing.Printing;
using System.Security;
using System.Security.Permissions;

namespace MonoTests.System.Drawing.Printing {

	[TestFixture]
	public class PrintingPermissionAttributeTest {

		[Fact]
		public void Default ()
		{
			PrintingPermissionAttribute a = new PrintingPermissionAttribute (SecurityAction.Assert);
			Assert.Equal (a.ToString (), a.TypeId.ToString (), "TypeId");
			Assert.False (a.Unrestricted, "Unrestricted");
			Assert.Equal (PrintingPermissionLevel.NoPrinting, a.Level, "PrintingPermissionLevel");

			PrintingPermission sp = (PrintingPermission)a.CreatePermission ();
			Assert.False (sp.IsUnrestricted (), "IsUnrestricted");
		}

		[Fact]
		public void Action ()
		{
			PrintingPermissionAttribute a = new PrintingPermissionAttribute (SecurityAction.Assert);
			Assert.Equal (SecurityAction.Assert, a.Action, "Action=Assert");
			a.Action = SecurityAction.Demand;
			Assert.Equal (SecurityAction.Demand, a.Action, "Action=Demand");
			a.Action = SecurityAction.Deny;
			Assert.Equal (SecurityAction.Deny, a.Action, "Action=Deny");
			a.Action = SecurityAction.InheritanceDemand;
			Assert.Equal (SecurityAction.InheritanceDemand, a.Action, "Action=InheritanceDemand");
			a.Action = SecurityAction.LinkDemand;
			Assert.Equal (SecurityAction.LinkDemand, a.Action, "Action=LinkDemand");
			a.Action = SecurityAction.PermitOnly;
			Assert.Equal (SecurityAction.PermitOnly, a.Action, "Action=PermitOnly");
			a.Action = SecurityAction.RequestMinimum;
			Assert.Equal (SecurityAction.RequestMinimum, a.Action, "Action=RequestMinimum");
			a.Action = SecurityAction.RequestOptional;
			Assert.Equal (SecurityAction.RequestOptional, a.Action, "Action=RequestOptional");
			a.Action = SecurityAction.RequestRefuse;
			Assert.Equal (SecurityAction.RequestRefuse, a.Action, "Action=RequestRefuse");
		}

		[Fact]
		public void Action_Invalid ()
		{
			PrintingPermissionAttribute a = new PrintingPermissionAttribute ((SecurityAction)Int32.MinValue);
			// no validation in attribute
		}

		[Fact]
		public void Unrestricted ()
		{
			PrintingPermissionAttribute a = new PrintingPermissionAttribute (SecurityAction.Assert);
			a.Unrestricted = true;
			PrintingPermission wp = (PrintingPermission)a.CreatePermission ();
			Assert.True (wp.IsUnrestricted (), "IsUnrestricted");
			Assert.Equal (PrintingPermissionLevel.NoPrinting, a.Level, "NoPrinting");

			a.Unrestricted = false;
			wp = (PrintingPermission)a.CreatePermission ();
			Assert.False (wp.IsUnrestricted (), "!IsUnrestricted");
		}

		[Fact]
		public void Level ()
		{
			PrintingPermissionAttribute a = new PrintingPermissionAttribute (SecurityAction.Assert);
			a.Level = PrintingPermissionLevel.NoPrinting;
			Assert.Equal (PrintingPermissionLevel.NoPrinting, a.Level, "NoPrinting");
			a.Level = PrintingPermissionLevel.SafePrinting;
			Assert.Equal (PrintingPermissionLevel.SafePrinting, a.Level, "SafePrinting");
			a.Level = PrintingPermissionLevel.DefaultPrinting;
			Assert.Equal (PrintingPermissionLevel.DefaultPrinting, a.Level, "DefaultPrintin.");
			a.Level = PrintingPermissionLevel.AllPrinting;
			Assert.Equal (PrintingPermissionLevel.AllPrinting, a.Level, "AllPrinting");
		}

		[Fact]
		[ExpectedException (typeof (ArgumentException))]
		public void Level_Invalid ()
		{
			PrintingPermissionAttribute a = new PrintingPermissionAttribute (SecurityAction.Assert);
			a.Level = (PrintingPermissionLevel) Int32.MinValue;
		}

		[Fact]
		public void Attributes ()
		{
			Type t = typeof (PrintingPermissionAttribute);
			Assert.False (t.IsSerializable, "IsSerializable");

			object [] attrs = t.GetCustomAttributes (typeof (AttributeUsageAttribute), false);
			Assert.Equal (1, attrs.Length, "AttributeUsage");
			AttributeUsageAttribute aua = (AttributeUsageAttribute)attrs [0];
			Assert.True (aua.AllowMultiple, "AllowMultiple");
			Assert.True (aua.Inherited, "Inherited");
			AttributeTargets at = AttributeTargets.All;
			Assert.Equal (at, aua.ValidOn, "ValidOn");
		}
	}
}
