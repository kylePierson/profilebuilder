
create table student (
 student_id integer identity,
 firstname varchar(32) NOT NULL,
 lastname varchar(32) NOT NULL,
 class varchar(32) NOT NULL,
 summary varchar (max),
 previousexperience varchar (max),
 linkedin varchar(200),
 contactinfo varchar (200),
 username varchar (32) NOT NULL,
 acedemicdegree varchar (200),
 CONSTRAINT pk_student_student_id PRIMARY KEY (student_id),
 CONSTRAINT ck_class CHECK (class IN ('.NET', 'Java'))
 );

create table employer (
employer_id integer identity NOT NULL,
company varchar (200) NOT NULL,
contactfirstname varchar(32) NOT NULL,
contactlastname varchar(32) NOT NULL,
address varchar (max) NOT NULL,
username varchar (32) NOT NULL,
contactinfo varchar (200) NOT NULL,
CONSTRAINT pk_employer_employer_id PRIMARY KEY(employer_id)
);

create table staff (
staff_id integer identity NOT NULL,
firstname varchar (32) NOT NULL,
lastname varchar (32) NOT NULL,
title varchar (32) NOT NULL,
username varchar (32) NOT NULL,
CONSTRAINT staff_staff_id PRIMARY KEY (staff_id)
);

CREATE TABLE user_password (
username varchar (32) NOT NULL,
password varchar (32) NOT NULL,

role_title varchar(32) NOT NULL
CONSTRAINT user_password_username_password PRIMARY KEY (username)
CONSTRAINT ck_role_title CHECK (role_title in('Student', 'Employer', 'Staff'))
);


create table interests (
interest_id integer identity NOT NULL,
interest varchar(max) NOT NULL
CONSTRAINT interests_interest_id PRIMARY KEY (interest_id) 
);

create table student_interests (
student_id integer NOT NULL,
interest_id integer NOT NULL,
CONSTRAINT student_interests_student_id_interest_id PRIMARY KEY (student_id,interest_id)
);

create table softskills (
softskill_id integer identity NOT NULL,
skill varchar (32) NOT NULL,
CONSTRAINT softskills_softskills_id PRIMARY KEY (softskill_id)
);

create table student_softskills (
student_id integer NOT NULL,
softskill_id integer NOT NULL
CONSTRAINT student_softskills_student_id_softskill_id PRIMARY KEY (student_id,softskill_id)
);

create table project (
 project_id integer identity NOT NULL,
 title varchar (32) NOT NULL,
 summary varchar (max) NOT NULL,
 student_id integer NOT NULL
 CONSTRAINT project_project_id PRIMARY KEY (project_id)
);

create table programming_language (
programminglanguage_id integer identity NOT NULL,
name varchar (32) NOT NULL
CONSTRAINT programming_language_programminglanguage_id PRIMARY KEY (programminglanguage_id)
);

create table project_programming (
project_id integer NOT NULL,
programminglanguage_id integer NOT NULL,
CONSTRAINT project_programming_project_id_programminglanguage_id PRIMARY KEY (project_id,programminglanguage_id)
);

create table employer_language (
employer_id integer NOT NULL,
programminglanguage_id integer NOT NULL
CONSTRAINT employer_language_employer_id_programminglanguage_id PRIMARY KEY (employer_id,programminglanguage_id)
);

create table student_language (
student_id integer NOT NULL,
programminglanguage_id integer NOT NULL
CONSTRAINT student_language_student_id_programminglanguage_id PRIMARY KEY (student_id,programminglanguage_id)
);


ALTER TABLE student ADD FOREIGN KEY (username) REFERENCES user_password(username);
ALTER TABLE employer ADD FOREIGN KEY (username) REFERENCES user_password(username);
ALTER TABLE staff ADD FOREIGN KEY (username) REFERENCES user_password(username);
ALTER TABLE student_interests ADD FOREIGN KEY (interest_id) REFERENCES interests(interest_id);
ALTER TABLE student_interests ADD FOREIGN KEY (student_id) REFERENCES student(student_id);
ALTER TABLE student_softskills ADD FOREIGN KEY (student_id) REFERENCES student(student_id);
ALTER TABLE student_softskills ADD FOREIGN KEY (softskill_id) REFERENCES softskills(softskill_id);
ALTER TABLE project ADD FOREIGN KEY (student_id) REFERENCES student(student_id);
ALTER TABLE student_language ADD FOREIGN KEY (programminglanguage_id) REFERENCES programming_language (programminglanguage_id)
ALTER TABLE student_language ADD FOREIGN KEY (student_id) REFERENCES student (student_id)
ALTER TABLE employer_language ADD FOREIGN KEY (programminglanguage_id) REFERENCES programming_language (programminglanguage_id)
