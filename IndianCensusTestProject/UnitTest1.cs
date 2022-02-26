
using IndiaCensusDataDemo.DTO;
using IndianCensus;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace IndianCensus
{
    [TestClass]
    public class IndianCensusTestProject
    {
        //AAA Methodlogy
        //Arrange
        //List of file paths (UC1)
        string stateCensusFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndianPopulatio.csv";
        string wrongTypeFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndianPopulation.txt";
        string wrongDelimiterFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        //list of file paths (UC2)
        string stateCodeFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndiaStateCodes.csv";
        string wrongStateCodeTypeFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        //Object for csv adapter class
        CSVAdapterFactory csv;
        Dictionary<string, CensusDTO> stateCensusRecords;
        Dictionary<string, CensusDTO> stateCodeRecords;
        //Initializing the objects
        [TestInitialize]
        public void Setup()
        {
            csv = new CSVAdapterFactory();
            stateCensusRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
        }
        //Test case for returning the total count from census and state code if path is correct(UC1-TC1.1 && UC2-TC2.1)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenStateCodeOrCensusCsvReturnRecordsCount()
        {
            stateCensusRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, stateCensusHeaders);
            stateCodeRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeFilePath, stateCodeHeaders);
            Assert.AreEqual(29, stateCensusRecords.Count);
            Assert.AreEqual(37, stateCodeRecords.Count);
        }
        //Test case for returning the file not found custom exception if path is incorrect(UC1-TC1.2 && UC2-TC2.2)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongFileThrowCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateCodeException.exception);
        }
        //Test case for returning the invalid file type custom exception if file name is same and extension is different(UC1-TC1.3 && UC2-TC2.3)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongFileTypeThrowCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.exception);
        }
        //Test case for returning the incorrect delimeter in data custom exception if path is correct(UC1-TC1.4 && UC2-TC2.4)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongDelimiterThrowCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.exception);
        }
        //Test case for returning the incorrect header custom exception if path is correct(UC1-TC1.5  && UC2-TC2.5)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongeHeaderThrowCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.exception);
        }
    }
}