CREATE TABLE StarRating (
    RatingID INT PRIMARY KEY IDENTITY(1,1),
    RatingValue INT NOT NULL UNIQUE CHECK (RatingValue >= 1 AND RatingValue <= 5),
    RatingDescription NVARCHAR(50)
);
