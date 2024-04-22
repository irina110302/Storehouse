DELIMITER $$

USE `sh_main` $$
DROP FUNCTION IF EXISTS `GetSellingPrice` $$

CREATE FUNCTION `GetSellingPrice` (
	`SKU` VARCHAR(45),
    `SupplyId` INT
)
RETURNS DECIMAL(10,2) DETERMINISTIC
BEGIN
	RETURN (SELECT `ps`.`Price` * `s`.`SaleK` FROM `Product_In_Supply` as `ps` 
    JOIN `SKU` as `s` ON `s`.`SKU` = `ps`.`SKU`
    WHERE `ps`.`SupplyId` = `SupplyId`);
END$$

DELIMITER ;

SELECT GetSellingPrice('1', 1);