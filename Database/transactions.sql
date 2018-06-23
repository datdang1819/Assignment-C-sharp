-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 23, 2018 at 09:08 AM
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
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
