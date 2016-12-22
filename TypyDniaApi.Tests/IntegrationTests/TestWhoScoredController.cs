﻿using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Shared.Model.Requests;
using TypyDniaApi.Controllers;
using TypyDniaApi.Model.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Shared;

namespace TypyDniaApi.Tests.IntegrationTests
{
    [TestClass]
    public class TestWhoScoredController
    {
        private WhoScoredController _controller;
        private Mock<IWhoScoredService> _mockService;
        private string expectedDetailsPath = "chujwamwdupala";
        private string expectedSeasonPath = "gterter";

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IWhoScoredService>();
            _controller = new WhoScoredController(_mockService.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [TestMethod]
        public void TestGetMatchDetails()
        {
            //string expectedMatchDetails = File.ReadAllText(expectedDetailsPath);
            string expectedMatchDetails = EmbeddedData.AsString("matchDetails.txt");

            var testMatchRequest = new MatchRequest();
            testMatchRequest.HomeTeamId = 75;
            testMatchRequest.Date = "30-10-16";

            string actualMatchDetails = _controller.GetMatchDetails(testMatchRequest);

            Assert.AreEqual(expectedMatchDetails, actualMatchDetails);
        }

        [TestMethod]
        public void TestGetSeasonMatches()
        {
            //string expectedSeasonRequests = File.ReadAllText(expectedSeasonPath);
            string expectedSeasonRequests = EmbeddedData.AsString("seasonMatches.txt");

            var testSeasonRequest = new SeasonRequest();
            testSeasonRequest.League = "Serie A";
            testSeasonRequest.Years = "2014/2015";

            string actualSeasonRequests = _controller.GetSeasonMatches(testSeasonRequest);

            Assert.AreEqual(expectedSeasonRequests, actualSeasonRequests);
        }
    }
}
