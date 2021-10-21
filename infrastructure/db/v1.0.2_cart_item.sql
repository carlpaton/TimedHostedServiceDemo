CREATE TABLE `foo`.`cart_item` (
  `db_id` BIGINT NOT NULL AUTO_INCREMENT,
  `feed_id` VARCHAR(36) NULL,
  `cart_id` BIGINT NOT NULL,
  `quantity` INT NOT NULL,
  `unit_cost` DECIMAL(5,2) NOT NULL,
  CONSTRAINT fk_cart
    FOREIGN KEY (cart_id) 
        REFERENCES cart(db_id)
        ON DELETE CASCADE,
  PRIMARY KEY (`db_id`));