CREATE TABLE TourBooking (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    TouristID INT NOT NULL,
    TourID INT NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETDATE(),
    NumberOfAdults INT NOT NULL CHECK (NumberOfAdults > 0),
    NumberOfChildren INT NOT NULL DEFAULT 0 CHECK (NumberOfChildren >= 0),
    TotalPrice DECIMAL(18, 2) NOT NULL CHECK (TotalPrice >= 0),
    PaymentStatus NVARCHAR(50) NOT NULL, -- e.g., 'Paid', 'Pending', 'Refunded', 'Partially Paid'
    StatusID INT NOT NULL, -- e.g., 'Confirmed', 'Cancelled', 'Completed'
    CONSTRAINT FK_TourBooking_Tourist FOREIGN KEY (TouristID) REFERENCES Tourist(TouristID),
    CONSTRAINT FK_TourBooking_Tour FOREIGN KEY (TourID) REFERENCES Tour(TourID),
    CONSTRAINT FK_TourBooking_Status FOREIGN KEY (StatusID) REFERENCES EntityStatus(StatusID)
);