CREATE TABLE Tour (
    TourID INT PRIMARY KEY IDENTITY(1,1), 
    TourName NVARCHAR(255) NOT NULL,     
    Destination NVARCHAR(255) NOT NULL,  
    DurationDays INT NOT NULL,          
    Price DECIMAL(18, 2) NOT NULL
);