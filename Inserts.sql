INSERT INTO employer (company, contactfirstname, contactlastname, address, username, contactinfo)
VALUES('Hyland', 'James', 'Vorous','Westlake, OH','pokemonGo69', 'J.valous@onbase.com');

INSERT INTO staff (firstname, lastname, title, username)
Values('Josh', 'Tucholski', 'Instructor', 'jTucholski');

insert into user_password (username, password, role_title)
values ('jTucholski', 'password', 'Staff');

INSERT INTO student (firstname, lastname, class, summary, perviousexperience, contactinfo, username)
VALUES('Kyle', 'Pierson', '.NET', 'I am the best .NET student in this bitch', 'Bindows', 'myShitIsLegit@yahoo.com', 'TolegitToQuit');

INSERT INTO student (firstname, lastname, class, summary, perviousexperience, contactinfo, username)
VALUES('Simin', 'Nickelsen', '.NET', 'I am rocking dis shit', 'Adobe', '432-345-543', 'siminN');

INSERT INTO softskills ( skill)
VALUES ('Adchiever');

INSERT INTO softskills ( skill)
VALUES ('Detail oriented');

INSERT INTO softskills ( skill)
VALUES ('Listener');

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (1,1);

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,2);

INSERT INTO student_softskills (student_id, softskill_id)
VALUES (2,3);

INSERT INTO project (title, summary)
Values ('Vending machine', 'people paid money and got snacks');

INSERT INTO project_student (student_id, project_id)
VALUES (2,1);

INSERT INTO user_passord (username, password, role_title)
VALUES ('TolegitToQuit', 'password', 'Student')

INSERT INTO user_passord (username, password, role_title)
VALUES ('siminN', 'password', 'Student')

INSERT INTO user_passord (username, password, role_title)
VALUES ('pokemonGo69', 'password', 'Employer')

INSERT INTO user_passord (username, password, role_title)
VALUES ('jTucholski', 'password', 'Staff')

INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 2, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science')

INSERT INTO academic(degree, school, student_id, school_address, major)
VALUES ('Certificate','Tech Elevator', 1, '7100 Euclid Ave #140, Cleveland, OH ','Computer Science')
