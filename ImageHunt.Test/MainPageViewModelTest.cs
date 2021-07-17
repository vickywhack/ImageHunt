using ImageHunt.Interfaces;
using ImageHunt.Test.Samples;
using ImageHunt.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageHunt.Test
{
    public class MainPageViewModelTest
    {

        private Mock<IToastService> toastService;
        private MainPageViewModel vm;

        [SetUp]
        public void Setup()
        {
            toastService = new Mock<IToastService>();
        }

        [Test]
        public async Task TestSearchResultsAsync()
        {
            //Arrange
            vm = new MainPageViewModel(toastService.Object);

            //Act
            var testResult = await vm.SearchResultsAsync().ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(testResult);
        }

        [TestCaseSource("SampleSerialzed")]
        public void TestGetImages(string input)
        {
            //Arrange
            vm = new MainPageViewModel(toastService.Object);

            //Act
            var testResult = vm.GetImages(input);

            //Assert
            Assert.IsNotNull(testResult);
        }

        [Test]
        public void NegativeTestGetImages()
        {
            //Arrange
            vm = new MainPageViewModel(toastService.Object);

            //Act
            var testResult = vm.GetImages(null);

            //Assert
            Assert.IsNull(testResult);
        }

        //Dynamic TestCase Values
        public static IEnumerable<TestCaseData> SampleSerialzed
        {
            get
            {
                yield return new TestCaseData(new Sample().SampleSerialzed);
            }
        }
    }
}