-- ----------------------------
-- Table structure for `bbsorder`
-- ----------------------------
DROP TABLE IF EXISTS `bbsorder`;
CREATE TABLE `bbsorder` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `oid` varchar(36) NOT NULL COMMENT '订单号',
  `deliverfee` decimal(10,2) NOT NULL COMMENT '运费',
  `payablefee` double NOT NULL COMMENT '应付金额',
  `totalprice` double NOT NULL COMMENT '订单金额',
  `paymentway` tinyint(1) NOT NULL COMMENT '支付方式 0:到付 1:在线 2:邮局 3:公司转帐',
  `paymentcash` tinyint(1) DEFAULT NULL COMMENT '货到付款方式.1现金,2POS刷卡',
  `delivery` tinyint(1) DEFAULT NULL COMMENT '送货时间',
  `isConfirm` tinyint(1) DEFAULT NULL COMMENT '是否电话确认 1:是  0: 否',
  `ispaiy` tinyint(1) NOT NULL COMMENT '支付状态 :0到付1待付款,2已付款,3待退款,4退款成功,5退款失败',
  `state` tinyint(1) NOT NULL COMMENT '订单状态 0:提交订单 1:仓库配货 2:商品出库 3:等待收货 4:完成 5待退货 6已退货',
  `createdate` datetime NOT NULL COMMENT '订单生成时间',
  `note` varchar(100) DEFAULT NULL COMMENT '附言',
  `buyerid` int(11) NOT NULL COMMENT '用户名',
  PRIMARY KEY (`id`),
  KEY `buyerid` (`buyerid`),
  CONSTRAINT `bbsorderibfk1` FOREIGN KEY (`buyerid`) REFERENCES `bbsbuyer` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8 COMMENT='订单';

-- ----------------------------
-- Records of bbsorder
-- ----------------------------
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES ('20', '20141212114007973', '0.00', '128', '128', '0', '0', '3', '0', '0', '0', '2014-12-12 11:40:08', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('21', '20141212143650902', '0.00', '600', '600', '1', '0', '3', '0', '1', '0', '2014-12-12 14:36:50', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('22', '20141212153328678', '0.00', '1500', '1500', '1', '0', '3', '0', '1', '0', '2014-12-12 15:33:28', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('24', '20141212161455779', '0.00', '600', '600', '1', '0', '3', '0', '1', '0', '2014-12-12 16:14:55', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('25', '20141212170812625', '0.00', '200', '200', '1', '0', '3', '0', '1', '0', '2014-12-12 17:08:12', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('26', '20141212170911104', '0.00', '128', '128', '0', '0', '3', '0', '0', '0', '2014-12-12 17:09:11', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('27', '20141212170924226', '0.00', '200', '200', '1', '0', '3', '0', '1', '0', '2014-12-12 17:09:24', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('28', '20141212171106201', '0.00', '200', '200', '1', '0', '3', '0', '1', '0', '2014-12-12 17:11:06', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('29', '20141212171115866', '0.00', '128', '128', '1', '0', '3', '0', '1', '0', '2014-12-12 17:11:15', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('30', '20141212171515334', '0.00', '200', '200', '2', '0', '3', '0', '1', '0', '2014-12-12 17:15:15', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('31', '20141212171527396', '0.00', '200', '200', '1', '0', '3', '0', '1', '0', '2014-12-12 17:15:27', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('32', '20141212171537335', '0.00', '300', '300', '1', '0', '3', '0', '1', '0', '2014-12-12 17:15:37', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('33', '20141212172259427', '0.00', '328', '328', '0', '0', '3', '0', '0', '0', '2014-12-12 17:22:59', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('34', '20141212172311831', '0.00', '200', '200', '0', '0', '3', '0', '0', '0', '2014-12-12 17:23:11', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('35', '20141212172817531', '0.00', '128', '128', '1', '0', '3', '0', '1', '0', '2014-12-12 17:28:17', null, '1');
INSERT INTO bbsorder(id,oid,deliverfee,payablefee,totalprice,paymentway,paymentcash,delivery,isConfirm,ispaiy,state,createdate,note,buyerid) VALUES  ('36', '20141212173742147', '0.00', '328', '328', '1', '0', '3', '0', '1', '0', '2014-12-12 17:37:42', null, '1');