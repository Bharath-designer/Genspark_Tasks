-- 1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

create proc PrintBooksPublishedByAuthor
@firstname varchar(20)
as begin
select title, concat(au_fname,' ', au_lname) as AuthorName from titles 
join titleauthor on titleauthor.title_id = titles.title_id
join authors on authors.au_id = titleauthor.au_id
join publishers on titles.pub_id = publishers.pub_id
where au_fname = @firstname
end

exec PrintBooksPublishedByAuthor 'Marjorie'
go

-- 2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

create proc PrintBooksDetailsByEmployee
@firstname varchar(20)
as begin
select title, price, qty, (qty * price) as cost
from titles t
join sales s on s.title_id = t.title_id
join employee e on e.pub_id = t.pub_id
where fname = @firstname
end


exec PrintBooksDetailsByEmployee 'Paolo'
go

--3) Create a query that will print all names from authors and employees

select au_fname as name from authors
union
select fname from employee

--4) Create a  query that will float the data from sales, titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,

select top 5 title, pub_name, concat(a.au_fname,' ', a.au_lname) as [Author Name], qty, (qty * price) as cost from titles t
join publishers p on t.pub_id = p.pub_id
join titleauthor ta on ta.title_id = t.title_id
join authors a on a.au_id = ta.au_id
join sales s on s.title_id = t.title_id
order by cost
