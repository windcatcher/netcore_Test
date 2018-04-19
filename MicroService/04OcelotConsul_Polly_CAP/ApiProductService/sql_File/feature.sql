-- ----------------------------
-- Table structure for `Feature`
-- ----------------------------
DROP TABLE IF EXISTS `Feature`;
CREATE TABLE `Feature` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `Name` varchar(255) DEFAULT NULL COMMENT 'Ãû³Æ',
  `Value` varchar(255) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL COMMENT 'Ç°Ì¨ÅÅÐò',
  `IsDel` tinyint(4) DEFAULT NULL COMMENT 'ÊÇ·ñ·ÏÆú:1:Î´·ÏÆú,0:·ÏÆúÁË',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COMMENT='ÊôÐÔ±í';

-- ----------------------------
-- Records of Feature
-- ----------------------------
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('1', '»·±£ÈËÃÞ', '»·±£ÈËÃÞ', '1', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('2', 'Äª´ú¶û', 'Äª´ú¶û', '2', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('3', 'TPE', 'TPE', '3', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('4', 'ÃÞÂé', 'ÃÞÂé', '4', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('5', '½õÂÚ', '½õÂÚ', '5', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('6', 'ÖñÏËÎ¬', 'ÖñÏËÎ¬', '6', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('7', 'À³¿¨ÃÞ', 'À³¿¨ÃÞ', '7', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('8', 'Å£ÄÌË¿', 'Å£ÄÌË¿', '8', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('9', 'µÓÂÚ', 'µÓÂÚ', '9', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('10', 'Ïð½º', 'Ïð½º', '10', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('11', 'PVC', 'PVC', '11', '1');
INSERT INTO Feature(Id,Name,Value,Sort,IsDel) ValueS ('12', 'ÆäËü', 'ÆäËü', '12', '1');