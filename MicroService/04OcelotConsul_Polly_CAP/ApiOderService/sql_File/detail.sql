-- ----------------------------
-- Table structure for `detail`
-- ----------------------------
DROP TABLE IF EXISTS `detail`;
CREATE TABLE `detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `orderid` int(11) NOT NULL COMMENT '订单ID',
  `productno` varchar(255) DEFAULT NULL COMMENT '商品编号',
  `productname` varchar(255) DEFAULT NULL COMMENT '商品名称',
  `color` varchar(11) NOT NULL COMMENT ' 颜色名称',
  `size` varchar(11) NOT NULL COMMENT '尺码',
  `skuprice` double NOT NULL COMMENT '商品销售价',
  `amount` int(11) NOT NULL COMMENT '购买数量',
  PRIMARY KEY (`id`),
  KEY `fkorderid` (`orderid`),
  CONSTRAINT `fkorderid` FOREIGN KEY (`orderid`) REFERENCES `order` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8 COMMENT='订单详情';

-- ----------------------------
-- Records of detail
-- ----------------------------
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES ('28', '20', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '507', '275', '128', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('29', '21', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '511', '275', '300', '2');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('30', '22', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '513', '275', '200', '5');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('31', '22', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '511', '275', '300', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('32', '22', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '512', '275', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('33', '24', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('34', '24', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '桃粉', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('35', '24', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'XXL', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('36', '25', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('37', '26', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '海军蓝', 'S', '128', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('38', '27', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '桃粉', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('39', '28', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('40', '29', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '海军蓝', 'S', '128', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('41', '30', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('42', '31', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '桃粉', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('43', '32', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'XL', '300', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('44', '33', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('45', '33', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '海军蓝', 'S', '128', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('46', '34', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '桃粉', 'S', '200', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('47', '35', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '海军蓝', 'S', '128', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('48', '36', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '海军蓝', 'S', '128', '1');
INSERT INTO detail(id,orderid,productno,productname,color,size,skuprice,amount) VALUES  ('49', '36', '20141028114510055', '依琦莲2014瑜伽服套装新款 瑜珈健身服三件套 广场舞蹈服装 性价比最高的瑜伽服 三件套 送胸垫 支持货到付款', '纯黑', 'S', '200', '1');
