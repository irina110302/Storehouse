DELIMITER $$

USE `sh_main` $$
DROP FUNCTION IF EXISTS `GetSku` $$
CREATE FUNCTION GetSku(
	`ProductId` INT,
    `ProductionDate` DATETIME,
    `SaleK` DECIMAL(10, 2)
)
RETURNS VARCHAR(45) DETERMINISTIC
BEGIN
	DECLARE `Name`, `Manufacturer` VARCHAR(255);
    DECLARE `SKU` VARCHAR(45);
	
    IF EXISTS (SELECT * FROM `Product` as `p` WHERE `p`.`Id` = `ProductId`) 
    THEN
		SET `SKU` = (SELECT CalculateSKU(`ProductId`, `ProductionDate`));
        
        IF NOT EXISTS (SELECT * FROM `SKU` as `s` WHERE `s`.`SKU` = `SKU`)
        THEN
			INSERT INTO `SKU`(`SKU`, `ProductId`, `ProductionDate`, `SaleK`) 
			VALUES (`SKU`, `ProductId`, `ProductionDate`, `SaleK`);
		END IF;
        
        RETURN `SKU`;
    ELSE 
		RETURN "error";
    END IF;
END$$
       
COMMIT$$

DELIMITER ;