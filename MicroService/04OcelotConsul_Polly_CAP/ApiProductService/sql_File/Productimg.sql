-- ----------------------------
-- Table structure for `ProductImg`
-- ----------------------------
DROP TABLE IF EXISTS `ProductImg`;
CREATE TABLE `ProductImg` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `productid` int(11) DEFAULT NULL COMMENT '商品ID',
  `url` varchar(80) DEFAULT NULL COMMENT '图片URL',
  `isdef` tinyint(4) DEFAULT NULL COMMENT '是否默认:0否 1:是',
  PRIMARY KEY (`id`),
  KEY `productid` (`productid`),
  CONSTRAINT `ProductImgibfk1` FOREIGN KEY (`productid`) REFERENCES `bbsproduct` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=240 DEFAULT CHARSET=utf8 COMMENT='图片';

-- ----------------------------
-- Records of ProductImg
-- ----------------------------
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('216', '252', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('217', '253', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('218', '254', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('219', '255', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('220', '256', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('221', '257', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('222', '258', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('223', '259', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('224', '260', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('225', '261', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('226', '262', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('227', '263', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('228', '264', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('229', '265', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('230', '266', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('231', '267', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('232', '268', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('233', '269', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('234', '270', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('235', '271', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('236', '272', 'res/img/pic/ppp.jpg', '1');
INSERT INTO ProductImg(id,productid,url,isdef) VALUES ('239', '275', 'res/img/pic/ppp.jpg', '1');
