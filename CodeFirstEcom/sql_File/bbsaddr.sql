-- ----------------------------
-- Table structure for `bbsaddr`
-- ----------------------------CREATE TABLE
DROP TABLE IF EXISTS `bbsaddr`;
 CREATE TABLE `bbsaddr` (
  `id` int(11) NOT NULL AUTOINCREMENT COMMENT 'ID',
  `buyerid` varchar(40) NOT NULL COMMENT '用户ID',
  `name` varchar(80) NOT NULL COMMENT '收货人',
  `city` varchar(255) DEFAULT NULL,
  `addr` varchar(400) NOT NULL COMMENT '收货地址',
  `phone` varchar(60) NOT NULL COMMENT '手机号或是固定电话号',
  `isdef` int(1) NOT NULL COMMENT '是否默认',
  PRIMARY KEY (`id`),
  KEY `buyerid` (`buyerid`),
  CONSTRAINT `bbsaddribfk1` FOREIGN KEY (`buyerid`) REFERENCES `bbsbuyer` (`username`)
) ENGINE=InnoDB AUTOINCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='收货地址';

-- ----------------------------
-- Records of bbsaddr
-- ----------------------------
INSERT INTO bbsaddr VALUES ('1', 'fbb2014', '范冰冰', '北京市北京市通州区', '建材城西路中腾建华3楼314室', '13888888899', '1');
INSERT INTO bbsaddr VALUES ('2', 'fbb2014', '李冰冰', '北京市北京市通州区', '建材城龙乡小区', '13666666666', '0');