DELIMITER $$

USE `sh_main` $$
DROP FUNCTION IF EXISTS `GetReminderByProduct` $$

CREATE FUNCTION `GetReminderByProduct` (
	`ProductId` INT,
    `StorehouseId` INT
)
RETURNS INT DETERMINISTIC
BEGIN
	RETURN (SELECT SUM(GetReminderBySKU(`s`.`SKU`, `StorehouseId`)) FROM `Product` as `p` 
    JOIN `SKU` as `s` ON `p`.`Id` = `s`.`ProductId`
    WHERE `p`.`Id` = `ProductId`);
END$$

DELIMITER ;