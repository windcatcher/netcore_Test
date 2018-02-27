-- ----------------------------
-- Table structure for `bbsfeature`
-- ----------------------------
DROP TABLE IF EXISTS `bbsfeature`;
CREATE TABLE `bbsfeature` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `name` varchar(255) DEFAULT NULL COMMENT 'Ãû³Æ',
  `value` varchar(255) DEFAULT NULL,
  `sort` int(11) DEFAULT NULL COMMENT 'Ç°Ì¨ÅÅÐò',
  `isdel` tinyint(4) DEFAULT NULL COMMENT 'ÊÇ·ñ·ÏÆú:1:Î´·ÏÆú,0:·ÏÆúÁË',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COMMENT='ÊôÐÔ±í';

-- ----------------------------
-- Records of bbsfeature
-- ----------------------------
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('1', '»·±£ÈËÃÞ', '»·±£ÈËÃÞ', '1', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('2', 'Äª´ú¶û', 'Äª´ú¶û', '2', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('3', 'TPE', 'TPE', '3', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('4', 'ÃÞÂé', 'ÃÞÂé', '4', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('5', '½õÂÚ', '½õÂÚ', '5', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('6', 'ÖñÏËÎ¬', 'ÖñÏËÎ¬', '6', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('7', 'À³¿¨ÃÞ', 'À³¿¨ÃÞ', '7', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('8', 'Å£ÄÌË¿', 'Å£ÄÌË¿', '8', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('9', 'µÓÂÚ', 'µÓÂÚ', '9', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('10', 'Ïð½º', 'Ïð½º', '10', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('11', 'PVC', 'PVC', '11', '1');
INSERT INTO bbsfeature(id,name,value,sort,isdel) VALUES ('12', 'ÆäËü', 'ÆäËü', '12', '1');