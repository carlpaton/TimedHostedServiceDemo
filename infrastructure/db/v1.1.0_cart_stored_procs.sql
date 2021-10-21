USE foo;

DROP PROCEDURE IF EXISTS sp_addcart;
DROP PROCEDURE IF EXISTS sp_updatecart;
DROP PROCEDURE IF EXISTS sp_deletecart;

DELIMITER $$

-- INSERT
CREATE PROCEDURE sp_addcart(IN FeedId BIGINT, IN UserId VARCHAR(36), IN DateUtc DATETIME)
BEGIN
	INSERT INTO cart
        (feed_id, user_id, date_utc)
        VALUES
        (FeedId, UserId, DateUtc);
        
    SELECT LAST_INSERT_ID();
END $$

-- UPDATE
CREATE PROCEDURE sp_updatecart(IN DbId BIGINT, IN FeedId BIGINT, IN UserId VARCHAR(36), IN DateUtc DATETIME)
BEGIN
	UPDATE cart SET
		feed_id = FeedId,
		user_id = UserId,
		date_utc = DateUtc
		WHERE db_id = DbId;
        
    SELECT LAST_INSERT_ID();
END $$

-- DELETE
CREATE PROCEDURE sp_deletecart(IN CartId BIGINT)
BEGIN
	DELETE FROM cart
    WHERE db_id = CartId;
END $$

DELIMITER ;