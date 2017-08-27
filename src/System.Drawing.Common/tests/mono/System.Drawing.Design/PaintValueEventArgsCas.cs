//
// PaintValueEventArgsCas.cs 
//	- CAS unit tests for System.Drawing.Design.PaintValueEventArgs
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
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
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;

namespace MonoCasTests.System.Drawing.Design {

	[TestFixture]
	[Category ("CAS")]
	public class PaintValueEventArgsCas {

		private ConstructorInfo ctor;

		[TestFixtureSetUp]
		public void FixtureSetUp ()
		{
			// this executes at fulltrust
			ConstructorInfo[] infos = typeof (PaintValueEventArgs).GetConstructors ();
			ctor = infos[0];
		}

		[SetUp]
		public void SetUp ()
		{
			if (!SecurityManager.SecurityEnabled)
				Assert.Ignore ("SecurityManager.SecurityEnabled is OFF");
		}

		[Fact]
		public void Create ()
		{
			Rectangle r = new Rectangle ();
			new PaintValueEventArgs (null, null, Graphics.FromImage (new Bitmap (10, 10)), r);
		}

		// we use reflection to call PaintValueEventArgs class as it's protected 
		// by a  LinkDemand (which will be converted into full demand, i.e. a 
		// stack walk) when reflection is used (i.e. it gets testable).

		[Fact]
		[ExpectedException (typeof (SecurityException))]
		public void Create_LinkDemand ()
		{
			// requires FullTrust, so denying anything break the requirements
			Assert.NotNull (ctor, "constructor");
			ctor.Invoke (new object[4]);
		}
	}
}
