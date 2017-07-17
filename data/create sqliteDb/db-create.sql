-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.22-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.4.0.5169
-- --------------------------------------------------------

-- Dumping structure for table bib.acl
CREATE TABLE IF NOT EXISTS `acl` (
  `ID` bigint NOT NULL,
  `CanAddMedia` tinyint NOT NULL,
  `CanAddReaders` tinyint NOT NULL,
  `CanAddUsers` tinyint NOT NULL,
  `CanAddUserGroups` tinyint NOT NULL,
  `CanRemoveMedia` tinyint NOT NULL,
  `CanRemoveReaders` tinyint NOT NULL,
  `CanRemoveUsers` tinyint NOT NULL,
  `CanRemoveUserGroups` tinyint NOT NULL,
  `CanModifyMedia` tinyint NOT NULL,
  `CanModifyReaders` tinyint NOT NULL,
  `CanModifyUsers` tinyint NOT NULL,
  `CanModifyUserGroups` tinyint NOT NULL,
  CONSTRAINT acl_PK PRIMARY KEY (`ID`)
);

-- Data exporting was unselected.
-- Dumping structure for table bib.borrow
CREATE TABLE IF NOT EXISTS `borrow` (
  `ID` bigint  NOT NULL,
  `Reader_ID` bigint  NOT NULL,
  `Medium_ID` bigint  NOT NULL,
  `BorrowDate` date NOT NULL,
  `ReturnDate` date DEFAULT NULL,
  CONSTRAINT borrow_PK PRIMARY KEY (`ID`),
  FOREIGN KEY (`Medium_ID`) REFERENCES `medium` (`ID`) ON DELETE CASCADE,
  FOREIGN KEY (`Reader_ID`) REFERENCES `reader` (`ID`) ON DELETE CASCADE
);

-- Data exporting was unselected.
-- Dumping structure for table bib.media_type
CREATE TABLE IF NOT EXISTS `media_type` (
  `ID` bigint  NOT NULL,
  `Name` varchar(50) NOT NULL DEFAULT '0',
  CONSTRAINT media_type_PK PRIMARY KEY (`ID`)
);

-- Data exporting was unselected.
-- Dumping structure for table bib.medium
CREATE TABLE IF NOT EXISTS `medium` (
  `ID` bigint  NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Year` year(4) DEFAULT NULL,
  `ISBN` varchar(50) DEFAULT NULL,
  `Picture` text,
  `Type` bigint  DEFAULT NULL,
  `IsAvailable` tinyint DEFAULT '1',
  `IsDeleted` tinyint DEFAULT '0',
  `DevelopmentPlan` tinyint DEFAULT '-1',
  CONSTRAINT medium_PK PRIMARY KEY (`ID`),
  FOREIGN KEY (`Type`) REFERENCES `media_type` (`ID`)
);

-- Data exporting was unselected.
-- Dumping structure for table bib.reader
CREATE TABLE IF NOT EXISTS `reader` (
  `ID` bigint  NOT NULL ,
  `Card_ID` varchar(100) DEFAULT '0',
  `FirstName` varchar(100) NOT NULL DEFAULT '0',
  `LastName` varchar(100) NOT NULL DEFAULT '0',
  `Phone` varchar(100) DEFAULT '0',
  `Address` varchar(100) DEFAULT '0',
  `IsActive` tinyint  DEFAULT '1',
  CONSTRAINT reader_PK PRIMARY KEY (`ID`)
);

-- Data exporting was unselected.
-- Dumping structure for table bib.user
CREATE TABLE IF NOT EXISTS `user` (
  `ID` bigint NOT NULL ,
  `Group_ID` bigint DEFAULT NULL,
  `ACL_ID` bigint DEFAULT NULL,
  `AccountName` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Password` text NOT NULL,
  `IsActive` tinyint NOT NULL DEFAULT '1',
  CONSTRAINT user_PK PRIMARY KEY (`ID`),
  FOREIGN KEY (`ACL_ID`) REFERENCES `acl` (`ID`),
  FOREIGN KEY (`Group_ID`) REFERENCES `user_group` (`ID`)
);

-- Data exporting was unselected.
-- Dumping structure for table bib.user_group
CREATE TABLE IF NOT EXISTS `user_group` (
  `ID` bigint  NOT NULL ,
  `Name` varchar(50) NOT NULL,
  `ACL_ID` bigint  NOT NULL,
  CONSTRAINT user_group_PK PRIMARY KEY (`ID`),
  FOREIGN KEY (`ACL_ID`) REFERENCES `acl` (`ID`)
);

-- Data exporting was unselected.
-- Dumping structure for table bib.user_settings
CREATE TABLE IF NOT EXISTS `user_settings` (
  `ID` tinyint  NOT NULL ,
  `User_ID` bigint  NOT NULL,
  `Language` tinytext NOT NULL,
  `DateTimeFormat` tinytext NOT NULL,
  `IsActive` tinyint  NOT NULL DEFAULT '1',
  CONSTRAINT user_settings_PK PRIMARY KEY (`ID`),
  FOREIGN KEY (`User_ID`) REFERENCES `user` (`ID`) ON DELETE CASCADE
);