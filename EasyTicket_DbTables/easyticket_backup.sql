-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: easyticket_pro
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20261031194640_InitialCreate','9.0.0'),('20261101144719_AddEventsTable','9.0.0'),('20261101155046_AddLocationToEvent','9.0.0'),('20261101164829_AddTicketModel','9.0.0'),('20261101172431_AddUserDescription','9.0.0');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `events`
--

DROP TABLE IF EXISTS `events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `events` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Date` datetime(6) NOT NULL,
  `Category` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  `Location` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `events`
--

LOCK TABLES `events` WRITE;
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
INSERT INTO `events` VALUES (1,'Ed Sheeran Tour','Pop concert on big stage','2026-06-15 20:00:00.000000','Concerts',120.000000000000000000000000000000,'Vasil Levski Stadium, Sofia'),(2,'Rock Fest 2026','Heavy metal and rock bands live','2026-07-04 18:00:00.000000','Concerts',85.000000000000000000000000000000,'Plovdiv Plaza, Plovdiv'),(3,'Jazz Night Under The Stars','Relaxing smooth jazz evening','2026-08-12 21:00:00.000000','Concerts',45.000000000000000000000000000000,'Ancient Theatre, Plovdiv'),(4,'Electronic Summer Beat','EDM festival with top DJs','2026-07-20 22:00:00.000000','Concerts',90.000000000000000000000000000000,'Cacao Beach, Sunny Beach'),(5,'Symphonic Masterpieces','Classical orchestra performance','2026-09-05 19:00:00.000000','Concerts',60.000000000000000000000000000000,'Bulgaria Hall, Sofia'),(6,'Hip-Hop Nation Live','Local and international rap stars','2026-05-30 20:30:00.000000','Concerts',50.000000000000000000000000000000,'Arena Sofia, Sofia'),(7,'Acoustic Nights','Intimate unplugged guitar live','2026-06-01 20:00:00.000000','Concerts',30.000000000000000000000000000000,'Club Studio 5, Sofia'),(8,'Indie Rock Vibes','Alternative and indie band showcase','2026-08-22 19:30:00.000000','Concerts',40.000000000000000000000000000000,'Summer Theater, Varna'),(9,'Retro 90s Party Live','Best nostalgia hits live on stage','2026-10-10 21:00:00.000000','Concerts',55.000000000000000000000000000000,'Kolo колодром, Plovdiv'),(10,'Opera Grand Gala','Famous opera arias and duets','2026-11-15 19:00:00.000000','Concerts',75.000000000000000000000000000000,'Sofia Opera and Ballet, Sofia'),(11,'Football Derby','Local championship derby match','2026-05-18 17:30:00.000000','Sports',25.000000000000000000000000000000,'Vasil Levski Stadium, Sofia'),(12,'Tennis Open Final','Professional tournament final','2026-09-20 15:00:00.000000','Sports',110.000000000000000000000000000000,'Arena Sofia, Sofia'),(13,'Basketball League Final','National championship game 5','2026-06-02 19:00:00.000000','Sports',35.000000000000000000000000000000,'SILA Complex, Plovdiv'),(14,'Marathon Challenge 2026','City marathon 42km run','2026-10-04 09:00:00.000000','Sports',15.000000000000000000000000000000,'City Center, Sofia'),(15,'Volleyball World Cup Match','National team group match','2026-07-11 18:00:00.000000','Sports',40.000000000000000000000000000000,'Palace of Culture and Sports, Varna'),(16,'Boxing Championship Night','Heavyweight title clash','2026-11-28 20:00:00.000000','Sports',95.000000000000000000000000000000,'Arena Burgas, Burgas'),(17,'Formula Drift Show','Extreme cars and drifting contest','2026-08-08 14:00:00.000000','Sports',50.000000000000000000000000000000,'Track Drakon, Kaloyanovo'),(18,'Swimming National Cup','Sprint and relay competitions','2026-06-25 10:00:00.000000','Sports',10.000000000000000000000000000000,'Park Arena OZU, Burgas'),(19,'MMA Fight Night','Octagon professional mixed martial arts','2026-09-12 21:00:00.000000','Sports',70.000000000000000000000000000000,'Arena Sofia, Sofia'),(20,'Cycling Tour Cup','Stage race through mountain roads','2026-07-01 08:30:00.000000','Sports',0.000000000000000000000000000000,'Central Square, Veliko Tarnovo'),(21,'Hamlet - Classical Drama','Shakespeare tragic masterpiece','2026-05-25 19:00:00.000000','Theater',35.000000000000000000000000000000,'Ivan Vazov National Theatre, Sofia'),(22,'Comedy Night Stand-Up','Hilarious comedy show by top comics','2026-06-10 20:00:00.000000','Theater',30.000000000000000000000000000000,'Tears and Laughter Theatre, Sofia'),(23,'Les Miserables Musical','Broad-way style musical production','2026-10-15 19:30:00.000000','Theater',80.000000000000000000000000000000,'State Opera, Varna'),(24,'The Great Gatsby Drama','1920s classic story performance','2026-09-08 19:00:00.000000','Theater',40.000000000000000000000000000000,'Youth Theatre, Sofia'),(25,'Romeo and Juliet Ballet','Romantic ballet and orchestra','2026-07-14 19:00:00.000000','Theater',50.000000000000000000000000000000,'Ancient Theatre, Plovdiv'),(26,'Phantasmagoria Magic Show','Illusionists and mentalism show','2026-08-30 18:30:00.000000','Theater',45.000000000000000000000000000000,'Summer Theatre, Burgas'),(27,'The Phantom of the Opera','Classic gothic musical drama','2026-11-05 19:00:00.000000','Theater',90.000000000000000000000000000000,'National Music Theatre, Sofia'),(28,'Modern Dance Fusion','Contemporary choreography project','2026-06-18 20:00:00.000000','Theater',25.000000000000000000000000000000,'Derida Stage, Sofia'),(29,'Puppet Show for Adults','Satirical and dark comedy puppets','2026-09-25 19:30:00.000000','Theater',20.000000000000000000000000000000,'State Puppet Theatre, Plovdiv'),(30,'Monodrama: The Last Confession','One actor emotional performance','2026-10-22 19:00:00.000000','Theater',28.000000000000000000000000000000,'Satirical Theatre, Sofia');
/*!40000 ALTER TABLE `events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tickets`
--

DROP TABLE IF EXISTS `tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tickets` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `EventId` int NOT NULL,
  `PurchasedAt` datetime(6) NOT NULL,
  `Quantity` int NOT NULL,
  `TotalPrice` decimal(65,30) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Tickets_EventId` (`EventId`),
  KEY `IX_Tickets_UserId` (`UserId`),
  CONSTRAINT `FK_Tickets_Events_EventId` FOREIGN KEY (`EventId`) REFERENCES `events` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Tickets_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tickets`
--

LOCK TABLES `tickets` WRITE;
/*!40000 ALTER TABLE `tickets` DISABLE KEYS */;
INSERT INTO `tickets` VALUES (1,4,1,'2026-11-01 19:04:29.716987',1,120.000000000000000000000000000000),(2,4,3,'2026-11-01 19:04:36.779463',1,45.000000000000000000000000000000),(3,4,8,'2026-11-01 19:09:38.100772',1,40.000000000000000000000000000000),(4,4,12,'2026-11-01 19:11:31.732360',1,110.000000000000000000000000000000),(5,4,22,'2026-11-01 19:16:34.888143',1,30.000000000000000000000000000000);
/*!40000 ALTER TABLE `tickets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Kristian-Yoan','Kolibarov','kriskata2501@gmail.com','AQAAAAIAAYagAAAAEPSnmOeyuWHpAMmEOyiaFoNla9Ljn6zuTI2UnHMQG4uewkGeZ9rV9XWJm5QaJUTCNQ==',''),(3,'Peter','Parker','spiderman@gmail.com','AQAAAAIAAYagAAAAEMpHoW2Xp6xz0Hn3xe3AI/x4Z/LoFoXx0Dd15nnM8cG1Oghm+AzfijW+uPJiVbmz+w==',''),(4,'Peter','Petrov','pepi123@gmail.com','AQAAAAIAAYagAAAAED5QpwTFdEz7fIdTPzurHx52/KhjX3atrMes80Iny6MHG5jpRzp6j3S0y1Pyd+C+eQ==','hello'),(5,'Test','Tester','test@gmail.com','AQAAAAIAAYagAAAAEJwOEZkrPd7sXKj2u0SyHu4S9Iekiv9eT2X3G5kIXK16Y7S3FN+8VFuqv2DFfvO75A==','hello');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-01 21:26:15
