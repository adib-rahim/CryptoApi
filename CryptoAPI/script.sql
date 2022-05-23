CREATE DATABASE CRYPTODATABASE;

CREATE TABLE CURRENCYCATEGORY (
    ID INT NOT NULL AUTO_INCREMENT,
    CATEGORY VARCHAR (100) NOT NULL,
    PRIMARY KEY ( ID )
);

INSERT INTO `CRYPTODATABASE`.`currencycategory` (`CATEGORY`) VALUES ('Decentralized Money');
INSERT INTO `CRYPTODATABASE`.`currencycategory` (`CATEGORY`) VALUES ('GameFI/Play2Earn');
INSERT INTO `CRYPTODATABASE`.`currencycategory` (`CATEGORY`) VALUES ('Metaverse');

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create table CURRENCYSYMBOL(
   Id INT NOT NULL AUTO_INCREMENT,
   SYMBOL VARCHAR (50) NOT NULL,
   PRICE DECIMAL(19, 2) NOT NULL,
   CategoryId INT,
   PRIMARY KEY ( Id )
);

ALTER TABLE CURRENCYSYMBOL
ADD CHECK (PRICE>0); 

ALTER TABLE CURRENCYSYMBOL
ADD FOREIGN KEY (CategoryId) REFERENCES CURRENCYCATEGORY (ID);

INSERT INTO `CRYPTODATABASE`.`currencysymbol` (`SYMBOL`,`PRICE`,`CategoryId`) VALUES('BTC',40000,1);
INSERT INTO `CRYPTODATABASE`.`currencysymbol` (`SYMBOL`,`PRICE`,`CategoryId`) VALUES('MAGIC',2.50,2);
INSERT INTO `CRYPTODATABASE`.`currencysymbol` (`SYMBOL`,`PRICE`,`CategoryId`) VALUES('SAND',3.20,3);


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

SELECT * FROM `CRYPTODATABASE`.`currencycategory`;
SELECT * FROM `CRYPTODATABASE`.`currencysymbol`;