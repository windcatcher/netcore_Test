-- ----------------------------
-- Table structure for `bbsbuyer`
-- ----------------------------
DROP TABLE IF EXISTS `bbsbuyer`;
CREATE TABLE `bbsbuyer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(18) NOT NULL COMMENT '用户名',
  `password` varchar(32) DEFAULT NULL COMMENT '密码',
  `gender` varchar(8) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL COMMENT '邮箱',
  `realname` varchar(8) DEFAULT NULL COMMENT '真实名字',
  `registertime` datetime DEFAULT NULL COMMENT '注册时间',
  `province` varchar(11) DEFAULT NULL COMMENT '省ID',
  `city` varchar(11) DEFAULT NULL COMMENT '市ID',
  `town` varchar(11) DEFAULT NULL COMMENT '县ID',
  `addr` varchar(255) DEFAULT NULL COMMENT '地址',
  `isdel` tinyint(4) DEFAULT NULL COMMENT '是否已删除:1:未,0:删除了',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='购买者';

-- ----------------------------
-- Records of bbsbuyer
-- ----------------------------
INSERT INTO bbsbuyer(username,password,gender,email,realname,registertime,province,city,town,addr,isdel) VALUES ('fbb2014', 'e10adc3949ba59abbe56e057f20f883e', 'WOMAN', '112624349@qq.com', '范冰冰', '2014-10-27 11:31:00', '120000', '120100', '120105', '海淀区建材城西路100号', '1');