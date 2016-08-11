--This is inserting employer contact info into employer and inserting data(values) for all the columns 
INSERT INTO employer (company, contactfirstname, contactlastname, address, username, contactinfo)
VALUES('Hyland', 'James', 'Vorous','Westlake, OH','pokemonGo69', 'J.valous@onbase.com');

--inserting a staff member with Josh and info(values) into the columns columns 
INSERT INTO staff (firstname, lastname, title, username)
Values('Josh', 'Tucholski', 'Instructor', 'jTucholski');

-- Now createing a user and password for Josh in the user_password table which is keyed to student, staff, and employer.
insert into user_password (username, password, role_title)
values ('jTucholski', 'password', 'Staff');

-- same as the staff, but now it is populating student table and columns 
INSERT INTO student (firstname, lastname, class, summary, perviousexperience, contactinfo, username)
VALUES('Kyle', 'Pierson', '.NET', 'I am the best .NET student in this bitch', 'Bindows', 'myShitIsLegit@yahoo.com', 'TolegitToQuit');

--since the staff creates the student profile.
INSERT INTO student (firstname, lastname, class, summary, perviousexperience, contactinfo, username)
VALUES('Simin', 'Nickelsen', '.NET', 'I am rocking dis shit', 'Adobe', '432-345-543', 'siminN');

--inserting Adchiever into softskills table and only have to define ( skill). 
--The skill_id is already generated when a new skill is inserted
INSERT INTO softskills ( skill)
VALUES ('Adchiever');

--Same as above.
INSERT INTO softskills ( skill)
VALUES ('Detail oriented');

--Same as above
INSERT INTO softskills ( skill)
VALUES ('Listener');

-- Now if want assign a student with a soft skill, we insert id values into student_softskills.
--the (student_id, softskill_id) are the only two columns in student_softskills.
--So (1) pertains to Kyle and (1002) refers to Detailed oriented soft skill(softskill_id)
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (1,1002);

--This is Simin(student_id 2) and assigning her Listener(softskill_id 1003)
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,1003);

-- Assigning simin the softskill(1004) adchiever.
--INSERT INTO student_softskills (student_id, softskill_id)
--VALUES (2,1004);

--creating a project to assign to a student(project_id = 1)
INSERT INTO project (title, summary)
Values ('Vending machine', 'people paid money and got snacks');

--assigning Simin(2) to a project(Venting Machine(1))
INSERT INTO project_student (student_id, project_id)
VALUES (2,1);

--  assigning Kyle, using username to identify him, a password and roll
INSERT INTO user_passord (username, password, role_title)
VALUES ('TolegitToQuit', 'password', 'Student')

--  assigning Simin, using username to identify her, a password and roll
INSERT INTO user_passord (username, password, role_title)
VALUES ('siminN', 'password', 'Student')

--  assigning James, using username to identify him, a password and roll
INSERT INTO user_passord (username, password, role_title)
VALUES ('pokemonGo69', 'password', 'Employer')

--  assigning Josh, using username to identify him, a password and roll
INSERT INTO user_passord (username, password, role_title)
VALUES ('jTucholski', 'password', 'Staff')

--using the student_id (2) to insert data in academic
INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 2, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science')

--using the student_id (2) to insert data in academic
INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 1, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science')

--This is just some shit
SELECT *
FROM softskills
