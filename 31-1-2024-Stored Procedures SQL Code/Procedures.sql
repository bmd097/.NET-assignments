--CREATE DATABASE crud_procedures_db;

--CREATE TABLE CoffeeItems (
--	_id int primary key,
--	_name nvarchar(50) not null,
--	_description nvarchar(100) not null,
--	_createdAt datetime,
--	_type int not null check(_type in (1,2,3)),
--	foreign key(_type) references CoffeeType(_type)
--);

--CREATE TABLE CoffeeType (
--	_type int primary key,
--	_origin varchar(30) not null,
--	_quality int not null
--);

--INSERT INTO CoffeeType VALUES 
--	(1,'INDIAN',4),
--	(2,'BRAZILIAN',5),
--	(3,'CHINESE',2);


--SELECT * FROM CoffeeType;

--INSERT INTO CoffeeItems VALUES
--(4,'Expresso','Dark coffee!',GETDATE(),2),
--(5,'Light Coffee','Skinny coffee!',GETDATE(),3);

--INSERT INTO CoffeeItems VALUES
--(3,'Cappacino','Actually tastes like coffee!',GETDATE(),1);

--SELECT * FROM CoffeeItems;

--UPDATE CoffeeItems SET _description = 'It really feels good to drink that!' where _type = 1;

--DELETE FROM CoffeeItems where _id = 3;

--SELECT 
--	_id as id,
--	_name as [name],
--	_description as [description],
--	ci._type as [type],
--	_origin as origin,
--	_quality as quality
--from CoffeeItems ci
--join CoffeeType ct on ci._type = ct._type;

--CREATE PROCEDURE GetCoffeeItem
--    @id INT
--AS
--BEGIN
--    SELECT
--		_id as id,
--		_name as [name],
--		_description as [description],
--		ci._type as [type],
--		_origin as origin,
--		_quality as quality
--	from CoffeeItems ci
--	join CoffeeType ct on ci._type = ct._type
--	where _id = @id
--END

-- DROP PROCEDURE GetCoffeeItem;

 --EXEC GetCoffeeItem 4

--CREATE PROCEDURE UpdateCoffeeItemDescription
--    @type INT,
--    @description NVARCHAR(MAX)
--AS
--BEGIN
--    UPDATE CoffeeItems
--    SET _description = @description
--    WHERE _type = @type;
--END

--EXEC UpdateCoffeeItemDescription @type = 2, @description = 'Very Intense Coffee Man!';
--EXEC GetCoffeeItem 4

--CREATE PROCEDURE GetAllCoffeeItems
--AS
--    SELECT
--		_id as id,
--		_name as [name],
--		_description as [description],
--		ci._type as [type],
--		_origin as origin,
--		_quality as quality
--	from CoffeeItems ci
--	join CoffeeType ct on ci._type = ct._type;

--EXEC GetAllCoffeeItems;

--CREATE PROCEDURE DeleteCoffeeItem
--    @id INT
--AS
--BEGIN
--    DELETE FROM CoffeeItems
--    WHERE _id = @id;
--END

--CREATE PROCEDURE InsertCoffeeItem
--    @id INT,
--    @name NVARCHAR(50),
--    @description NVARCHAR(MAX),
--    @type INT
--AS
--BEGIN
--    INSERT INTO CoffeeItems
--    VALUES (@id, @name, @description, GETDATE(), @type);
--END

--EXEC InsertCoffeeItem @id = 6, @name = 'Filter Coffee', @description = 'Extreme Intense Coffee', @type = 1;

--EXEC GetAllCoffeeItems;
--EXEC DeleteCoffeeItem 6;

