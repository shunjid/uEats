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

CREATE PROCEDURE get_sp_StatusOfTheRestaurant
@numberOfFoodsOfTheRestaurant int,
@resId nvarchar(450)
AS
BEGIN
    if @numberOfFoodsOfTheRestaurant < 1
        UPDATE Restaurants SET RestaurantStatus = 'Silver' WHERE RestaurantId = @resId
    else if @numberOfFoodsOfTheRestaurant >= 1 AND @numberOfFoodsOfTheRestaurant <3
        UPDATE Restaurants SET RestaurantStatus = 'Star' WHERE RestaurantId = @resId
    else if @numberOfFoodsOfTheRestaurant >= 3 AND @numberOfFoodsOfTheRestaurant <=5
        UPDATE Restaurants SET RestaurantStatus = 'Premium' WHERE RestaurantId = @resId
    else if @numberOfFoodsOfTheRestaurant > 5 AND @numberOfFoodsOfTheRestaurant <=7
        UPDATE Restaurants SET RestaurantStatus = 'Golden' WHERE RestaurantId = @resId
    else
        BEGIN
            UPDATE Restaurants SET RestaurantStatus = 'Nawaab' WHERE RestaurantId = @resId
        END
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

    EXEC get_sp_StatusOfTheRestaurant @numberOfFoodsOfTheRestaurant, @restaurantId;
END
go


CREATE PROCEDURE sp__RemoveItemOfTheRestaurant
@foodId int,
@restaurantId nvarchar(450)
AS
BEGIN
    DELETE FROM FoodRestaurants 
    WHERE FoodRestaurants.RestaurantId = @restaurantId AND FoodRestaurants.FoodId = @foodId;

    declare @numberOfFoods int = (SELECT COUNT(FoodId) FROM FoodRestaurants WHERE RestaurantId = @restaurantId)
    EXEC get_sp_StatusOfTheRestaurant @numberOfFoods, @restaurantId;
END
go


