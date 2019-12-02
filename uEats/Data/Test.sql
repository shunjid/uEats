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

INSERT INTO Locations(LocationName, LocationCity) VALUES
('Rayerbag', 'Dhaka'),
('Jatrabari', 'Dhaka'),
('Kadamtali', 'Dhaka'),
('Shyampur', 'Dhaka'),
('Kajla', 'Dhaka'),
('Shanir Akhra', 'Dhaka'),
('Chaan Khar Pool', 'Dhaka'),
('Bakhshi Bazar', 'Dhaka'),
('Dhanmondi-32', 'Dhaka'),
('Shukrabad', 'Dhaka'),
('Mirpur 01', 'Dhaka'),
('Shyamoli', 'Dhaka'),
('Agrabad', 'Chittagong'),
('Chashara', 'Narayanganj'),
('Babupara', 'Kushtia');