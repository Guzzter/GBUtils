using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GBUtils.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GBUtils.Test.Extension
{
    enum Importance {
	    None,
	    Trivial,
	    Regular,
	    Important,
	    Critical
    }

	[TestClass]
	public class EnumExtensionTest
	{
        [TestMethod]
        public void TestToEnum()
        {
            Assert.AreEqual(Importance.Critical, "Critical".ToEnum<Importance>());
        }

        [TestMethod]
        public void TestToEnumWithDefault()
        {
            Assert.AreEqual(Importance.Critical, "Critical".ToEnum(Importance.None));
            Assert.AreEqual(Importance.None, "DoesNotMatch".ToEnum(Importance.None));
        }
    }
}
