-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 23, 2018 at 09:05 AM
-- Server version: 10.1.31-MariaDB
-- PHP Version: 5.6.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `spring_hero_bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `accountNumber` varchar(50) NOT NULL,
  `identityCard` varchar(50) NOT NULL,
  `balance` decimal(10,0) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `fullName` varchar(50) NOT NULL,
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `salt` varchar(50) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`username`, `password`, `accountNumber`, `identityCard`, `balance`, `phone`, `email`, `fullName`, `createdAt`, `updatedAt`, `salt`, `status`) VALUES
('alahaba456', 'Gmn7Er/dghqVw3NqIwjMPcb3l7A=', '5b1d787c-bc91-4e33-b444-2ac257d9d5ff', '', '218000', '', '', '', '2018-06-23 03:14:47', '2018-06-23 03:14:47', 'LZEC7RB', 1),
('datdt1995', '5e0YCsC25jiJkd+MNi+0E6y/ihA=', '52fb2db5-2983-4041-8ea5-3fa9c8b9794d', '', '400211', '', '', '', '2018-06-19 12:38:47', '2018-06-19 12:38:47', 'CT0J5BS', 1),
('gianghap81', 'dqJC5VzLSzRC+RhClXbI7InastA=', 'f36452e3-e366-4079-b06c-f716f4b77af2', '11001010125', '10010', '01234567890', 'gianghap@gmail.com', 'Giang Sieu Nhan', '2018-06-23 06:45:00', '2018-06-23 06:45:00', 'TT2JF9F', 1),
('tunghap1256', 'B641pFQx5DVr5aSsNTL2J1WcrU8=', 'cb672164-778b-4051-b80f-fea0069735ab', '', '371789', '', '', '', '2018-06-20 01:44:16', '2018-06-20 01:44:16', '4WPY7X5', 1);

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `id` varchar(150) NOT NULL,
  `type` int(11) NOT NULL,
  `amount` decimal(10,0) NOT NULL,
  `content` varchar(150) NOT NULL,
  `senderAccountNumber` varchar(150) NOT NULL,
  `receiverAccountNumber` varchar(150) NOT NULL,
  `createdAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`id`, `type`, `amount`, `content`, `senderAccountNumber`, `receiverAccountNumber`, `createdAt`, `status`) VALUES
('3001b5f0-aed0-4364-9a5e-10b8f297381a', 3, '10000', 'mua bim bim', 'cb672164-778b-4051-b80f-fea0069735ab', 'f36452e3-e366-4079-b06c-f716f4b77af2', '2018-06-23 06:53:16', 2),
('549c8cb1-f4a9-4997-b3f5-077282153765', 1, '10', '222', 'f36452e3-e366-4079-b06c-f716f4b77af2', 'f36452e3-e366-4079-b06c-f716f4b77af2', '2018-06-23 06:46:09', 2),
('604c43a6-1972-4009-84cc-64b458cdcd5d', 3, '50000', 'cho chu the 50', 'cb672164-778b-4051-b80f-fea0069735ab', '5b1d787c-bc91-4e33-b444-2ac257d9d5ff', '2018-06-23 04:43:12', 2),
('68334487-9b9e-4850-8164-9d3c103d85e8', 3, '71000', 'Hello Gui tien cho di choi gai', '52fb2db5-2983-4041-8ea5-3fa9c8b9794d', '5b1d787c-bc91-4e33-b444-2ac257d9d5ff', '2018-06-23 03:39:50', 2),
('f0a3e29e-d0e9-4c40-bead-e639193e2c67', 2, '100000', 'Rut Tien', 'cb672164-778b-4051-b80f-fea0069735ab', 'cb672164-778b-4051-b80f-fea0069735ab', '2018-06-23 04:42:19', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`username`),
  ADD UNIQUE KEY `accountNumber` (`accountNumber`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
