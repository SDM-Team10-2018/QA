using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using SpecflowTests.Utils;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class SpecFlowFeature1Steps : Start
    {
        [Given(@"I have entered happiness levels (.*)")]
        public void GivenIHaveEnteredHappinessLevels(string p0)
        {
            // Click on the desired Individual Emotion
            Driver.driver.FindElement(By.XPath("//img[@id='Ind" + p0 + "']")).Click();
            // Cick on the desired Team Emotion
            Driver.driver.FindElement(By.XPath("//img[@id='Team" + p0 + "']")).Click();
            Thread.Sleep(1000);
        }

        [When(@"I press on the submit button")]
        public void WhenIPressOnTheSubmitButtonVeryHappy()
        {
            //Click on Submit button
            Driver.driver.FindElement(By.XPath("//button[@id='Submit']")).Click();
        }

        [Then(@"the hapiness level information should be submitted")]
        public void ThenTheHapinessLevelInformationShouldBeSubmitted()
        {
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Submit Happiness Level");

            // Setting up the expected result and the actual result
            Thread.Sleep(1000);
            string ActualResult = "Thanks for your help! Your happiness information has been saved. We will remind you for the next notification.";
            string ExpectedResult = Driver.driver.FindElement(By.XPath("//h5[@id='submitted']")).Text;
            Thread.Sleep(500);

            //Check if the expected confirmation is displayed             
            if (ActualResult == ExpectedResult)
            {
                Thread.Sleep(1000);
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "IndividualSubmitted");
            }
            else
            {
                // Display error on failure
                Console.WriteLine("Test Failed");
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
        }

    }
}
