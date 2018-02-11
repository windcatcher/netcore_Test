-- ----------------------------
-- Table structure for `bbsimg`
-- ----------------------------
DROP TABLE IF EXISTS `bbsimg`;
CREATE TABLE `bbsimg` (
  `id` int(11) NOT NULL AUTOINCREMENT COMMENT 'ID',
  `productid` int(11) DEFAULT NULL COMMENT '商品ID',
  `url` varchar(80) DEFAULT NULL COMMENT '图片URL',
  `isdef` tinyint(1) DEFAULT NULL COMMENT '是否默认:0否 1:是',
  PRIMARY KEY (`id`),
  KEY `productid` (`productid`),
  CONSTRAINT `bbsimgibfk1` FOREIGN KEY (`productid`) REFERENCES `bbsproduct` (`id`)
) ENGINE=InnoDB AUTOINCREMENT=240 DEFAULT CHARSET=utf8 COMMENT='图片';

-- ----------------------------
-- Records of bbsimg
-- ----------------------------
INSERT INTO bbsimg VALUES ('216', '252', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('217', '253', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('218', '254', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('219', '255', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('220', '256', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('221', '257', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('222', '258', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('223', '259', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('224', '260', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('225', '261', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('226', '262', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('227', '263', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('228', '264', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('229', '265', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('230', '266', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('231', '267', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('232', '268', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('233', '269', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('234', '270', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('235', '271', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('236', '272', 'res/img/pic/ppp.jpg', '1');
INSERT INTO bbsimg VALUES ('239', '275', 'res/img/pic/ppp.jpg', '1');
