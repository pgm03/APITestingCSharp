using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using APIDemo;
using System.Net;

namespace APITest
{
    [TestClass]
    public class RegressionTests
    {
        public HttpStatusCode statusCode;

        [TestInitialize]
        public void TC1_CreatePet()
        {
            string payload = @"{
              ""id"": 115,
              ""category"": {
                ""id"": 115,
                ""name"": ""beagle""
              },
              ""name"": ""snoopy"",
              ""photoUrls"": [
                ""/images/snoopydog.jpg""
              ],
              ""tags"": [
                {           
                  ""id"": 115,
                  ""name"": ""small beagle""
                }
              ],
              ""status"": ""available""
            }";

            var demo = new Demo<CreatePetDTO>();
            var response = demo.CreateAPet("v2/pet", payload);
            var statusCode = response.statusCode;
            var content = response.content;

            Assert.AreEqual(200, statusCode);
            Assert.AreEqual(115, content.Id);
            Assert.AreEqual(115, content.Category.Id);
            Assert.AreEqual("beagle", content.Category.Name);
            Assert.AreEqual("snoopy", content.Name);
            Assert.AreEqual("/images/snoopydog.jpg", content.PhotoUrls[0]);
            Assert.AreEqual(115, content.Tags[0].Id);
            Assert.AreEqual("small beagle", content.Tags[0].Name);
            Assert.AreEqual("available", content.Status);
        }

        [TestMethod]
        public void TC2_VerifyCreatedPet()
        {
            var demo = new Demo<CreatePetDTO>();
            var response = demo.GetPet("115", "v2/pet/{petId}");
            var statusCode = response.statusCode;
            var content = response.content;

            Assert.AreEqual(200, statusCode);
            Assert.AreEqual(115, content.Id);
            Assert.AreEqual(115, content.Category.Id);
            Assert.AreEqual("beagle", content.Category.Name);
            Assert.AreEqual("snoopy", content.Name);
            Assert.AreEqual("/images/snoopydog.jpg", content.PhotoUrls[0]);
            Assert.AreEqual(115, content.Tags[0].Id);
            Assert.AreEqual("small beagle", content.Tags[0].Name);
            Assert.AreEqual("available", content.Status);
        }

        [TestMethod]
        public void TC3_UpdateCreatedPet()
        {
            string payload = @"{
              ""id"": 115,
              ""category"": {
                ""id"": 115,
                ""name"": ""beagle updated""
              },
              ""name"": ""snoopy updated"",
              ""photoUrls"": [
                ""/images/snoopydogupdated.jpg""
              ],
              ""tags"": [
                {           
                  ""id"": 115,
                  ""name"": ""small beagle updated""
                }
              ],
              ""status"": ""not available""
            }";

            var demo = new Demo<CreatePetDTO>();
            var response = demo.UpdatePet("v2/pet", payload);
            var statusCode = response.statusCode;
            var content = response.content;

            Assert.AreEqual(200, statusCode);
            Assert.AreEqual(115, content.Id);
            Assert.AreEqual(115, content.Category.Id);
            Assert.AreEqual("beagle updated", content.Category.Name);
            Assert.AreEqual("snoopy updated", content.Name);
            Assert.AreEqual("/images/snoopydogupdated.jpg", content.PhotoUrls[0]);
            Assert.AreEqual(115, content.Tags[0].Id);
            Assert.AreEqual("small beagle updated", content.Tags[0].Name);
            Assert.AreEqual("not available", content.Status);
        }

        [TestMethod]
        public void TC4_DeleteNotFound()
        {
            var demo = new Demo<CreatePetDTO>();
            var response = demo.DeletePet("$110", "v2/pet/{petId}");
            var statusCode = response.statusCode;

            Assert.AreEqual(404, statusCode);
        }

        [TestMethod]
        public void TC5_CreateBadRequest()
        {
            string payload = "Text";

            var demo = new Demo<CreatePetDTO>();
            var response = demo.CreateAPet("v2/pet", payload);
            var statusCode = response.statusCode;

            Assert.AreEqual(400, statusCode);
        }

        [TestCleanup]
        public void TC6_DeleteCreatedPet()
        {
            var demo = new Demo<CreatePetDTO>();
            var response = demo.DeletePet("115", "v2/pet/{petId}");
            var statusCode = response.statusCode;

            Assert.AreEqual(200, statusCode);
        }
    }
}
