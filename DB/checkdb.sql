-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 24, 2020 at 12:03 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `checkdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_note`
--

CREATE TABLE `tbl_note` (
  `OrderId` int(11) NOT NULL,
  `Note` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_note`
--

INSERT INTO `tbl_note` (`OrderId`, `Note`) VALUES
(1, '12654654');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_ordercargo`
--

CREATE TABLE `tbl_ordercargo` (
  `OrderId` int(10) NOT NULL,
  `Quantity` int(20) NOT NULL,
  `WarehousePlace` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_ordercargo`
--

INSERT INTO `tbl_ordercargo` (`OrderId`, `Quantity`, `WarehousePlace`) VALUES
(1, 20, 'Delhi'),
(2, 20, 'Gurugram');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_shiftcargo`
--

CREATE TABLE `tbl_shiftcargo` (
  `OrderId` int(11) NOT NULL,
  `Place` varchar(80) NOT NULL,
  `QuantityOrdered` int(100) NOT NULL,
  `ShiftTo` varchar(80) NOT NULL,
  `Capacity` int(100) NOT NULL,
  `QuantityInWarehouse` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_shiftcargo`
--

INSERT INTO `tbl_shiftcargo` (`OrderId`, `Place`, `QuantityOrdered`, `ShiftTo`, `Capacity`, `QuantityInWarehouse`) VALUES
(1, 'Gurugram', 15, 'Noida', 20, 800);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `ID` int(11) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`ID`, `UserName`, `Password`) VALUES
(1, 'admin', '111'),
(2, 'Kunal', '111');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_warehous`
--

CREATE TABLE `tbl_warehous` (
  `WareH_Id` int(10) NOT NULL,
  `Place` varchar(100) NOT NULL,
  `SupervisorName` varchar(80) NOT NULL,
  `Capacity` int(10) NOT NULL,
  `MobileNumber` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_warehous`
--

INSERT INTO `tbl_warehous` (`WareH_Id`, `Place`, `SupervisorName`, `Capacity`, `MobileNumber`) VALUES
(101, 'Delhi', 'Amit', 50, '1234567891'),
(102, 'Noida', 'Arun', 450, '1234567891'),
(103, 'Gurugram', 'Amit', 450, '2547891468');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_note`
--
ALTER TABLE `tbl_note`
  ADD PRIMARY KEY (`OrderId`);

--
-- Indexes for table `tbl_ordercargo`
--
ALTER TABLE `tbl_ordercargo`
  ADD PRIMARY KEY (`OrderId`);

--
-- Indexes for table `tbl_shiftcargo`
--
ALTER TABLE `tbl_shiftcargo`
  ADD PRIMARY KEY (`OrderId`);

--
-- Indexes for table `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_warehous`
--
ALTER TABLE `tbl_warehous`
  ADD PRIMARY KEY (`WareH_Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_note`
--
ALTER TABLE `tbl_note`
  MODIFY `OrderId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_ordercargo`
--
ALTER TABLE `tbl_ordercargo`
  MODIFY `OrderId` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_shiftcargo`
--
ALTER TABLE `tbl_shiftcargo`
  MODIFY `OrderId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_warehous`
--
ALTER TABLE `tbl_warehous`
  MODIFY `WareH_Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=104;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
