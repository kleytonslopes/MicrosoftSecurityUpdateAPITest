CREATE TABLE `t_remediation` (
  `remedi_id` varchar(20) NOT NULL,
  `updite_id` varchar(20) NOT NULL,
  `remedi_url` varchar(255) NOT NULL,
  `remedi_description` varchar(45) NOT NULL,
  PRIMARY KEY (`remedi_id`,`updite_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
