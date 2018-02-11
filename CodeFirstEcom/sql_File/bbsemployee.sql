-- ----------------------------
-- Table structure for `bbsemployee`
-- ----------------------------
DROP TABLE IF EXISTS `bbsemployee`;
CREATE TABLE `bbsemployee` (
  `username` varchar(20) NOT NULL COMMENT '用户名',
  `password` varchar(20) NOT NULL COMMENT '密码',
  `degree` varchar(10) DEFAULT NULL COMMENT '学历',
  `email` varchar(40) DEFAULT NULL COMMENT '邮箱',
  `gender` tinyint(1) DEFAULT NULL COMMENT '性别 ',
  `imgurl` varchar(41) DEFAULT NULL COMMENT '图片(头像)',
  `phone` varchar(18) DEFAULT NULL COMMENT '手机',
  `realname` varchar(8) DEFAULT NULL COMMENT '真实名字',
  `school` varchar(20) DEFAULT NULL COMMENT '毕业学校',
  `isdel` tinyint(1) NOT NULL COMMENT '是否删除 1:未删除 0:删除',
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='员工';

-- ----------------------------
-- Records of bbsemployee
-- ----------------------------
INSERT INTO bbsemployee VALUES ('admin', '123456', null, null, '1', null, null, '系统管理员', null, '1');
INSERT INTO bbsemployee VALUES ('zhangsan', '123456', null, null, null, null, null, null, null, '1');