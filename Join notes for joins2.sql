
--inner joining student_softskills on student, then softskills on student_softskills
SELECT firstname, lastname, skill
FROM student
INNER JOIN student_softskills ON student.student_id = student_softskills.student_id
INNER JOIN softskills ON student_softskills.softskill_id = softskills.softskill_id

--inner joining student_interests on student using student_id, then interests on student_interests to link student and interests
SELECT student.firstname, student.lastname, interests.interest, student.student_id, interests.interest_id
FROM student
INNER JOIN student_interests ON student.student_id = student_interests.student_id
INNER JOIN interests ON student_interests.interest_id = interests.interest_id

--inserting kyle(1) as a software tester(3) using student_id and interest_id (1,3)
INSERT INTO student_interests (student_id, interest_id)
VALUES (1,3)

-- inserting Simin(2) as a front end developer(2) using student_id and interest_id (2,2)
INSERT INTO student_interests (student_id, interest_id)
VALUES (2,2)

--This WILL replace kyle's(1) interests(software tester(3)) to janitor(5)
UPDATE student_interests 
SET interest_id = 5
WHERE student_id = 1

-- inner joining student and academic using student_id as primary key
SELECT firstname, lastname, degree, class
FROM student
INNER JOIN academic ON student.student_id = academic.student_id

--inserting and updating student_language
--(id = 1)
INSERT INTO programming_language (name)
VALUES ('JavaScript')

--(id = 2)
INSERT INTO programming_language (name)
VALUES ('C#')

INSERT INTO student_language (student_id, programminglanguage_id)
VALUES (1,1)

--just practicing UPDATING student(kyle) language
UPDATE student_language
SET programminglanguage_id = 2
WHERE student_id = 1

INSERT INTO student_language (student_id, programminglanguage_id)
VALUES (2,1)

UPDATE student_language
SET programminglanguage_id = 1
WHERE student_id = 2

select *
from student_language

SELECT student.firstname, student.lastname, programming_language.name
FROM student
INNER JOIN student_language ON student.student_id = student_language.student_id
INNER JOIN programming_language ON student_language.programminglanguage_id = programming_language.programminglanguage_id

--inserting and updating employer language 
INSERT INTO programming_language (name)
VALUES ('COBOL')

INSERT INTO programming_language (name)
VALUES ('Java')

INSERT INTO employer_language (employer_id, programminglanguage_id)
VALUES (1,3)

UPDATE employer_language
SET programminglanguage_id = 6
WHERE employer_id = 1

SELECT employer.contactfirstname, employer.contactlastname, programming_language.name, programming_language.programminglanguage_id
FROM employer
INNER JOIN employer_language ON employer.employer_id = employer_language.employer_id
INNER JOIN programming_language ON employer_language.programminglanguage_id = programming_language.programminglanguage_id



