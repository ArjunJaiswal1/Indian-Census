
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
        //List of file paths
        string stateCensusFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndianPopulatio.csv";
        string wrongTypeFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\IndianPopulation.txt";
        string wrongDelimiterFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"F:\BridgeLabz\IndianCensus\IndianCensus\IndianCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        //Object for csv adapter class
        CSVAdapterFactory csv;
        Dictionary<string, CensusDTO> stateRecords;
        //Initializing the objects
        [TestInitialize]
        public void Setup()
        {
            csv = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
        }
        //Test case for returning the total count from census if path is correct(UC1-TC1.1)
        [TestMethod]
        public void GivenStateCsvReturnStateRecords()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
        //Test case for returning the file not found custom exception if path is incorrect(UC1-TC1.2)
        [TestMethod]
        public void GivenWrongFileThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
        }
        //Test case for returning the invalid file type custom exception if file name is same and extension is different(UC1-TC1.3)
        [TestMethod]
        public void GivenWrongFileTypeThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.exception);
        }
        //Test case for returning the incorrect delimeter in data custom exception if path is correct(UC1-TC1.4)
        [TestMethod]
        public void GivenWrongDelimiterThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.exception);
        }
        //Test case for returning the incorrect header custom exception if path is correct(UC1-TC1.5)
        [TestMethod]
        public void GivenWrongeHeaderThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.exception);
        }
    }
}