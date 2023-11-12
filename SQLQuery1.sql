
select * from transation_log where library_Id=1 and return_Date is null

create procedure trans_Record as begin
select c.trans_No'Transaction No' ,a.library_id' Library ID', 
a.stud_Name'Student Name',b.bId 'Book ID', b.bName'Book Name',
c.issue_Date'Book Issued Date',c.return_Date'Book Returned Date'
from transation_log c full outer join  newStudent a on a.library_Id =c.library_Id full outer join newBook b on c.book_Id =b.bId
end

exec trans_Record
select * from  newBook select * from newStudent  select * from transation_log

select * from transation_log where library_Id like '%1%'or book_Id like '%2%'

create table admin_login(
id int identity(1,1) primary key,
user_name varchar(50),
user_pwd  varchar(50))
insert into admin_login values('admin','admin')

create procedure admin_log(
@uname varchar(50),
@pwd varchar(50))
as begin 
select * from admin_login where 
user_name =@uname and user_pwd =@pwd
end
update admin_login set user_name='admin', user_pwd='admin'

create table stud_message(
id int identity(1,1) primary key,
nav_message varchar(1000),
box_message varchar(1000))
insert into stud_message  values ('wertyuiifdfsd')
update  stud_message set nav_message ='wertyuiifd345678fsd'
Select  nav_message from stud_message 
alter table  stud_message drop column box_message 
select * from stud_message