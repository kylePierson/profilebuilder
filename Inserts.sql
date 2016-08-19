-----------------------------------------------------------------------------------
--Employer
--  assigning James, using username to identify him, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('pokemonGo69', 'password', 'Employer');

INSERT INTO user_password (username, password, role_title)
VALUES ('techelevator', 'password', 'Employer');

--This is inserting employer contact info into employer and inserting data(values) for all the columns 
INSERT INTO employer (company, contactfirstname, contactlastname, address, username, contactinfo)
VALUES('Hyland', 'James', 'Vorous','Westlake, OH','pokemonGo69', 'J.valous@onbase.com');

INSERT INTO employer (company, contactfirstname, contactlastname, address, username, contactinfo)
VALUES('Tech Elevator', 'Josh', 'T.','CLE','techelevator', 'test@tech.com');
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
VALUES ('piersonkyle90', 'password', 'Student');

INSERT INTO user_password (username, password, role_title)
VALUES ('james', 'password', 'Student');

-- same as the staff, but now it is populating student table and columns 
INSERT INTO student (firstname, lastname, class, previousexperience, contactinfo, username, summary)
VALUES('Kyle', 'Pierson', '.NET', 'BioMechanic', 'piersonkyle90@yahoo.com', 'piersonkyle90', 'Currently I’m a .Net boot camp student at Tech Elevator with a background in Engineering and Customer Service. I spent 3 years at an Income Tax firm and 3 more in a Lab Environment where I helped in implementing procedure and interpreting the results into usable data. I am a career learner, often spending my time finding out the why or how in many different subjects. I’ve always had a knack for absorbing information, educating others, and creative problem solving. After I graduate, I’m looking to apply the knowledge I gain along with my unique skill set to a Software Developer role that allows me to collaborate, innovate, and grow as person.');

INSERT INTO student (firstname, lastname, class, previousexperience, contactinfo, username, summary)
VALUES('James', 'Vorous', 'JAVA','Beerhead Bar & Eatery', 'piersonkyle90@yahoo.com', 'james', 'I am a Java bootcamp student at Tech Elevator, priding myself on my ability to achieve the goals I set for myself through perseverance. Though I have worked in a variety of fields, one trait that always followed me is my dedicated work ethic. I feel my programming skills coupled with my tireless enthusiasm will have a positive impact on a development team.'
');

--  assigning Simin, using username to identify her, a password and roll
INSERT INTO user_password (username, password, role_title)
VALUES ('siminN', 'password', 'Student');

--since the staff creates the student profile.
INSERT INTO student (firstname, lastname, class, summary, previousexperience, contactinfo, username)
VALUES('Simin', 'Nickelsen', '.NET', 'I am pursuing the .NET track at Tech Elevator software developer bootcamp. I have one year of experience as a web developer at Global Vocabulary which helped me to develop my problem-solving and trouble-shooting skills.', 'Engineer', 'SNickelsen@yahoo.com', 'siminN');
-----------------------------------------------------------------------------------
--Softskills


--inserting Adchiever into softskills table and only have to define ( skill). 
--The skill_id is already generated when a new skill is inserted
INSERT INTO softskills ( skill)
VALUES ('Achiever');

--Same as above.
INSERT INTO softskills ( skill)
VALUES ('Emotional intelligence');

INSERT INTO softskills ( skill)
VALUES ('Patience');

INSERT INTO softskills ( skill)
VALUES ('Empathy');

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

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (1,2);

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (3,2);

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (3,3);

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,4);

-----------------------------------------------------------------------------------
--projects

--creating a project to assign to a student(project_id = 1)
INSERT INTO project (title, summary, student_id)
Values ('Vending machine', 'Make a console app', 1);

INSERT INTO project (title, summary, student_id)
values ('TicTacToe', 'A interactive webpage using JavaScript, MVC, HTML and CSS', 2);

INSERT INTO project (title, summary, student_id)
Values ('Vending machine', 'Make a console app', 2);

INSERT INTO project (title, summary, student_id)
values ('TicTacToe', 'A interactive webpage using JavaScript, MVC, HTML and CSS', 1);

INSERT INTO project (title, summary, student_id)
Values ('Vending machine', 'Make a console app',3);

INSERT INTO project (title, summary, student_id)
values ('TicTacToe', 'A interactive webpage using JavaScript, MVC, HTML and CSS', 3)


-----------------------------------------------------------------------------------
--Interests

INSERT INTO interests (interest)
VALUES ('Front end Develpoer');

INSERT INTO interests (interest)
VALUES ('Software Tester');

INSERT INTO interests (interest)
VALUES ('QA');

INSERT INTO student_interests (student_id, interest_id)
VALUES (1,1);

INSERT INTO student_interests (student_id, interest_id)
VALUES (2,2);

INSERT INTO student_interests (student_id, interest_id)
VALUES (1,2);

INSERT INTO student_interests (student_id, interest_id)
VALUES (1,3);

INSERT INTO student_interests (student_id, interest_id)
VALUES (3,2);

INSERT INTO student_interests (student_id, interest_id)
VALUES (3,1)


-----------------------------------------------------------------------------------
--Programming languages

INSERT INTO programming_language (name)
VALUES ('Java')

INSERT INTO  programming_language (name) 
VALUES ('C#')

INSERT INTO programming_language (name)
VALUES ('JavaScript')

INSERT INTO programming_language (name)
VALUES ('SQL')

INSERT INTO programming_language (name)
VALUES ('HTML')

INSERT INTO programming_language (name)
VALUES ('CSS')
-----------------------------------------------------------------------------------
--Programming languages for employers

-- insert into employer_language
INSERT INTO employer_language (employer_id, programminglanguage_id)
VALUES (1,1);

INSERT INTO employer_language (employer_id, programminglanguage_id)
VALUES (1,2);

INSERT INTO employer_language (employer_id, programminglanguage_id)
VALUES (2,3);

INSERT INTO employer_language (employer_id, programminglanguage_id)
VALUES (2,1);
-----------------------------------------------------------------------------------
--Programming languages for students

--insert into student-language
INSERT INTO student_language (student_id, programminglanguage_id)
Values (1, 2);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (1, 4);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (2, 3);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (2, 4);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (2, 1);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (3, 3);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (3, 2);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (1, 1);

INSERT INTO student_language (student_id, programminglanguage_id)
Values (2, 1);


UPDATE student 
set  elevatorpitch = 'Currently I’m a .Net boot camp student at Tech Elevator with a background in Engineering and Customer Service. I spent 3 years at an Income Tax firm and 3 more in a Lab Environment where I helped in implementing procedure and interpreting the results into usable data. I am a career learner, often spending my time finding out the why or how in many different subjects. I’ve always had a knack for absorbing information, educating others, and creative problem solving. After I graduate, I’m looking to apply the knowledge I gain along with my unique skill set to a Software Developer role that allows me to collaborate, innovate, and grow as person.'
where student_id = 1;

Update student 
set elevatorpitch = 'I am a Java bootcamp student at Tech Elevator, priding myself on my ability to achieve the goals I set for myself through perseverance. Though I have worked in a variety of fields, one trait that always followed me is my dedicated work ethic. I feel my programming skills coupled with my tireless enthusiasm will have a positive impact on a development team.'
where student_id = 2;

Update student 
set elevatorpitch = 'I am pursuing the .NET track at Tech Elevator software developer bootcamp. I have one year of experience as a web developer at Global Vocabulary which helped me to develop my problem-solving and trouble-shooting skills.'
where student_id = 3;