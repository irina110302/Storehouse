DELIMITER $$

USE `sh_main` $$
DROP FUNCTION IF EXISTS `GetTotalSupplyPrice` $$
CREATE FUNCTION GetTotalSupplyPrice(
	`SupplyId` INT
)
RETURNS DECIMAL(10,2) DETERMINISTIC
BEGIN
	DECLARE `TotalPrice` DECIMAL(10,2);
    SET `TotalPrice` = (SELECT SUM(`Price` * `Amount`) 
		FROM `Product_In_Supply` as `p` 
		WHERE `p`.`SupplyId` = `SupplyId`);
    
    IF `TotalPrice` IS NULL THEN
		RETURN 0;
	ELSE
		RETURN `TotalPrice`;
	END IF;
END$$
       
COMMIT$$

DELIMITER ;