using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Converters;
using MobileRcp.Core.Models;
using NUnit.Framework;

namespace MobileRcp.CoreTests.Converters
{
    public class UserWorktimeToDisplayConverterTests
    {
        public UserWorktime[] UserWorktime { get; set; }

        public UserWorktimeToDisplayConverterTests()
        {
            UserWorktime = new[] 
            {
                new UserWorktime()
                {
                    UserId = 1,
                    NormalIn = new DateTime(2016,6,1,8,1,0),
                    NormalOut = new DateTime(2016,6,1,16,10,25),
                }
            };
        }

        [Test]
        public void ShouldConvertDay()
        {
            var converter = new UserWorktimeToDisplayConverter();

            var model = converter.Convert(UserWorktime).FirstOrDefault();

            Assert.NotNull(model);
            Assert.AreEqual("01", model.Day);
        }

        [Test]
        public void ShouldConvertNormalIn()
        {
            var converter = new UserWorktimeToDisplayConverter();

            var model = converter.Convert(UserWorktime).FirstOrDefault();

            Assert.NotNull(model);
            Assert.AreEqual("08:01", model.NormalInTime);
        }

        [Test]
        public void ShouldConvertNormalOut()
        {
            var converter = new UserWorktimeToDisplayConverter();

            var model = converter.Convert(UserWorktime).FirstOrDefault();

            Assert.NotNull(model);
            Assert.AreEqual("16:10", model.NormalOutTime);
        }

        [Test]
        public void ShouldConvertAdditionalLeavesIfEmpty()
        {
            var converter = new UserWorktimeToDisplayConverter();

            var model = converter.Convert(UserWorktime).FirstOrDefault();

            Assert.NotNull(model);
            Assert.AreEqual("Nie", model.IsAdditionalsLeaves);
        }

        [Test]
        public void ShouldGetProperWorktime()
        {
            var converter = new UserWorktimeToDisplayConverter();

            var model = converter.Convert(UserWorktime).FirstOrDefault();

            Assert.NotNull(model);
            Assert.AreEqual("08:09", model.Worktime);
        }
    }
}
