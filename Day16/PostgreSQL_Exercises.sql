-- 1. Retrieve everything from a table
select * from cd.facilities

-- 2. Retrieve specific columns from a table
select name, membercost from cd.facilities

-- 3. Control which rows are retrieved
select * from cd.facilities where membercost > 0

-- 4. Control which rows are retrieved - part 2
select facid, name, membercost, monthlymaintenance from cd.facilities 
where membercost > 0 and membercost < (monthlymaintenance/50)

-- 5. Basic string searches
select * from cd.facilities 
where name like '%Tennis%'

-- 6. Matching against multiple possible values
select * from cd.facilities where facid in (1,5)

-- 7. Classify results into buckets
select name, case 
	when monthlymaintenance > 100 then 'expensive'
	else 'cheap'
	end as cost	
from cd.facilities

-- 8. Working with dates
select memid, surname, firstname, joindate 
	from cd.members
	where joindate >= '2012-09-01';          

-- 9. Removing duplicates, and ordering results
select surname from cd.members group by surname order by surname limit 10

-- 10. Combining results from multiple queries
select surname from cd.members
union
select name from cd.facilities; 

-- 11. Simple aggregation
select max(joindate) as latest from cd.members;          

-- 12. More aggregation
select firstname, surname, joindate from cd.members
where joindate = (select max(joindate) from cd.members);          