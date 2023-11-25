﻿use master
go
drop database midterm
go
create database midterm
go
use midterm
go

-- Table for car types
CREATE TABLE TypeCar (
    typeCarID INT PRIMARY KEY ,
    typeName NVARCHAR(255) NOT NULL,
	price float not null
);
GO
drop table car
-- Table for managing cars
CREATE TABLE Car (
    carID INT PRIMARY KEY IDENTITY,
    carName VARCHAR(255) NOT NULL,
    typeCarID INT,
    nhienLieuID NVarchar(100),
    FOREIGN KEY (typeCarID) REFERENCES TypeCar(typeCarID),
);
GO
-- Table for function cars
CREATE TABLE Feature(
    id INT PRIMARY KEY IDENTITY,
    nameFeature NVARCHAR(255) NOT NULL
);

-- Table for car features (Many-to-Many relationship)
CREATE TABLE CarFeature (
    carID INT,
    featureID INT,
    PRIMARY KEY (carID, featureID),
    FOREIGN KEY (carID) REFERENCES Car(carID)  ON DELETE CASCADE,
    FOREIGN KEY (featureID) REFERENCES Feature(id)
);
GO

CREATE TABLE Customer (
	id int  primary KEY identity ,
	nameCustomer nvarchar(255) not null,
	phoneCustomer nvarchar(12) not null,
	addressCustomer nvarchar(255) not null,
	gender nvarchar(12) not null,
)
GO

CREATE TABLE MyOrder (
	id int  primary KEY identity ,
	customerId INT,
	FOREIGN KEY (customerId) REFERENCES Customer(id),
	carID INT not null,
	FOREIGN KEY (carID) REFERENCES Car(carID),
	RentalTime datetime not null,
	RentalDay int , 
	RentailTimeLimit datetime not null,
	status bit not null,
	total float not null,
)
go

GO
INSERT INTO feature (nameFeature)
VALUES
	(N'Bản đồ'),
	(N'Camera cập lể'),
	(N'Cảm biến lốp'),
	(N'Cửa sổ trời'),
	(N'Khe cắm USB'),
	(N'Nắp thùng bán xe tải'),
	(N'Bluetooth'),
	(N'Camera hành trình'),
	(N'Cảm biến va chạm'),
	(N'Định vị GPS'),
	(N'Lốp dự phòng'),
	(N'Camera 360'),
	(N'Camera lùi'),
	(N'Cảnh báo tốc độ')

INSERT INTO TypeCar (typeCarID, typeName, price)
VALUES
    (1, N'(4 chỗ) Mini' , 123),
    (2, N'(4 chỗ) Sedan'  , 46),
    (3, N'(4 chỗ) Hatchback' , 1),
	(4, N'(5 chỗ) CUV Gầm Cao' , 7),
	(5, N'(7 chỗ) SUV Gầm Cao' , 9),
	(6, N'(7 chỗ) MPV Gầm thấp', 100),
	(7, N'Bán tải' , 239);

INSERT INTO Car (carName, typeCarID, nhienLieuID)
VALUES
    ('Car1', 1, 1), 
    ('Car2', 2, 2), 
    ('Car3', 3, 3)

INSERT INTO CarFeature (carID, featureID)
VALUES
    (1, 1)

INSERT INTO Customer (nameCustomer , phoneCustomer , addressCustomer , gender)
VALUES
    (N'Cao Nguyên Bình' , '0942563747',  N'Quận 5 thành phố Hồ Chí Minh', N'Nam'),
    (N'Nguyễn Huy Hòa' , '0876942257',  N'Quận 7 thành phố Hồ Chí Minh', N'Nam'),
    (N'Nguyễn Thái Tuệ' , '0781743664',  N'Quận 6 thành phố Hồ Chí Minh', N'Nữ'),
	(N'Lê Trần Quỳnh Như' , '0853080080',  N'Quận 4 thành phố Hồ Chí Minh', N'Nữ'),
	(N'Lưu Ngọc Đỉnh' , '0834353676',  N'Quận 3 thành phố Hồ Chí Minh', N'Nam'),
	(N'Nguyễn Tiến Đạt' , '0346844581',  N'Quận 9 thành phố Hồ Chí Minh', N'Nam'),
	(N'Huỳnh Ngọc Hân' , '0245633256',  N'Quận 2 thành phố Hồ Chí Minh', N'Nữ')