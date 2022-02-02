using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Unit.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _mockfileReaader;
        private VideoService _service;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp() 
        {
            _mockfileReaader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _service = new VideoService(_mockfileReaader.Object, _videoRepository.Object);
        }
            
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {            
            _mockfileReaader.Setup(x => x.Read("video.txt")).Returns("");
                      
            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>() {
                new Video{Id = 1},
                new Video{Id = 2},
                new Video{Id = 3},
            });

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
