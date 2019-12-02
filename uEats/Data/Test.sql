INSERT INTO Foods (FoodName, FoodCategory) VALUES 
('Popcorn', 'Fibre'),
('Kacchi Biriyani', 'Spicy'),
('Chicken Biriyani', 'Spicy'),
('Fish Fry', 'Fibre'),
('Good morning breads', 'Fibre'),
('Beef Tehari', 'Spicy'),
('Mountain Dew', 'Drinks'),
('Pepsi', 'Drinks'),
('Coca Cola', 'Drinks'),
('Sandesh', 'Sweets'),
('Yogurt', 'Sweets'); 

CREATE PROCEDURE GetFoodsByCategory
@category nvarchar(max)
AS
BEGIN
    SELECT * FROM Foods WHERE FoodCategory = @category
END