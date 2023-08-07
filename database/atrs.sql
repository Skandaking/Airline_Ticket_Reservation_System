-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 14, 2023 at 10:26 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `atrs`
--

-- --------------------------------------------------------

--
-- Table structure for table `aircraft`
--

CREATE TABLE `aircraft` (
  `Aircraft_ID` varchar(35) NOT NULL,
  `Aircraft_Name` varchar(35) DEFAULT NULL,
  `Airline` varchar(55) DEFAULT NULL,
  `Capacity` int(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `aircraft`
--

INSERT INTO `aircraft` (`Aircraft_ID`, `Aircraft_Name`, `Airline`, `Capacity`) VALUES
('D001', 'DR764', 'Drake Airways', 50),
('ET001', 'Boeing-220', 'Ethiopian Airways', 44),
('ET002', 'Boeing-704-002', 'Ethiopian Airways', 50),
('ET003', 'Boeing-12-137', 'Ethiopian Airways', 50),
('k001', 'K3456', 'Kenyan Airways', 60),
('MWI001', 'Boeing-123-445', 'Malawian Airways', 50),
('SA001', 'Boeing-221', 'South African Airways', 40);

-- --------------------------------------------------------

--
-- Table structure for table `fairs`
--

CREATE TABLE `fairs` (
  `Fair_ID` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Economy` int(35) DEFAULT NULL,
  `First_Class` int(35) DEFAULT NULL,
  `Business` int(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `flightreservation`
--

CREATE TABLE `flightreservation` (
  `ID` int(35) NOT NULL,
  `Reservation_Ref` varchar(35) DEFAULT NULL,
  `Flight_ID` varchar(35) DEFAULT NULL,
  `Class` varchar(35) DEFAULT NULL,
  `Seat_No` varchar(35) DEFAULT NULL,
  `Cost` int(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `flightreservation`
--

INSERT INTO `flightreservation` (`ID`, `Reservation_Ref`, `Flight_ID`, `Class`, `Seat_No`, `Cost`) VALUES
(6, 'hehede', '004', 'Business', '1', 200),
(7, 'hehede', '004', 'First Class', '2', 200),
(9, '1234', '004', 'Business', '11', 400),
(10, '1234', '004', 'First Class', '3', 400),
(11, 'holiday', '004', 'First Class', '36', 400),
(12, 'holiday', '004', 'Business', '4', 400),
(13, 'sc200', '004', 'First Class', '12', 300000),
(14, 'sc200', '004', 'Business', '14', 300000);

-- --------------------------------------------------------

--
-- Table structure for table `flightsschedules`
--

CREATE TABLE `flightsschedules` (
  `Flight_ID` varchar(35) NOT NULL,
  `Aircraft_ID` varchar(35) DEFAULT NULL,
  `Origin` varchar(35) DEFAULT NULL,
  `Destination` varchar(55) DEFAULT NULL,
  `Depart_Time` varchar(55) DEFAULT NULL,
  `Arrive_Time` varchar(55) DEFAULT NULL,
  `Date` varchar(35) DEFAULT NULL,
  `Status` varchar(55) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `flightsschedules`
--

INSERT INTO `flightsschedules` (`Flight_ID`, `Aircraft_ID`, `Origin`, `Destination`, `Depart_Time`, `Arrive_Time`, `Date`, `Status`) VALUES
('002', 'ET003', 'New York', 'LA', '19:54:44', '22:30:44', '10/02/2023', 'departed'),
('003', 'ET002', 'Blantyre', 'cape town', '20:57:19', '23:57:19', '16/02/2023', 'Active'),
('004', 'MWI001', 'lilogwe', 'kenya', '15:35:40', '22:35:40', '22/03/2023', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `flight_002_seats`
--

CREATE TABLE `flight_002_seats` (
  `Seat_No` int(11) NOT NULL,
  `Flight_ID` varchar(255) DEFAULT NULL,
  `Seat_Status` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `flight_002_seats`
--

INSERT INTO `flight_002_seats` (`Seat_No`, `Flight_ID`, `Seat_Status`) VALUES
(1, '002', 'Available'),
(2, '002', 'Available'),
(3, '002', 'Available'),
(4, '002', 'Available'),
(5, '002', 'Available'),
(6, '002', 'Available'),
(7, '002', 'Available'),
(8, '002', 'Available'),
(9, '002', 'Available'),
(10, '002', 'Available'),
(11, '002', 'Available'),
(12, '002', 'Available'),
(13, '002', 'Available'),
(14, '002', 'Available'),
(15, '002', 'Available'),
(16, '002', 'Available'),
(17, '002', 'Available'),
(18, '002', 'Available'),
(19, '002', 'Available'),
(20, '002', 'Available'),
(21, '002', 'Available'),
(22, '002', 'Available'),
(23, '002', 'Available'),
(24, '002', 'Available'),
(25, '002', 'Available'),
(26, '002', 'Available'),
(27, '002', 'Available'),
(28, '002', 'Available'),
(29, '002', 'Available'),
(30, '002', 'Available'),
(31, '002', 'Available'),
(32, '002', 'Available'),
(33, '002', 'Available'),
(34, '002', 'Available'),
(35, '002', 'Available'),
(36, '002', 'Available'),
(37, '002', 'Available'),
(38, '002', 'Available'),
(39, '002', 'Available'),
(40, '002', 'Available'),
(41, '002', 'Available'),
(42, '002', 'Available'),
(43, '002', 'Available'),
(44, '002', 'Available'),
(45, '002', 'Available'),
(46, '002', 'Available'),
(47, '002', 'Available'),
(48, '002', 'Available'),
(49, '002', 'Available'),
(50, '002', 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `flight_003_seats`
--

CREATE TABLE `flight_003_seats` (
  `Seat_No` int(11) NOT NULL,
  `Flight_ID` varchar(255) DEFAULT NULL,
  `Seat_Status` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `flight_003_seats`
--

INSERT INTO `flight_003_seats` (`Seat_No`, `Flight_ID`, `Seat_Status`) VALUES
(4, '003', 'Occupied'),
(5, '003', 'Occupied'),
(6, '003', 'Occupied');

-- --------------------------------------------------------

--
-- Table structure for table `flight_004_seats`
--

CREATE TABLE `flight_004_seats` (
  `Seat_No` int(11) NOT NULL,
  `Flight_ID` varchar(255) DEFAULT NULL,
  `Seat_Status` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `flight_004_seats`
--

INSERT INTO `flight_004_seats` (`Seat_No`, `Flight_ID`, `Seat_Status`) VALUES
(1, '004', 'Occupied'),
(2, '004', 'Occupied'),
(3, '004', 'Occupied'),
(4, '004', 'Occupied'),
(5, '004', 'Available'),
(6, '004', 'Available'),
(7, '004', 'Available'),
(8, '004', 'Available'),
(9, '004', 'Available'),
(10, '004', 'Available'),
(11, '004', 'Occupied'),
(12, '004', 'Occupied'),
(13, '004', 'Available'),
(14, '004', 'Occupied'),
(15, '004', 'Available'),
(16, '004', 'Available'),
(17, '004', 'Available'),
(18, '004', 'Available'),
(19, '004', 'Available'),
(20, '004', 'Available'),
(21, '004', 'Available'),
(22, '004', 'Available'),
(23, '004', 'Available'),
(24, '004', 'Available'),
(25, '004', 'Available'),
(26, '004', 'Available'),
(27, '004', 'Available'),
(28, '004', 'Available'),
(29, '004', 'Available'),
(30, '004', 'Available'),
(31, '004', 'Available'),
(32, '004', 'Available'),
(33, '004', 'Available'),
(34, '004', 'Available'),
(35, '004', 'Available'),
(36, '004', 'Occupied'),
(37, '004', 'Available'),
(38, '004', 'Available'),
(39, '004', 'Available'),
(40, '004', 'Available'),
(41, '004', 'Available'),
(42, '004', 'Available'),
(43, '004', 'Available'),
(44, '004', 'Available'),
(45, '004', 'Available'),
(46, '004', 'Available'),
(47, '004', 'Available'),
(48, '004', 'Available'),
(49, '004', 'Available'),
(50, '004', 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `help`
--

CREATE TABLE `help` (
  `ID` int(11) NOT NULL,
  `Tittle` varchar(100) NOT NULL,
  `Text` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `help`
--

INSERT INTO `help` (`ID`, `Tittle`, `Text`) VALUES
(1, 'How to Reserve a Flight', 'First, go to schedules and right click on a target flight then select reserve flight. choose the rou'),
(2, 'View Reservation', 'click on reservation, then go to manage reservations'),
(3, 'Cancel Reservation', 'go to reservation, right click on the target, choose cancel reservation'),
(4, 'Send Email', 'go to mail, select the customer you want send to, add message, add an attachments if needed '),
(5, 'Print Reports', 'go to reports, enter the date range, then click where there is a printer'),
(6, 'Add New User', 'more to come'),
(7, 'View Customer Details', 'more to come'),
(8, 'View intinerary', 'more to come'),
(9, 'Logout of the System', 'more'),
(10, 'Add Aircraft', 'more');

-- --------------------------------------------------------

--
-- Table structure for table `passengers`
--

CREATE TABLE `passengers` (
  `Passenger_ID` int(35) NOT NULL,
  `Passenger_Name` varchar(35) DEFAULT NULL,
  `Gender` varchar(35) DEFAULT NULL,
  `Age_Range` varchar(35) DEFAULT NULL,
  `Phone_NO` varchar(35) DEFAULT NULL,
  `Address` varchar(55) DEFAULT NULL,
  `Email` varchar(35) DEFAULT NULL,
  `DOB` varchar(35) DEFAULT NULL,
  `Username` varchar(35) DEFAULT NULL,
  `Password` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `passengers`
--

INSERT INTO `passengers` (`Passenger_ID`, `Passenger_Name`, `Gender`, `Age_Range`, `Phone_NO`, `Address`, `Email`, `DOB`, `Username`, `Password`) VALUES
(1, 'Gomez Kaunda', 'Male', 'Adult', '0880291811', 'guliver, lilongwe', 'a.skanda265@gmail.com', '23/05/1995', 'gomez', '1234'),
(2, 'king kaunda', 'male', 'Adult', '0880291811', '6miles', 'walco265@gmail.com', '23/05/1995', 'king', '1234'),
(3, 'Skanda king', 'Male', 'Child', '0983008016', 'nyambadye, Blantyre', 'a.skanda265@gmail.com', '28/03/2018', 'skanda', '1234'),
(4, 'Precious', 'Male', 'Adult', '088456245', 'area49 guliver', 'skandakaunda@gmail.com', '5/11/1990', 'pk', '0000');

-- --------------------------------------------------------

--
-- Table structure for table `reservations`
--

CREATE TABLE `reservations` (
  `Reservation_ref` varchar(35) NOT NULL,
  `Passenger_ID` int(35) DEFAULT NULL,
  `Issued_Date` date DEFAULT NULL,
  `Cost` int(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservations`
--

INSERT INTO `reservations` (`Reservation_ref`, `Passenger_ID`, `Issued_Date`, `Cost`) VALUES
('1234', 3, '2023-05-08', 1015),
('holiday', 2, '2023-05-11', 790),
('sc200', 4, '2023-05-13', 620000);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `User_ID` varchar(35) NOT NULL,
  `Firstname` varchar(35) DEFAULT NULL,
  `Lastname` varchar(35) DEFAULT NULL,
  `Usertype` varchar(35) DEFAULT NULL,
  `Position` varchar(35) DEFAULT NULL,
  `Dob` varchar(35) DEFAULT NULL,
  `Address` varchar(55) DEFAULT NULL,
  `Username` varchar(35) DEFAULT NULL,
  `Password` varchar(55) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`User_ID`, `Firstname`, `Lastname`, `Usertype`, `Position`, `Dob`, `Address`, `Username`, `Password`) VALUES
('U001', 'admin', 'admin', 'admin', 'admin', 'admin', 'admin', 'admin', 'admin'),
('u002', 'Gomezgani ', 'Kaunda', 'Staff', 'staff', '4/5/2001', 'area 49 guliver', 'Kaunda', '0101');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aircraft`
--
ALTER TABLE `aircraft`
  ADD PRIMARY KEY (`Aircraft_ID`);

--
-- Indexes for table `fairs`
--
ALTER TABLE `fairs`
  ADD PRIMARY KEY (`Fair_ID`);

--
-- Indexes for table `flightreservation`
--
ALTER TABLE `flightreservation`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `flightsschedules`
--
ALTER TABLE `flightsschedules`
  ADD PRIMARY KEY (`Flight_ID`);

--
-- Indexes for table `flight_002_seats`
--
ALTER TABLE `flight_002_seats`
  ADD PRIMARY KEY (`Seat_No`);

--
-- Indexes for table `flight_003_seats`
--
ALTER TABLE `flight_003_seats`
  ADD PRIMARY KEY (`Seat_No`);

--
-- Indexes for table `flight_004_seats`
--
ALTER TABLE `flight_004_seats`
  ADD PRIMARY KEY (`Seat_No`);

--
-- Indexes for table `help`
--
ALTER TABLE `help`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `passengers`
--
ALTER TABLE `passengers`
  ADD PRIMARY KEY (`Passenger_ID`);

--
-- Indexes for table `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`Reservation_ref`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`User_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `flightreservation`
--
ALTER TABLE `flightreservation`
  MODIFY `ID` int(35) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `flight_002_seats`
--
ALTER TABLE `flight_002_seats`
  MODIFY `Seat_No` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `flight_003_seats`
--
ALTER TABLE `flight_003_seats`
  MODIFY `Seat_No` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `flight_004_seats`
--
ALTER TABLE `flight_004_seats`
  MODIFY `Seat_No` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `passengers`
--
ALTER TABLE `passengers`
  MODIFY `Passenger_ID` int(35) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
