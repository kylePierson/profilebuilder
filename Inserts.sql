-----------------------------------------------------------------------------------
--Employer
--  assigning James, using username to identify him, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('pokemonGo69', 'password', 'Employer');


--This is inserting employer contact info into employer and inserting data(values) for all the columns 
INSERT INTO employer (company, contactfirstname, contactlastname, address, username, contactinfo)
VALUES('Hyland', 'James', 'Vorous','Westlake, OH','pokemonGo69', 'J.valous@onbase.com');
-----------------------------------------------------------------------------------
--Staff

--  assigning Josh, using username to identify him, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('jTucholski', 'password', 'Staff');

--inserting a staff member with Josh and info(values) into the columns columns 
INSERT INTO staff (firstname, lastname, title, username)
Values('Josh', 'Tucholski', 'Instructor', 'jTucholski');
-----------------------------------------------------------------------------------
--Students

--  assigning Kyle, using username to identify him, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('TolegitToQuit', 'password', 'Student');

-- same as the staff, but now it is populating student table and columns 
INSERT INTO student (firstname, lastname, class, summary, previousexperience, contactinfo, username)
VALUES('Kyle', 'Pierson', '.NET', 'I am the best .NET student in this bitch', 'Bindows', 'myShitIsLegit@yahoo.com', 'TolegitToQuit');


--  assigning Simin, using username to identify her, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('siminN', 'password', 'Student');

--since the staff creates the student profile.
INSERT INTO student (firstname, lastname, class, summary, previousexperience, contactinfo, username)
VALUES('Simin', 'Nickelsen', '.NET', 'I am rocking dis shit', 'Adobe', 'SNickelsen@yahoo.com', 'siminN');
-----------------------------------------------------------------------------------
--Softskills

--inserting Adchiever into softskills table and only have to define ( skill). 
--The skill_id is already generated when a new skill is inserted
INSERT INTO softskills ( skill)
VALUES ('Achiever');

--Same as above.
INSERT INTO softskills ( skill)
VALUES ('Detail oriented');

-- Now if want assign a student with a soft skill, we insert id values into student_softskills.
--the (student_id, softskill_id) are the only two columns in student_softskills.
--So (1) pertains to Kyle and (1002) refers to Detailed oriented soft skill(softskill_id)
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (1,1);

-- Assigning simin the softskill(1004) adchiever.
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,2);
-----------------------------------------------------------------------------------
--projects

--creating a project to assign to a student(project_id = 1)
INSERT INTO project (title, summary, student_id)
Values ('Vending machine', 'people paid money and got snacks', 1);

INSERT INTO project (title, summary, student_id)
values ('TicTacToe', 'A interactive webpage using JavaScript', 2)
-----------------------------------------------------------------------------------
--Academic

--using the student_id (1) to insert data in academic
INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 1, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science');

--using the student_id (2) to insert data in academic
INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 2, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science');
-----------------------------------------------------------------------------------
--Interests

INSERT INTO interests (interest)
VALUES ('Front end Develpoer')

INSERT INTO interests (interest)
VALUES ('Software Tester')

INSERT INTO student_interests (student_id, interest_id)
VALUES (1,1)

INSERT INTO student_interests (student_id, interest_id)
VALUES (2,2)

-----------------------------------------------------------------------------------
--Programming languages

INSERT INTO programming_language (name)
VALUES ('Java')

INSERT INTO  programming_language (name) 
VALUES ('C#')

INSERT INTO programming_language (name)
VALUES ('JavaScript')
-----------------------------------------------------------------------------------
--Programming languages for employers

-- insert into employer_language
INSERT INTO employer_language (employer_id, programminglanguage_id)
VALUES (1,1);
-----------------------------------------------------------------------------------
--Programming languages for students

--insert into student-language
INSERT INTO student_language (student_id, programminglanguage_id)
Values (1, 2);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (2, 3);
