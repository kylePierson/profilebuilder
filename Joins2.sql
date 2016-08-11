SELECT student.firstname,student.lastname, student.summary, student.perviousexperience, student.class, student.contactinfo,
academic.degree,academic.school, academic.major, softskills.skill, interests.interest
FROM student
INNER JOIN academic on student.student_id = academic.student_id
INNER JOIN student_softskills ON student.student_id = student_softskills.student_id
INNER JOIN softskills ON student_softskills.softskill_id = softskills.softskill_id
INNER JOIN student_interests ON student.student_id = student_interests.student_id
INNER JOIN interests ON student_interests.interest_id = interests.interest_id
Where  student.student_id =1;

select * from student_softskills;
select * from student;
select * from interests;
select * from student_interests;
select * from softskills;
select * from academic;

INSERT INTO interests (interest)
VALUES ('Front end Develpoer');

INSERT INTO interests (interest)
VALUES ('Software Tester');

INSERT INTO student_interests (student_id, interest_id)
VALUES (1,2);

INSERT INTO student_interests (student_id, interest_id)
VALUES (2,1);

SELECT student.firstname,student.lastname, student.summary, student.perviousexperience, student.class, student.contactinfo,
academic.degree,academic.school, academic.major, softskills.skill, interests.interest
FROM student
INNER JOIN academic on student.student_id = academic.student_id
INNER JOIN student_softskills ON student.student_id = student_softskills.student_id
INNER JOIN softskills ON student_softskills.softskill_id = softskills.softskill_id
INNER JOIN student_interests ON student.student_id = student_interests.student_id
INNER JOIN interests ON student_interests.interest_id = interests.interest_id

SELECT *
FROM softskills

select *
from student_softskills
INNER JOIN student_softskills ON softskills.softskill_id = student_softskills.softskill_id