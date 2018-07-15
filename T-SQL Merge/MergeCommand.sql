/* CREATE TABLES */
CREATE TABLE Users (
   Username VARCHAR(32) NOT NULL,
   Email VARCHAR(128) NOT NULL,
   FirstName VARCHAR(32) NOT NULL,
   LastName VARCHAR(32) NOT NULL,
   FavouriteColor VARCHAR(16) NOT NULL,
   CreateDate DATETIME NOT NULL,
   LastUpdate DATETIME NOT NULL
)

CREATE TABLE UsersUpdate (
    UpdateUsername VARCHAR(32) NOT NULL,
    UpdateEmail VARCHAR(128) NOT NULL,
    UpdateFirstName VARCHAR(32) NOT NULL,
    UpdateLastName VARCHAR(32) NOT NULL,
    UpdateFavouriteColor VARCHAR(32) NOT NULL
)


/* ACTUAL MERGE COMMAND */
MERGE Users AS [destination]
USING (
    SELECT
        UpdateUsername,
        UpdateEmail,
        UpdateFirstName,
        UpdateLastName,
        UpdateFavouriteColor
    FROM UsersUpdate
) AS [origin]
ON [origin].UpdateUsername = [destination].Username
WHEN MATCHED THEN UPDATE
    SET [destination].Email = [origin].UpdateEmail,
        [destination].FirstName = [origin].UpdateFirstName,
        [destination].LastName= [origin].UpdateLastName,
        [destination].FavouriteColor = [origin].UpdateFavouriteColor,
        [destination].LastUpdate = GETDATE()
WHEN NOT MATCHED THEN INSERT (
    Username,
    Email,
    FirstName,
    LastName,
    FavouriteColor,
    CreateDate,
    LastUpdate
)
VALUES (
        [origin].UpdateUsername,
        [origin].UpdateEmail,
        [origin].UpdateFirstName,
        [origin].UpdateLastName,
        [origin].UpdateFavouriteColor,
        GETDATE(),
        GETDATE()
);