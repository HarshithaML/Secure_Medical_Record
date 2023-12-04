/*
SQLyog Ultimate v8.55 
MySQL - 5.1.36-community : Database - be57
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`be57` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `be57`;

/*Table structure for table `adminmaster` */

DROP TABLE IF EXISTS `adminmaster`;

CREATE TABLE `adminmaster` (
  `AdminId` int(11) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `departmentmaster` */

DROP TABLE IF EXISTS `departmentmaster`;

CREATE TABLE `departmentmaster` (
  `DeptId` int(11) NOT NULL AUTO_INCREMENT,
  `DeptName` varchar(100) DEFAULT NULL,
  `Description` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`DeptId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `dmrdatahospital` */

DROP TABLE IF EXISTS `dmrdatahospital`;

CREATE TABLE `dmrdatahospital` (
  `DDataId` int(11) NOT NULL AUTO_INCREMENT,
  `DRecordId` int(11) DEFAULT NULL,
  `HospitalId` int(11) DEFAULT NULL,
  `DeptId` int(11) DEFAULT NULL,
  PRIMARY KEY (`DDataId`),
  KEY `FK_DMRDataHospital` (`DRecordId`),
  CONSTRAINT `FK_DMRDataHospital` FOREIGN KEY (`DRecordId`) REFERENCES `drecordmaster` (`DRecordId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `doctormaster` */

DROP TABLE IF EXISTS `doctormaster`;

CREATE TABLE `doctormaster` (
  `DoctorId` int(11) NOT NULL,
  `DeptId` int(11) DEFAULT NULL,
  `DoctorName` varchar(100) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `EmailId` varchar(100) DEFAULT NULL,
  `Address` varchar(400) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`DoctorId`),
  KEY `FK_DoctorMaster` (`DeptId`),
  CONSTRAINT `FK_DoctorMaster` FOREIGN KEY (`DeptId`) REFERENCES `departmentmaster` (`DeptId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `drecordmaster` */

DROP TABLE IF EXISTS `drecordmaster`;

CREATE TABLE `drecordmaster` (
  `DRecordId` int(11) NOT NULL AUTO_INCREMENT,
  `DoctorId` int(11) DEFAULT NULL,
  `DRecordName` varchar(100) DEFAULT NULL,
  `FilePath` varchar(200) DEFAULT NULL,
  `DataKey` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`DRecordId`),
  KEY `FK_DRecordMaster` (`DoctorId`),
  CONSTRAINT `FK_DRecordMaster` FOREIGN KEY (`DoctorId`) REFERENCES `doctormaster` (`DoctorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `hospitalmaster` */

DROP TABLE IF EXISTS `hospitalmaster`;

CREATE TABLE `hospitalmaster` (
  `HospitalId` int(11) NOT NULL,
  `HospitalName` varchar(80) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `ContactPerson` varchar(50) DEFAULT NULL,
  `ContactNo` varchar(10) DEFAULT NULL,
  `Address` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`HospitalId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `mapdoctorhospital` */

DROP TABLE IF EXISTS `mapdoctorhospital`;

CREATE TABLE `mapdoctorhospital` (
  `MPDId` int(11) NOT NULL AUTO_INCREMENT,
  `DoctorId` int(11) DEFAULT NULL,
  `HospitalId` int(11) DEFAULT NULL,
  `DurationTimings` varchar(800) DEFAULT NULL,
  PRIMARY KEY (`MPDId`),
  KEY `FK_MapDoctorHospital` (`HospitalId`),
  CONSTRAINT `FK_MapDoctorHospital` FOREIGN KEY (`HospitalId`) REFERENCES `hospitalmaster` (`HospitalId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Table structure for table `patientclinicalmaster` */

DROP TABLE IF EXISTS `patientclinicalmaster`;

CREATE TABLE `patientclinicalmaster` (
  `PPMId` int(11) NOT NULL AUTO_INCREMENT,
  `PatientId` int(11) DEFAULT NULL,
  `FilePath` varchar(200) DEFAULT NULL,
  `DataKey` varchar(800) DEFAULT NULL,
  PRIMARY KEY (`PPMId`),
  KEY `FK_patientclinicalmaster` (`PatientId`),
  CONSTRAINT `FK_patientclinicalmaster` FOREIGN KEY (`PatientId`) REFERENCES `patientmaster` (`PatientId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `patientmaster` */

DROP TABLE IF EXISTS `patientmaster`;

CREATE TABLE `patientmaster` (
  `PatientId` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `Gender` varchar(10) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `Reason` varchar(800) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `Address` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`PatientId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `patienttreatment` */

DROP TABLE IF EXISTS `patienttreatment`;

CREATE TABLE `patienttreatment` (
  `TId` int(11) NOT NULL AUTO_INCREMENT,
  `PatientId` int(11) DEFAULT NULL,
  `DoctorId` int(11) DEFAULT NULL,
  `ProblemTitle` varchar(200) DEFAULT NULL,
  `FilePath` varchar(200) DEFAULT NULL,
  `TDate` varchar(20) DEFAULT NULL,
  `DataKey` varchar(800) DEFAULT NULL,
  PRIMARY KEY (`TId`),
  KEY `FK_PatientTreatment` (`PatientId`),
  CONSTRAINT `FK_PatientTreatment` FOREIGN KEY (`PatientId`) REFERENCES `patientmaster` (`PatientId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `recordmaster` */

DROP TABLE IF EXISTS `recordmaster`;

CREATE TABLE `recordmaster` (
  `RecordId` int(11) NOT NULL AUTO_INCREMENT,
  `DeptId` int(11) DEFAULT NULL,
  `RecordName` varchar(100) DEFAULT NULL,
  `AccessType` varchar(80) DEFAULT NULL,
  `RecordPath` varchar(500) DEFAULT NULL,
  `DataKey` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RecordId`),
  KEY `FK_recordmaster` (`DeptId`),
  CONSTRAINT `FK_recordmaster` FOREIGN KEY (`DeptId`) REFERENCES `departmentmaster` (`DeptId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `recordrequest` */

DROP TABLE IF EXISTS `recordrequest`;

CREATE TABLE `recordrequest` (
  `ReqId` int(11) NOT NULL AUTO_INCREMENT,
  `RecordId` int(11) DEFAULT NULL,
  `DoctorId` int(11) DEFAULT NULL,
  `AccessKey` varchar(10) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ReqId`),
  KEY `FK_RecordRequest` (`RecordId`),
  CONSTRAINT `FK_RecordRequest` FOREIGN KEY (`RecordId`) REFERENCES `recordmaster` (`RecordId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `requestdocdata` */

DROP TABLE IF EXISTS `requestdocdata`;

CREATE TABLE `requestdocdata` (
  `RDDId` int(11) NOT NULL AUTO_INCREMENT,
  `DRecordId` int(11) DEFAULT NULL,
  `DoctorId` int(11) DEFAULT NULL,
  `AccessKey` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`RDDId`),
  KEY `FK_RequestDocData` (`DRecordId`),
  CONSTRAINT `FK_RequestDocData` FOREIGN KEY (`DRecordId`) REFERENCES `drecordmaster` (`DRecordId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
