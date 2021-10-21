CREATE TABLE `foo`.`cart` (
  `db_id` BIGINT NOT NULL AUTO_INCREMENT,
  `feed_id` BIGINT NOT NULL,
  `user_id` VARCHAR(36) NULL,
  `date_utc` DATETIME NULL,
  PRIMARY KEY (`db_id`));