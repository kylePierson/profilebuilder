
--  assigning James, using username to identify him, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('pokemonGo69', 'password', 'Employer');

--This is inserting employer contact info into employer and inserting data(values) for all the columns 
INSERT INTO employer (company, contactfirstname, contactlastname, address, username, contactinfo)
VALUES('Hyland', 'James', 'Vorous','Westlake, OH','pokemonGo69', 'J.valous@onbase.com');

--  assigning Josh, using username to identify him, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('jTucholski', 'password', 'Staff');

--inserting a staff member with Josh and info(values) into the columns columns 
INSERT INTO staff (firstname, lastname, title, username)
Values('Josh', 'Tucholski', 'Instructor', 'jTucholski');


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
VALUES('Tyler', 'Pompeii', '.NET', 'I am rocking dis shit', 'Adobe', '432-345-543', 'tylerP');


INSERT INTO user_password (username, password, role_title)
VALUES ('tylerP', 'password', 'Student');

--since the staff creates the student profile.
INSERT INTO student (firstname, lastname, class, summary, previousexperience, contactinfo, username)
VALUES('Simin', 'Nickelsen', '.NET', 'I am rocking dis shit', 'Adobe', '432-345-543', 'siminN');

UPDATE student
SET contactinfo = 'SNickelsen@yahoo.com'
WHERE student_id = 3

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

INSERT INTO student (firstname, lastname, class, summary, perviousexperience, contactinfo, username)
VALUES('Tyler', 'Pompeii', '.NET', 'I am the best .NET student in this bitch', 'Bindows', 'myShitIsLegit@yahoo.com', 'Tyler');

-- Now if want assign a student with a soft skill, we insert id values into student_softskills.
--the (student_id, softskill_id) are the only two columns in student_softskills.
--So (1) pertains to Kyle and (1002) refers to Detailed oriented soft skill(softskill_id)
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,1);

--This is Simin(student_id 2) and assigning her Listener(softskill_id 1003)
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (3,3);

-- Assigning simin the softskill(1004) adchiever.
INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,2);

--creating a project to assign to a student(project_id = 1)
INSERT INTO project (title, summary, student_id)
Values ('Vending machine', 'people paid money and got snacks', 3);

--using the student_id (2) to insert data in academic
INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 2, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science');

--using the student_id (3) to insert data in academic
INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 3, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science');

--This is just some shit
SELECT *
FROM softskills;

-- insert into program_language
INSERT INTO  programming_language (name) VALUES ('C#');
-- insert into employer_language
INSERT INTO employer_language (employer_id, programminglanguage_id) VALUES (1,1);


--insert into student-language
insert into student_language Values (1, 1);
insert into student_language Values (2, 1);

Select * from student;
select * from programming_language;
select * from student_language;

--Query for finding students that have a specific programming language
select student.firstname, student.lastname, student.class
from student
inner join student_language on student.student_id = student_language.student_id
inner join programming_language on programming_language.programminglanguage_id = student_language.programminglanguage_id
where programming_language.name = 'C#';

INSERT INTO interests (interest)
VALUES ('Front end Develpoer')

INSERT INTO interests (interest)
VALUES ('Software Tester')

INSERT INTO student_interests (student_id, interest_id)
VALUES (2,2)

INSERT INTO student_interests (student_id, interest_id)
VALUES (3,1)

