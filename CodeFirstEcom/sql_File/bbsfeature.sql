-- ----------------------------
-- Table structure for `bbsfeature`
-- ----------------------------
DROP TABLE IF EXISTS `bbsfeature`;
CREATE TABLE `bbsfeature` (
  `id` int(11) NOT NULL AUTOINCREMENT COMMENT 'ID',
  `name` varchar(255) DEFAULT NULL COMMENT '名称',
  `value` varchar(255) DEFAULT NULL,
  `sort` int(11) DEFAULT NULL COMMENT '前台排序',
  `isdel` tinyint(1) DEFAULT NULL COMMENT '是否废弃:1:未废弃,0:废弃了',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTOINCREMENT=13 DEFAULT CHARSET=utf8 COMMENT='属性表';

-- ----------------------------
-- Records of bbsfeature
-- ----------------------------
INSERT INTO bbsfeature VALUES ('1', '环保人棉', '环保人棉', '1', '1');
INSERT INTO bbsfeature VALUES ('2', '莫代尔', '莫代尔', '2', '1');
INSERT INTO bbsfeature VALUES ('3', 'TPE', 'TPE', '3', '1');
INSERT INTO bbsfeature VALUES ('4', '棉麻', '棉麻', '4', '1');
INSERT INTO bbsfeature VALUES ('5', '锦纶', '锦纶', '5', '1');
INSERT INTO bbsfeature VALUES ('6', '竹纤维', '竹纤维', '6', '1');
INSERT INTO bbsfeature VALUES ('7', '莱卡棉', '莱卡棉', '7', '1');
INSERT INTO bbsfeature VALUES ('8', '牛奶丝', '牛奶丝', '8', '1');
INSERT INTO bbsfeature VALUES ('9', '涤纶', '涤纶', '9', '1');
INSERT INTO bbsfeature VALUES ('10', '橡胶', '橡胶', '10', '1');
INSERT INTO bbsfeature VALUES ('11', 'PVC', 'PVC', '11', '1');
INSERT INTO bbsfeature VALUES ('12', '其它', '其它', '12', '1');