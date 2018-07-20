DELETE FROM park;
DELETE FROM weather;
DELETE FROM survey_result;

SET IDENTITY_INSERT park ON;
INSERT park VALUES ('TEST', 'Test Park 1', 'TS', 1, 1, 1, 0, 'Test Climate', 1, 1, 'Test Quote', 'Quote Dude', 'Test Description', 1, 1);
SET IDENTITY_INSERT park OFF;

SET IDENTITY_INSERT weather ON;
INSERT INTO weather VALUES (1,'TEST',1,1,1,'test');
INSERT INTO weather VALUES (2,'TEST',2,1,1,'test');
INSERT INTO weather VALUES (3,'TEST',3,1,1,'test');
INSERT INTO weather VALUES (4,'TEST',4,1,1,'test');
INSERT INTO weather VALUES (5,'TEST',5,1,1,'test');
SET IDENTITY_INSERT weather OFF;

SET IDENTITY_INSERT survey_result ON;
INSERT INTO survey_result(1,'TEST','TestEmail','TS','test activity');
SET IDENTITY_INSERT survey_result OFF;