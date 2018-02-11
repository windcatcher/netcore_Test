-- ----------------------------
-- Table structure for `bbsproduct`
-- ----------------------------
DROP TABLE IF EXISTS `bbsproduct`;
CREATE TABLE `bbsproduct` (
  `id` int(11) NOT NULL AUTOINCREMENT COMMENT 'ID',
  `no` varchar(30) DEFAULT NULL COMMENT '商品编号',
  `name` varchar(255) NOT NULL COMMENT '商品名称',
  `weight` double(11,0) DEFAULT NULL COMMENT '重量 单位:克',
  `isnew` tinyint(1) DEFAULT NULL COMMENT '是否新品:0:旧品,1:新品',
  `ishot` tinyint(1) DEFAULT NULL COMMENT '是否热销:0,否 1:是',
  `iscommend` tinyint(1) DEFAULT NULL COMMENT '推荐 1推荐 0 不推荐',
  `createtime` datetime DEFAULT NULL COMMENT '添加时间',
  `createuserid` varchar(255) DEFAULT NULL COMMENT '添加人ID',
  `checktime` datetime DEFAULT NULL COMMENT '审核时间',
  `checkuserid` varchar(255) DEFAULT NULL COMMENT '审核人ID',
  `isshow` tinyint(1) DEFAULT NULL COMMENT '上下架:0否 1是',
  `isdel` tinyint(1) DEFAULT NULL COMMENT '是否删除:0删除,1,没删除',
  `typeid` int(11) DEFAULT NULL COMMENT '类型ID',
  `brandid` int(11) DEFAULT NULL COMMENT '品牌ID',
  `keywords` varchar(255) DEFAULT NULL COMMENT '检索关键词',
  `sales` int(11) DEFAULT NULL COMMENT '销量',
  `description` longtext COMMENT '商品描述',
  `packagelist` longtext COMMENT '包装清单',
  `feature` varchar(255) DEFAULT NULL COMMENT '商品属性集',
  `color` varchar(255) DEFAULT NULL COMMENT '颜色集',
  `size` varchar(255) DEFAULT NULL COMMENT '尺寸集',
  PRIMARY KEY (`id`),
  KEY `typeid` (`typeid`),
  KEY `brandid` (`brandid`),
  CONSTRAINT `bbsproductibfk1` FOREIGN KEY (`typeid`) REFERENCES `bbstype` (`id`),
  CONSTRAINT `bbsproductibfk2` FOREIGN KEY (`brandid`) REFERENCES `bbsbrand` (`id`)
) ENGINE=InnoDB AUTOINCREMENT=276 DEFAULT CHARSET=utf8 COMMENT='商品';

-- ----------------------------
-- Records of bbsproduct
-- ----------------------------
INSERT INTO bbsproduct VALUES ('252', '20141028114308048', '252--依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 ', '1', '0', '1', '0', '2014-10-28 11:43:08', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" alt=\"\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('253', '20141028114322284', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:22', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('254', '20141028114328904', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:28', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('255', '20141028114331167', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:31', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('256', '20141028114333647', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:33', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('257', '20141028114336280', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:36', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('258', '20141028114338422', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:38', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('259', '20141028114340470', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:40', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('260', '20141028114342622', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:42', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('261', '20141028114347654', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:47', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('262', '20141028114350662', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:50', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('263', '20141028114352709', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:52', null, null, null, '0', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('264', '20141028114354902', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:54', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('265', '20141028114356998', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:56', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('266', '20141028114358873', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:43:58', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('267', '20141028114401153', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:44:01', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('268', '20141028114403414', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '0', '0', '2014-10-28 11:44:03', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('269', '20141028114405217', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:44:05', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('270', '20141028114407438', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:44:07', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('271', '20141028114409502', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '1', '0', '2014-10-28 11:44:09', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('272', '20141028114411609', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 女瑜伽服送胸垫 长袖紫色', '1', '0', '0', '0', '2014-10-28 11:44:11', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"674\" alt=\"\" src=\"http://localhost:8088/image-web/upload/20141028114251971945586.jpg\" /></p>', '衣服 裤子', '1,2,9,11', '9,11,18,19,29', 'S,M,L,XL');
INSERT INTO bbsproduct VALUES ('275', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件', '1', '0', '0', '0', '2014-12-01 10:08:33', null, null, null, '1', '1', '2', '1', null, null, '<p><img width=\"750\" height=\"1079\" src=\"http://localhost:8088/image-web/upload/20141201100423474346.jpg\" alt=\"\" /></p>\r\n<p><img width=\"750\" height=\"572\" src=\"http://localhost:8088/image-web/upload/20141201100445873531.jpg\" alt=\"\" /></p>', '衣服*1,裤子*1', '1,6,7', '14,17,22', 'S,XL,XXL');
