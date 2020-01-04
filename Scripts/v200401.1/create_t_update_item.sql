CREATE TABLE `t_update_item` (
  `updite_id` VARCHAR(20) NOT NULL,
  `updite_alias` VARCHAR(20) NOT NULL,
  `updite_document_title` VARCHAR(150) NOT NULL,
  `updite_severity` VARCHAR(150) NULL,
  `updite_initial_release_date` DATETIME NOT NULL,
  `updite_current_release_date` VARCHAR(45) NOT NULL,
  `updite_cvrf_url` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`updite_id`),
  UNIQUE INDEX `idt_update_item_UNIQUE` (`updite_id` ASC));