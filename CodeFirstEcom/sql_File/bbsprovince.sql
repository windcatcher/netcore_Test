-- ----------------------------
-- Table structure for `bbsprovince`
-- ----------------------------
DROP TABLE IF EXISTS `bbsprovince`;
CREATE TABLE `bbsprovince` (
  `id` int(11) NOT NULL AUTOINCREMENT COMMENT '主键',
  `code` char(6) NOT NULL COMMENT '省份编码',
  `name` varchar(40) NOT NULL COMMENT '省份名称',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTOINCREMENT=35 DEFAULT CHARSET=utf8 COMMENT='省份信息表';

-- ----------------------------
-- Records of bbsprovince
-- ----------------------------
INSERT INTO bbsprovince VALUES ('1', '110000', '北京市');
INSERT INTO bbsprovince VALUES ('2', '120000', '天津市');
INSERT INTO bbsprovince VALUES ('3', '130000', '河北省');
INSERT INTO bbsprovince VALUES ('4', '140000', '山西省');
INSERT INTO bbsprovince VALUES ('5', '150000', '内蒙古自治区');
INSERT INTO bbsprovince VALUES ('6', '210000', '辽宁省');
INSERT INTO bbsprovince VALUES ('7', '220000', '吉林省');
INSERT INTO bbsprovince VALUES ('8', '230000', '黑龙江省');
INSERT INTO bbsprovince VALUES ('9', '310000', '上海市');
INSERT INTO bbsprovince VALUES ('10', '320000', '江苏省');
INSERT INTO bbsprovince VALUES ('11', '330000', '浙江省');
INSERT INTO bbsprovince VALUES ('12', '340000', '安徽省');
INSERT INTO bbsprovince VALUES ('13', '350000', '福建省');
INSERT INTO bbsprovince VALUES ('14', '360000', '江西省');
INSERT INTO bbsprovince VALUES ('15', '370000', '山东省');
INSERT INTO bbsprovince VALUES ('16', '410000', '河南省');
INSERT INTO bbsprovince VALUES ('17', '420000', '湖北省');
INSERT INTO bbsprovince VALUES ('18', '430000', '湖南省');
INSERT INTO bbsprovince VALUES ('19', '440000', '广东省');
INSERT INTO bbsprovince VALUES ('20', '450000', '广西壮族自治区');
INSERT INTO bbsprovince VALUES ('21', '460000', '海南省');
INSERT INTO bbsprovince VALUES ('22', '500000', '重庆市');
INSERT INTO bbsprovince VALUES ('23', '510000', '四川省');
INSERT INTO bbsprovince VALUES ('24', '520000', '贵州省');
INSERT INTO bbsprovince VALUES ('25', '530000', '云南省');
INSERT INTO bbsprovince VALUES ('26', '540000', '西藏自治区');
INSERT INTO bbsprovince VALUES ('27', '610000', '陕西省');
INSERT INTO bbsprovince VALUES ('28', '620000', '甘肃省');
INSERT INTO bbsprovince VALUES ('29', '630000', '青海省');
INSERT INTO bbsprovince VALUES ('30', '640000', '宁夏回族自治区');
INSERT INTO bbsprovince VALUES ('31', '650000', '新疆维吾尔自治区');
INSERT INTO bbsprovince VALUES ('32', '710000', '台湾省');
INSERT INTO bbsprovince VALUES ('33', '810000', '香港特别行政区');
INSERT INTO bbsprovince VALUES ('34', '820000', '澳门特别行政区');
