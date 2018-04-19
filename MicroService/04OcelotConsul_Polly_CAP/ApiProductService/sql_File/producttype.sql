-- ----------------------------
-- Table structure for `ProductType`
-- ----------------------------
DROP TABLE IF EXISTS `ProductType`;
CREATE TABLE `ProductType` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `name` varchar(36) NOT NULL COMMENT '名称',
  `parentid` int(11) DEFAULT NULL COMMENT '父ID',
  `note` varchar(200) DEFAULT NULL COMMENT '备注,用于google搜索页面描述',
  `isdisplay` tinyint(4) NOT NULL COMMENT '是否可见 1:可见 0:不可见',
  PRIMARY KEY (`id`),
  KEY `FKA8168A929B5A332` (`parentid`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='商品类型';

-- ----------------------------
-- Records of ProductType
-- ----------------------------
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('1', '瑜珈', '0', null, '0');
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('2', '瑜珈服', '1', null, '1');
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('3', '瑜伽辅助', '1', null, '1');
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('4', '瑜伽铺巾', '1', null, '1');
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('5', '瑜伽垫', '1', null, '1');
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('6', '舞蹈鞋服', '1', null, '1');
INSERT INTO ProductType(id,name,parentid,note,isdisplay) VALUES ('7', '其它', '1', null, '1');
