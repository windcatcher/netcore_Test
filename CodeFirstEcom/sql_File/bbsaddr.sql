-- ----------------------------
-- Table structure for `bbsaddr`
-- ----------------------------CREATE TABLE
DROP TABLE IF EXISTS `bbsaddr`;
 CREATE TABLE `bbsaddr` (
  `id` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `buyerid` INT(11) NOT NULL COMMENT '用户ID',
  `name` VARCHAR(80) NOT NULL COMMENT '收货人',
  `city` VARCHAR(255) DEFAULT NULL,
  `addr` VARCHAR(400) NOT NULL COMMENT '收货地址',
  `phone` VARCHAR(60) NOT NULL COMMENT '手机号或是固定电话号',
  `isdef` tinyint(4) NOT NULL COMMENT '是否默认',
  PRIMARY KEY (`id`),
  KEY `buyerid` (`buyerid`),
  KEY `IX_BbsAddr_BuyerId1` (`BuyerId`),
  CONSTRAINT `FK_BbsAddr_BbsBuyer_BuyerId1` FOREIGN KEY (`BuyerId`) REFERENCES `bbsbuyer` (`Id`) ON DELETE NO ACTION
) ENGINE=INNODB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='收货地址';

-- ----------------------------
-- Records of bbsaddr
-- ----------------------------
INSERT INTO bbsaddr(id,buyerid,NAME,city,addr,phone,isdef) VALUES ('1', '1', '范冰冰', '北京市北京市通州区', '建材城西路中腾建华3楼314室', '13888888899', '1');
