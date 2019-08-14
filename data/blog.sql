-- --------------------------------------------------------
-- Sunucu:                       127.0.0.1
-- Sunucu sürümü:                5.7.27-log - MySQL Community Server (GPL)
-- Sunucu İşletim Sistemi:       Win64
-- HeidiSQL Sürüm:               10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- blog için veritabanı yapısı dökülüyor
CREATE DATABASE IF NOT EXISTS `blog` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_turkish_ci */;
USE `blog`;

-- tablo yapısı dökülüyor blog.comment
CREATE TABLE IF NOT EXISTS `comment` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `LastName` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `Message` varchar(5000) COLLATE utf8_turkish_ci NOT NULL,
  `PostId` int(10) unsigned NOT NULL,
  `IsDeleted` tinyint(4) NOT NULL DEFAULT '0',
  `DeleterUserId` int(11) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `IsActive` tinyint(4) NOT NULL DEFAULT '1',
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` int(11) DEFAULT NULL,
  `CreationTime` datetime DEFAULT NULL,
  `CreatorUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_comment_post` (`PostId`),
  CONSTRAINT `FK_comment_post` FOREIGN KEY (`PostId`) REFERENCES `post` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- blog.comment: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `comment` DISABLE KEYS */;
/*!40000 ALTER TABLE `comment` ENABLE KEYS */;

-- tablo yapısı dökülüyor blog.post
CREATE TABLE IF NOT EXISTS `post` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Title` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `Content` varchar(5000) COLLATE utf8_turkish_ci NOT NULL,
  `UserId` int(11) unsigned NOT NULL,
  `IsDeleted` tinyint(4) NOT NULL DEFAULT '0',
  `DeleterUserId` int(11) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `IsActive` tinyint(4) NOT NULL DEFAULT '1',
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` int(11) DEFAULT NULL,
  `CreationTime` datetime DEFAULT NULL,
  `CreatorUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_post_user` (`UserId`),
  FULLTEXT KEY `Title` (`Title`),
  FULLTEXT KEY `Content` (`Content`),
  CONSTRAINT `FK_post_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- blog.post: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
/*!40000 ALTER TABLE `post` ENABLE KEYS */;

-- tablo yapısı dökülüyor blog.user
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `LastName` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `MailAddress` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `Password` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `IsDeleted` tinyint(4) NOT NULL DEFAULT '0',
  `DeleterUserId` int(11) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `IsActive` tinyint(4) NOT NULL DEFAULT '1',
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` int(11) DEFAULT NULL,
  `CreationTime` datetime DEFAULT NULL,
  `CreatorUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- blog.user: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`Id`, `FirstName`, `LastName`, `MailAddress`, `Password`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `IsActive`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, 'admin', 'admin', 'admin@admin.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 0, NULL, NULL, 1, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
