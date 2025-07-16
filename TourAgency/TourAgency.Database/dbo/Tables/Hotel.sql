CREATE TABLE Hotel (
    HotelID INT PRIMARY KEY IDENTITY(1,1),
    HotelName NVARCHAR(255) NOT NULL,
    CityID INT NOT NULL,
    StarRatingID INT NOT NULL,
    Address NVARCHAR(500),
    ContactNumber NVARCHAR(50),
    Website NVARCHAR(255),
    CONSTRAINT FK_Hotel_City FOREIGN KEY (CityID) REFERENCES City(CityID),
    CONSTRAINT FK_Hotel_StarRating FOREIGN KEY (StarRatingID) REFERENCES StarRating(RatingID)
);