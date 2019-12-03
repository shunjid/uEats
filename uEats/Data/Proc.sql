CREATE PROCEDURE get_sp_AllAvailableLocations
AS
BEGIN
    SELECT * FROM Locations;
END
go



CREATE PROCEDURE sp__UpgradeRestaurantInformation
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
go



CREATE PROCEDURE sp__PushNewItemOfTheRestaurant
@foodId int,
@restaurantId nvarchar(450),
@added datetime2,
@price real
AS
BEGIN
    INSERT INTO FoodRestaurants(FoodId, RestaurantId, AddedIn, FoodRestaurantPrice)
    VALUES (@foodId, @restaurantId, @added, @price);

    declare @numberOfFoodsOfTheRestaurant int = (SELECT COUNT(FoodId) FROM FoodRestaurants WHERE RestaurantId = @restaurantId)

    if @numberOfFoodsOfTheRestaurant >= 2 AND @numberOfFoodsOfTheRestaurant <=5
        UPDATE Restaurants SET RestaurantStatus = 'Star' WHERE RestaurantId = @restaurantId
    else if @numberOfFoodsOfTheRestaurant > 5 AND @numberOfFoodsOfTheRestaurant <=8
        UPDATE Restaurants SET RestaurantStatus = 'Premium' WHERE RestaurantId = @restaurantId
    else if @numberOfFoodsOfTheRestaurant > 8 AND @numberOfFoodsOfTheRestaurant <=10
        UPDATE Restaurants SET RestaurantStatus = 'Golden' WHERE RestaurantId = @restaurantId
    else
        BEGIN
            UPDATE Restaurants SET RestaurantStatus = 'Nawab' WHERE RestaurantId = @restaurantId
        END
END