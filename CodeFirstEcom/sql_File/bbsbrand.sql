-- ----------------------------
-- Table structure for `bbsbrand`
-- ----------------------------
DROP TABLE IF EXISTS `bbsbrand`;
CREATE TABLE `bbsbrand` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `name` varchar(40) NOT NULL COMMENT '名称',
  `description` varchar(80) DEFAULT NULL COMMENT '描述',
  `imgurl` varchar(80) DEFAULT NULL COMMENT '图片Url',
  `website` varchar(80) DEFAULT NULL COMMENT '品牌网址',
  `sort` int(11) DEFAULT NULL COMMENT '排序:最大最排前',
  `isdisplay` tinyint(1) DEFAULT NULL COMMENT '是否可见 1:可见 0:不可见',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='品牌';

-- ----------------------------
-- Records of bbsbrand
-- ----------------------------
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('1', '依琦莲', null, null, null, '99', '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('2', '凯速（KANSOON）', null, null, null, null, '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('3', '梵歌纳（vangona）', null, null, null, null, '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('4', '伊朵莲', null, null, null, null, '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('5', '菩媞', null, null, null, null, '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('6', '丹璐斯', null, null, null, null, '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('7', '喜悦瑜伽', null, null, null, null, '1');
INSERT INTO bbsbrand(id,name,description,imgurl,website,sort,isdisplay) VALUES ('8', '金乐乐', '金乐乐', 'upload/20141201101326051272.jpg', null, '44', '1');