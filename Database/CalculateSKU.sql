DELIMITER $$

USE `sh_main` $$

DROP FUNCTION IF EXISTS `SPLIT_STR` $$
CREATE FUNCTION SPLIT_STR(
  x VARCHAR(255),
  delim VARCHAR(12),
  pos INT
)
RETURNS VARCHAR(255) DETERMINISTIC
RETURN REPLACE(SUBSTRING(SUBSTRING_INDEX(x, delim, pos),
       LENGTH(SUBSTRING_INDEX(x, delim, pos -1)) + 1),
       delim, '')$$

COMMIT$$

DROP FUNCTION IF EXISTS `GET_PREFIX` $$
CREATE FUNCTION GET_PREFIX(
  x VARCHAR(255)
)
RETURNS VARCHAR(255) DETERMINISTIC
BEGIN
	IF CHAR_LENGTH(SPLIT_STR(x, ' ', 2)) = 0
    THEN
		IF CHAR_LENGTH(x) > 3 
        THEN
			RETURN UPPER(SUBSTR(x, 1, 4));
        ELSE
			RETURN UPPER(CONCAT(x, SUBSTR('????', 1, 4 - CHAR_LENGTH(x))));
		END IF;
    ELSE
		RETURN UPPER(CONCAT(
			SUBSTR(SPLIT_STR(x, ' ', 1), 1, 2), 
            SUBSTR(SPLIT_STR(x, ' ', 2), 1, 2)
		));
    END IF;
END$$
       
COMMIT$$

DROP FUNCTION IF EXISTS `CalculateSKU` $$
CREATE FUNCTION `CalculateSKU` (
	`DescriptionId` INT,
    `ProductionDate` DATETIME
)
RETURNS VARCHAR(45) DETERMINISTIC
BEGIN
	RETURN (SELECT 
    CONCAT(GET_PREFIX(`Name`),
    '-',
    GET_PREFIX(`Manufacturer`),
    '-',
    (SELECT DATE_FORMAT(`ProductionDate`, '%d-%m-%y')))  as `SKU`
    FROM `Product` AS `p` WHERE `p`.`Id` = `DescriptionId`);
END$$

DELIMITER ;

# SELECT `CalculateSKU`(1, NOW())