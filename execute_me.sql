create database vims 

	use vims

	CREATE TABLE userinfo(
    	userID int PRIMARY KEY IDENTITY(1,1),
    	userName varchar(255),
    	userpassword varchar(255)
	);

		

	CREATE TABLE customerinfo(
    	Customer_ID int PRIMARY KEY IDENTITY(1,1),
    	Customer_Name varchar(255),
    	Customer_Address varchar(255),
    	Customer_Phone int
	);

	CREATE TABLE vehicleinfo(
    	Vehicle_ID int PRIMARY KEY IDENTITY(1,1),
    	Vehicle_Name varchar(255),
    	Vehicles_Owner_Address varchar(255),
    	Vehicle_Model varchar(255),
	Vehicle_Version varchar(255),
	Vehicle_Rate int,
	Vehicle_Body_Number varchar(255),
	Vehicle_Engine_Number varchar(255),
	Vehicle_Number int
	);

	CREATE TABLE estimate(
    	Customer_ID int PRIMARY KEY,
    	Estimate_Number int,
	Customer_Name varchar(255),
    	Customer_Phone int,	
	Vehicle_Name varchar(255),
    	Vehicle_Model varchar(255),		
	Vehicle_Rate int,
	Vehicle_Waranty varchar(255),
	Vehicle_Policy_type varchar(255),
	);	

	CREATE TABLE customer_policy_records(
	
	Customer_ID int PRIMARY KEY,
    	Customer_Name varchar(255),
    	Customer_Address varchar(255),
    	Customer_Phone int,
	Policy_ID int,                                             
	Policy_Date varchar(225),
	Policy_duration int,
	Vehicle_ID int,
    	Vehicle_Name varchar(255),
	Vehicle_Model varchar(255),
	Vehicle_Version varchar(255),
	Vehicle_Rate int,
	Vehicle_Warranty varchar(225),
	Vehicle_Body_Number varchar(255),
	Vehicle_Engine_Number varchar(255),
	Customer_Add_Prove varchar(255)
	
	);


	CREATE TABLE billinginfo(
	
	Customer_ID int PRIMARY KEY,
    	Customer_Name varchar(255),
    	Policy_ID int,                                             
	Customer_Add_Prove varchar(255),
	Customer_Phone int,
	Bill_ID int,
    	Vehicle_Name varchar(255),
	Vehicle_Model varchar(255),
	Vehicle_Rate int,
	Vehicle_Body_Number varchar(255),
	Vehicle_Engine_Number varchar(255),
	Date varchar(255),
	Amount int
	
	);






	CREATE TABLE company_expenses(
	
	Expence_ID int PRIMARY KEY IDENTITY(1,1),
	Date_of_Expence varchar(255),
	Type_of_Expence varchar(255),
	Amount_of_Expence varchar(255),
	
	);




	CREATE TABLE claim_datails(
	
	Claim_ID int PRIMARY KEY IDENTITY(1,1),
	Policy_ID int,
	Policy_Start_Date varchar(255),
	Policy_End_Date varchar(255),
	Customer_Name varchar(255),
	Place_Of_Accident varchar(255),
	Date_Of_Accident varchar(255),
	Insured_Amount int,
	Claimable_Amount int

	);



	INSERT INTO userinfo VALUES ('user', 'user');
	INSERT INTO userinfo VALUES ('admin', 'admin');
