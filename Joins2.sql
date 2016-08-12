SELECT student.firstname,student.lastname, student.summary, student.perviousexperience, student.class, student.contactinfo,
academic.degree,academic.school, academic.major, softskills.skill, interests.interest
FROM student
INNER JOIN academic on student.student_id = academic.student_id
INNER JOIN student_softskills ON student.student_id = student_softskills.student_id
INNER JOIN softskills ON student_softskills.softskill_id = softskills.softskill_id
INNER JOIN student_interests ON student.student_id = student_interests.student_id
INNER JOIN interests ON student_interests.interest_id = interests.interest_id

--select * from student_softskills;
--select * from student;
--select * from interests;
--select * from student_interests;
--select * from softskills;
--select * from academic;



