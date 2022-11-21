-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 21 Lis 2022, 21:55
-- Wersja serwera: 10.4.13-MariaDB
-- Wersja PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `bank`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `account_balance`
--

CREATE TABLE `account_balance` (
  `Account_number` int(11) NOT NULL,
  `Account_balance` double DEFAULT NULL,
  `Currency_type` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `account_balance`
--

INSERT INTO `account_balance` (`Account_number`, `Account_balance`, `Currency_type`) VALUES
(1, 1200, 'Zł');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `clients`
--

CREATE TABLE `clients` (
  `Account_number` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Surname` varchar(255) NOT NULL,
  `Gender` char(1) NOT NULL,
  `Birth_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `clients`
--

INSERT INTO `clients` (`Account_number`, `Name`, `Surname`, `Gender`, `Birth_date`) VALUES
(1, 'Admin', '', 'M', '0000-00-00');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `clients_login`
--

CREATE TABLE `clients_login` (
  `Account_number` int(11) NOT NULL,
  `Password` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `clients_login`
--

INSERT INTO `clients_login` (`Account_number`, `Password`) VALUES
(1, '123');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `currency`
--

CREATE TABLE `currency` (
  `Currency_type` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `currency`
--

INSERT INTO `currency` (`Currency_type`) VALUES
('Zł');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `transactions`
--

CREATE TABLE `transactions` (
  `Transaction_ID` int(11) NOT NULL,
  `Account_number` int(11) DEFAULT NULL,
  `Currency_type` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `account_balance`
--
ALTER TABLE `account_balance`
  ADD PRIMARY KEY (`Account_number`),
  ADD KEY `Currency_type` (`Currency_type`);

--
-- Indeksy dla tabeli `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`Account_number`);

--
-- Indeksy dla tabeli `clients_login`
--
ALTER TABLE `clients_login`
  ADD PRIMARY KEY (`Account_number`);

--
-- Indeksy dla tabeli `currency`
--
ALTER TABLE `currency`
  ADD PRIMARY KEY (`Currency_type`);

--
-- Indeksy dla tabeli `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`Transaction_ID`),
  ADD KEY `Account_number` (`Account_number`),
  ADD KEY `Currency_type` (`Currency_type`);

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `account_balance`
--
ALTER TABLE `account_balance`
  ADD CONSTRAINT `account_balance_ibfk_1` FOREIGN KEY (`Currency_type`) REFERENCES `currency` (`Currency_type`),
  ADD CONSTRAINT `account_balance_ibfk_2` FOREIGN KEY (`Account_number`) REFERENCES `clients` (`Account_number`) ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `clients_login`
--
ALTER TABLE `clients_login`
  ADD CONSTRAINT `clients_login_ibfk_1` FOREIGN KEY (`Account_number`) REFERENCES `clients` (`Account_number`);

--
-- Ograniczenia dla tabeli `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`Account_number`) REFERENCES `clients` (`Account_number`),
  ADD CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`Currency_type`) REFERENCES `currency` (`Currency_type`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
