SELECT firstname, lastname, role_title
FROM student
INNER JOIN user_passord ON student.username = user_passord.username

SELECT firstname, lastname, role_title
FROM staff
INNER JOIN user_passord ON staff.username = user_passord.username

SELECT company, role_title
FROM employer
INNER JOIN user_passord ON employer.username = user_passord.username

SELECT firstname, lastname, class
FROM student
WHERE class = '.NET'

SELECT firstname, lastname, major
FROM student
INNER JOIN academic ON student.student_id = academic.student_id
WHERE major = 'Computer Science'

SELECT firstname, lastname, skill
FROM student
INNER JOIN student_softskills ON student.student_id = student_softskills.student_id
INNER JOIN softskills ON student_softskills.softskill_id = softskills.softskill_id
WHERE skill = 'Listener'

SELECT firstname, lastname, contactinfo
FROM student
WHERE student_id = 1