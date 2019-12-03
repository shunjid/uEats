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

