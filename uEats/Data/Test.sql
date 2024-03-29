﻿INSERT INTO Foods (FoodName, FoodCategory) VALUES 
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

CREATE PROCEDURE UpdateRestaurantInformation
@restaurantId nvarchar(max),
@restaurantName nvarchar(max),
@locationId int
AS
BEGIN
    UPDATE Restaurants
    SET RestaurantName = @restaurantName, LocationId = @locationId
    WHERE RestaurantId = @restaurantId;
    
    SELECT * FROM Restaurants WHERE RestaurantId = @restaurantId;
END

/*SqlParameter param1 = new SqlParameter("@p0",restaurant.RestaurantId);
SqlParameter param2 = new SqlParameter("@p1", restaurant.RestaurantName);
SqlParameter param3 = new SqlParameter("@p2", restaurant.Location.LocationId);

var res = _context.Restaurants
    .FromSqlRaw("UpdateRestaurantInformation @p0,@p1,@p2", param1, param2, param3)
    .ToList();*/

/*var res = await _context.Database.ExecuteSqlInterpolatedAsync(
    $"EXEC UpdateRestaurantInformation @restaurantId={restaurant.RestaurantId}, @restaurantName={restaurant.RestaurantName}, @locationId = {restaurant.Location.LocationId}");
*/