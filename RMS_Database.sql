/* ============================================================
   RMS Database - simple flat structure (matches the forms directly)
   Run this against the RMS.mdf database once, in Server Explorer
   (right click the database > New Query) or in SSMS.
   ============================================================ */

IF OBJECT_ID('Notifications','U') IS NOT NULL DROP TABLE Notifications;
IF OBJECT_ID('Settings','U') IS NOT NULL DROP TABLE Settings;
IF OBJECT_ID('WaterBills','U') IS NOT NULL DROP TABLE WaterBills;
IF OBJECT_ID('ElectricityBills','U') IS NOT NULL DROP TABLE ElectricityBills;
IF OBJECT_ID('RentBills','U') IS NOT NULL DROP TABLE RentBills;
IF OBJECT_ID('Payments','U') IS NOT NULL DROP TABLE Payments;
IF OBJECT_ID('Contracts','U') IS NOT NULL DROP TABLE Contracts;
IF OBJECT_ID('Bookings','U') IS NOT NULL DROP TABLE Bookings;
IF OBJECT_ID('Tenants','U') IS NOT NULL DROP TABLE Tenants;
IF OBJECT_ID('Properties','U') IS NOT NULL DROP TABLE Properties;
IF OBJECT_ID('Users','U') IS NOT NULL DROP TABLE Users;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50),
    Password NVARCHAR(50)
);

CREATE TABLE Properties (
    PropertyID INT IDENTITY(1,1) PRIMARY KEY,
    RollNo NVARCHAR(30),
    PropertyName NVARCHAR(100),
    Category NVARCHAR(30),
    Owner NVARCHAR(100),
    Units NVARCHAR(20),
    Address NVARCHAR(200),
    MonthlyPayment NVARCHAR(30),
    Status NVARCHAR(20),
    DateAdded NVARCHAR(20)
);

CREATE TABLE Tenants (
    TenantID INT IDENTITY(1,1) PRIMARY KEY,
    RollNo NVARCHAR(30),
    TenantName NVARCHAR(100),
    Gender NVARCHAR(10),
    DateOfBirth NVARCHAR(20),
    NationalID NVARCHAR(30),
    Phone NVARCHAR(30),
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Occupation NVARCHAR(100),
    Room NVARCHAR(20),
    MonthlyFee NVARCHAR(30),
    DateAdded NVARCHAR(20),
    Status NVARCHAR(20),
    InRelationship NVARCHAR(10)
);

CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    BookingCode NVARCHAR(30),
    TenantName NVARCHAR(100),
    Item NVARCHAR(100),
    Room NVARCHAR(20),
    MonthlyFee NVARCHAR(30),
    StartDate NVARCHAR(20),
    EndDate NVARCHAR(20),
    Status NVARCHAR(20)
);

CREATE TABLE Contracts (
    ContractID INT IDENTITY(1,1) PRIMARY KEY,
    PropertyName NVARCHAR(100),
    TenantName NVARCHAR(100),
    StartDate NVARCHAR(20),
    EndDate NVARCHAR(20),
    MonthlyPayment NVARCHAR(30),
    Duration NVARCHAR(30),
    PaymentDay NVARCHAR(30),
    Note NVARCHAR(500)
);

CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    TaxID NVARCHAR(30),
    PropertyName NVARCHAR(100),
    TenantName NVARCHAR(100),
    Amount NVARCHAR(30),
    PaymentType NVARCHAR(30),
    PaymentMethod NVARCHAR(20),
    DueDate NVARCHAR(20),
    PayDate NVARCHAR(20),
    Status NVARCHAR(20)
);

CREATE TABLE RentBills (
    RentBillID INT IDENTITY(1,1) PRIMARY KEY,
    PropertyName NVARCHAR(100),
    TenantName NVARCHAR(100),
    BillingMonth NVARCHAR(30),
    Duration NVARCHAR(30),
    PaymentDay NVARCHAR(30),
    DueDate NVARCHAR(20)
);

CREATE TABLE ElectricityBills (
    ElecBillID INT IDENTITY(1,1) PRIMARY KEY,
    TenantUnit NVARCHAR(100),
    ReadingMonth NVARCHAR(30),
    PreviousReading NVARCHAR(30),
    CurrentReading NVARCHAR(30),
    UnitsRate NVARCHAR(30),
    FixedCharge NVARCHAR(30),
    VatPercent NVARCHAR(30),
    TotalAmount NVARCHAR(30)
);

CREATE TABLE WaterBills (
    WaterBillID INT IDENTITY(1,1) PRIMARY KEY,
    TenantUnit NVARCHAR(100),
    ReadingMonth NVARCHAR(30),
    PreviousReading NVARCHAR(30),
    CurrentReading NVARCHAR(30),
    UnitsRate NVARCHAR(30),
    FixedCharge NVARCHAR(30),
    TotalAmount NVARCHAR(30)
);

CREATE TABLE Notifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    Recipient NVARCHAR(150),
    Channel NVARCHAR(30),
    Message NVARCHAR(1000)
);

CREATE TABLE Settings (
    SettingID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(150),
    RegistrationNo NVARCHAR(50),
    Phone NVARCHAR(30),
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Currency NVARCHAR(10),
    TaxRate NVARCHAR(20)
);
GO

INSERT INTO Users (Username, Password) VALUES ('soluiahub', '1234');
INSERT INTO Settings (CompanyName, RegistrationNo, Phone, Email, Address, Currency, TaxRate)
VALUES ('SoluiaRent SARL', 'CR/DLA/2026/B/001', '+237 674 404 735', 'Contact@soluiahub.com', 'Ssadi, Douala, Cameroon', 'XAF', '19.25');
GO
