-- ----------------------------
-- Table structure for `Color`
-- ----------------------------
DROP TABLE IF EXISTS `Color`;
CREATE TABLE `Color` (
  `id` int(11) NOT NULL AUTO_INCREMENT  COMMENT 'ID',
  `name` varchar(20) DEFAULT NULL COMMENT '名称',
  `parentid` int(11) DEFAULT NULL COMMENT '父ID为色系',
  `imgurl` varchar(50) DEFAULT NULL COMMENT '颜色对应的衣服小图',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8 COMMENT='颜色大全';

-- ----------------------------
-- Records of Color
-- ----------------------------
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('1', '红色系', '0', '365756');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('2', '绿色系', '0', '831162');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('3', '蓝色系', '0', '397817');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('4', '黑色系', '0', '798685');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('5', '粉色系', '0', '714774');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('6', '紫色系', '0', '271247');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('7', '灰色系', '0', '215711');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('8', '其他', '0', '421753');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('9', '西瓜红', '1', '361823');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('10', '大红', '1', '761156');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('11', '墨绿', '2', '829598');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('12', '草绿', '2', '666929');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('13', '青绿', '2', '835412');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('14', '海军蓝', '3', '463347');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('15', '海军白蓝条', '14', '134458');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('16', '紫黑', '4', '839387');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('17', '纯黑', '4', '926366');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('18', '浅粉', '5', '385183');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('19', '浅紫', '6', '235837');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('20', '浅灰', '7', '379694');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('21', '均色', '8', '694256');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('22', '桃粉', '5', '288715');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('23', '深紫', '6', '448623');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('24', '浅蓝', '3', '773343');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('25', '深蓝', '3', '451347');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('26', '夕阳红', '1', '971962');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('27', '深灰', '7', '562622');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('28', '卡其灰', '7', '397751');
INSERT INTO Color(id,name,parentid,imgurl) VALUES ('29', '典雅灰', '7', '274621');