DELIMITER $$

USE `sh_main` $$
DROP FUNCTION IF EXISTS `UpdateReminder` $$

CREATE FUNCTION `UpdateReminder` (
	`SKU` VARCHAR(45),
	`StorehouseId` INT,
	`ReminderDifference` INT,
    `OperationType` CHAR
)
RETURNS INT DETERMINISTIC
BEGIN
	DECLARE newReminder, fixedReminderDifference INT;
	SET newReminder = 0;
    SET fixedReminderDifference = `ReminderDifference`;
    
	IF (SELECT EXISTS(SELECT `Reminder` FROM `Storehouse_Has_Product` as `s`
		WHERE `s`.`StorehouseId` = `StorehouseId`
        AND `s`.`ProductSKU` = `SKU`))
    THEN    
		SET newReminder = (SELECT `Reminder` FROM `Storehouse_Has_Product` as `s`
		WHERE `s`.`StorehouseId` = `StorehouseId`
        AND `s`.`ProductSKU` = `SKU`);
	ELSE
		INSERT INTO `Storehouse_Has_Product` 
        (`Reminder`, `StorehouseId`, `ProductSKU`) 
        VALUES (0, `StorehouseId`, `SKU`);
    END IF;
	
    IF (`OperationType` = '+') 
    THEN
		SET newReminder = newReminder + `ReminderDifference`;
    ELSE
		IF (newReminder > `ReminderDifference`)
        THEN
			SET newReminder = newReminder - `ReminderDifference`;
		ELSE
            SET fixedReminderDifference = newReminder;
			SET newReminder = 0;
        END IF;
    END IF;
    
    UPDATE `Storehouse_Has_Product` as `s` SET
    `s`.`Reminder` = newReminder
    WHERE `s`.`StorehouseId` = `StorehouseId`
	AND `s`.`ProductSKU` = `SKU`;
    
    RETURN fixedReminderDifference;
END$$

DELIMITER ;