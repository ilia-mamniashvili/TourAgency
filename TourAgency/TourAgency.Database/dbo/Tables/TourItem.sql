CREATE TABLE TourItem (
    TourItemID INT PRIMARY KEY IDENTITY(1,1),
    TouristID INT NOT NULL,
    ItemName NVARCHAR(255) NOT NULL,
    Quantity INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    IssueDate DATE,
    ExpiryDate DATE,
    StatusID INT NOT NULL,
    CONSTRAINT FK_TouristItem_Tourist FOREIGN KEY (TouristID) REFERENCES Tourist(TouristID),
    CONSTRAINT FK_TouristItem_Status FOREIGN KEY (StatusID) REFERENCES EntityStatus(StatusID)
);
