USE foo;

DROP PROCEDURE IF EXISTS sp_addcartitem;
DROP PROCEDURE IF EXISTS sp_updatecartitem;
DROP PROCEDURE IF EXISTS sp_deletecartitem;

DELIMITER $$

-- INSERT
CREATE PROCEDURE sp_addcartitem(IN FeedId VARCHAR(36), IN CartId BIGINT, IN Quantity INT, IN UnitCost DECIMAL(5,2))
BEGIN
	INSERT INTO cart_item
        (feed_id, cart_id, quantity, unit_cost)
        VALUES
        (FeedId, CartId, Quantity, UnitCost);
        
    SELECT LAST_INSERT_ID();
END $$

-- UPDATE
CREATE PROCEDURE sp_updatecartitem(IN DbId BIGINT, IN FeedId VARCHAR(36), IN CartId BIGINT, IN Quantity INT, IN UnitCost DECIMAL(5,2))
BEGIN
	UPDATE cart_item SET
		feed_id = FeedId,
		cart_id = CartId,
		quantity = Quantity,
		unit_cost = UnitCost
		WHERE db_id = DbId;
        
    SELECT LAST_INSERT_ID();
END $$

-- DELETE
CREATE PROCEDURE sp_deletecartitem(IN CartItemId BIGINT)
BEGIN
	DELETE FROM cart_item
    WHERE db_id = CartItemId;
END $$

DELIMITER ;