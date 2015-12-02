using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VejleSygehus2.Models;
using VejleSygehus2.Service;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        Article _testarticle = new Article() { Body="BodyTest1", Header = "HeaderTest1", Id=1};
        JsonService _jsonservice = new JsonService();

        [TestMethod]
        public void CreateJsonTest()
        {
            string filename = "testjson";
            string path = _jsonservice.CreateJson(_testarticle, filename);
            _testarticle.Path = path;

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void DeleteJsonTest()
        {
            #region createjson
            string filename = "testjson";
            string path = _jsonservice.CreateJson(_testarticle, filename);
            _testarticle.Path = path;
            #endregion

            _jsonservice.DeleteJson(_testarticle);

            Assert.IsFalse(File.Exists(path));
        }

        [TestMethod]
        public void LoadJsonTest()
        {
            #region createjson
            string filename = "testjson";
            string path = _jsonservice.CreateJson(_testarticle, filename);
            _testarticle.Path = path;
            #endregion

            Article actualarticle = _jsonservice.LoadJson(_testarticle.Path);

            Assert.AreSame(_testarticle.Body, actualarticle.Body);

        }

        [TestMethod]
        public void EditJsonTest()
        {
            #region createjson
            string filename = "testjson";
            string path = _jsonservice.CreateJson(_testarticle, filename);
            _testarticle.Path = path;
            #endregion

            _testarticle.Body = "BodyTest1Edit";
            _testarticle.Header = "HeaderTest1Edit";
            _jsonservice.EditJson(_testarticle);

            Article actualarticle = _jsonservice.LoadJson(_testarticle.Path);

            Debug.WriteLine(path);

            Assert.AreSame(_testarticle.Body, actualarticle.Body);
            Assert.AreSame(_testarticle.Header, actualarticle.Header);
        }
    }
}
