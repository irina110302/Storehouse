DELIMITER $$

USE `sh_main` $$
DROP PROCEDURE IF EXISTS `GetReminderBySKU` $$

CREATE FUNCTION `GetReminderBySKU` (
	`SKU` VARCHAR(45),
    `StorehouseId` INT
)
RETURNS INT DETERMINISTIC
BEGIN
	DECLARE input, output INT;
    
    SET input = (SELECT SUM(`ps`.`Amount`) FROM `Supply` as `s` 
    JOIN `Product_In_Supply` as `ps` ON `s`.`Id` = `ps`.`SupplyId`
    WHERE `s`.`StorehouseId` = `StorehouseId` AND `ps`.`SKU` = `SKU`);
    
    SET output = (SELECT SUM(`pp`.`Amount`) FROM `Purchase` as `p` 
    JOIN `Product_In_Purchase` as `pp` ON `p`.`Id` = `pp`.`PurchaseId`
    WHERE `p`.`StorehouseId` = `StorehouseId` AND `pp`.`SKU` = `SKU`);
    
    RETURN input - output;
END$$

DELIMITER ;