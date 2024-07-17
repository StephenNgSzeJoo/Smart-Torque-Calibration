CREATE SCHEMA IF NOT EXISTS `cal`;

CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(140) DEFAULT NULL,
  `Company` varchar(140) DEFAULT NULL,
  `Password` varchar(140) DEFAULT NULL,
  `UserNT` varchar(140) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `UserNameIndex` (`Username`)
) ;

CREATE TABLE `caldata` (
  `FormID` varchar(255) NOT NULL,
  `EquipID` varchar(255) DEFAULT NULL,
  `TorqCalID` varchar(255) DEFAULT NULL,
  `TorqSet` decimal(10,0) DEFAULT NULL,
  `StartCalDate` datetime DEFAULT NULL,
  `Location` varchar(255) DEFAULT NULL,
  `DoneBy` varchar(140) DEFAULT NULL,
  `TrackingID` VARCHAR(255) DEFAULT NULL,
  `Complete` int DEFAULT 0,
  `Submitted` int DEFAULT 0,
  PRIMARY KEY (`FormID`),
  KEY `DoneBy` (`DoneBy`),
  CONSTRAINT `caldata_ibfk_1` FOREIGN KEY (`DoneBy`) REFERENCES `users` (`Username`)
);

CREATE TABLE `readdata` (
  `ReadIndex` int NOT NULL AUTO_INCREMENT,
  `FormID` varchar(50) DEFAULT NULL,
  `ReadVal` decimal(10,2) DEFAULT NULL,
  `Deviation` decimal(10,2) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `DesVal` decimal(10,2) DEFAULT NULL,
  `IsPreCal` int DEFAULT NULL,
  `TrackingID` VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (`ReadIndex`),
  KEY `FormID` (`FormID`),
  CONSTRAINT `readdata_ibfk_1` FOREIGN KEY (`FormID`) REFERENCES `caldata` (`FormID`)
);

CREATE TABLE `torq_threshold` (
  `UserTorqId` int NOT NULL AUTO_INCREMENT,
  `PreCal` double DEFAULT NULL,
  `Postcal` double DEFAULT NULL,
  `LastUpdated` datetime DEFAULT NULL,
  `DoneBy` varchar(140) DEFAULT NULL,
  `TrackingID` VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (`UserTorqId`),
  KEY `DoneBy` (`DoneBy`),
  CONSTRAINT `torq_threshold_ibfk_1` FOREIGN KEY (`DoneBy`) REFERENCES `users` (`Username`)
);

CREATE TABLE `torqequip` (
  `Index` int NOT NULL AUTO_INCREMENT,
  `TorqCalID` varchar(255) DEFAULT NULL,
  `TorqCalDesc` varchar(255) DEFAULT NULL,
  `TrackingID` VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (`Index`)
);

CREATE TABLE tracking_source (
    `EquipmentID` VARCHAR(255),
    `ModelID` VARCHAR(255),
    `SerialNumber` VARCHAR(255),
    `ServiceID` VARCHAR(255),
    `PL` VARCHAR(255),
    `Dept` VARCHAR(255),
    `DueDate` DATE,
    `TrackingID` VARCHAR(255),
    `TorqueSet` decimal(10,0) DEFAULT NULL,
    `Status` VARCHAR(255) DEFAULT 'NOT STARTED',
	`SapphireFormID` VARCHAR(255) DEFAULT NULL
);


